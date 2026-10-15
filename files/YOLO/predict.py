import argparse
import glob
import os
import sys
import time
from concurrent.futures import ThreadPoolExecutor

startTime = time.perf_counter()

from ultralytics import YOLO
from utils import GetModelPath

parser = argparse.ArgumentParser(description="YOLO Prediction Script")
parser.add_argument("--model", type=str, default=None, help="Path to trained YOLO model file")
parser.add_argument("--source", type=str, default=None, help="Path to input image file or directory")
parser.add_argument("--conf", type=float, default=0.1, help="Confidence threshold")
parser.add_argument("--output", type=str, default=None, help="Path to output bbrf results file")
parser.add_argument("--batch", type=int, default=32, help="Inference batch size")
parser.add_argument("--workers", type=int, default=2, help="Threads decoding the next batch while the current one is detected; 0 lets ultralytics read the files itself")
parser.add_argument("--half", action="store_true", help="Run inference in half precision (FP16); changes confidences slightly")
parser.add_argument("--imgsz", type=int, default=None, help="Inference image size; omitted uses the ultralytics default (640)")

args = parser.parse_args()

modelPath = args.model if args.model else GetModelPath(useDefault=True)
if not modelPath:
    print("Could not find model.")
    exit(1)

print(f"Model path: {modelPath}")
model = YOLO(modelPath)
loadSeconds = time.perf_counter() - startTime

sourcePath = args.source if args.source else os.path.join("YOLO", "input")
outputPath = args.output if args.output else os.path.join("YOLO", "output", "results.bbrf")

imagePaths = []
if os.path.isfile(sourcePath):
    imagePaths = [sourcePath]
elif os.path.isdir(sourcePath):
    imagePaths = glob.glob(os.path.join(sourcePath, "*.jpg")) + \
                 glob.glob(os.path.join(sourcePath, "*.jpeg")) + \
                 glob.glob(os.path.join(sourcePath, "*.png"))

batchSize = max(1, args.batch) if args.batch else 32
workers = max(0, args.workers)

#Only what was asked for is passed, so the defaults run exactly the call this script always made
predictArguments = {"show": False, "conf": args.conf, "save": False, "verbose": False}
#ultralytics 8.4 takes precision as quantize; its half argument is deprecated and logs a warning on every call
if args.half:
    predictArguments["quantize"] = 16
if args.imgsz:
    predictArguments["imgsz"] = args.imgsz


def WriteResult(file, imagePath, result):
    fileName = os.path.splitext(os.path.basename(imagePath))[0]
    if not result.boxes or len(result.boxes) < 1:
        file.write(f"{fileName}\n")
        return

    #One device-to-host copy per image instead of three per box. tolist() turns float32 into the same Python floats item() does, so the text is unchanged
    boxes = result.boxes.cpu()
    for (x1, y1, x2, y2), confidence, labelIndex in zip(boxes.xyxy.tolist(), boxes.conf.tolist(), boxes.cls.tolist()):
        width = x2 - x1
        height = y2 - y1
        file.write(f"{fileName}\t{int(labelIndex)}\t{x1}\t{y1}\t{width}\t{height}\t{confidence}\n")


imageCount = 0
batchCount = 0
firstBatchSeconds = 0.0
writeSeconds = 0.0
speedTotals = {"preprocess": 0.0, "inference": 0.0, "postprocess": 0.0}


def Detect(file, sources, imagePaths_Batch=None):
    global imageCount, batchCount, firstBatchSeconds, writeSeconds

    results = model(source=sources, batch=len(sources), **predictArguments)

    #ultralytics drops a path it cannot decode from the batch, so a path source is named by the result rather than by position. Decoded arrays carry no path and are named by the list they were decoded from
    imagePaths_Result = imagePaths_Batch if imagePaths_Batch is not None else [result.path for result in results]

    writeStart = time.perf_counter()
    for imagePath, result in zip(imagePaths_Result, results):
        WriteResult(file, imagePath, result)
        for key in speedTotals:
            speedTotals[key] += result.speed.get(key) or 0.0
    file.flush()
    writeSeconds += time.perf_counter() - writeStart

    imageCount += len(results)
    batchCount += 1
    if batchCount == 1:
        firstBatchSeconds = time.perf_counter() - loopStart


loopStart = time.perf_counter()

if outputPath and imagePaths:
    outputDir = os.path.dirname(os.path.abspath(outputPath))
    if outputDir:
        os.makedirs(outputDir, exist_ok=True)
    with open(outputPath, "w", encoding="utf-8") as file:
        if workers < 1:
            for i in range(0, len(imagePaths), batchSize):
                Detect(file, imagePaths[i:i + batchSize])
        else:
            #The next batch is decoded while the current one is on the GPU. imread is the function the ultralytics loader decodes paths with, so the model sees the same BGR arrays
            from ultralytics.utils.patches import imread

            with ThreadPoolExecutor(max_workers=workers) as executor:
                def Submit(index):
                    return [(imagePath, executor.submit(imread, imagePath)) for imagePath in imagePaths[index:index + batchSize]]

                futures = Submit(0)
                for i in range(0, len(imagePaths), batchSize):
                    decoded = [(imagePath, future.result()) for imagePath, future in futures]
                    if i + batchSize < len(imagePaths):
                        futures = Submit(i + batchSize)

                    decoded = [(imagePath, image) for imagePath, image in decoded if image is not None]
                    if decoded:
                        Detect(file, [image for _, image in decoded], [imagePath for imagePath, _ in decoded])

loopSeconds = time.perf_counter() - loopStart

device = getattr(getattr(model, "predictor", None), "device", None)
speedMeans = {key: (value / imageCount if imageCount else 0.0) for key, value in speedTotals.items()}
print(
    f"predict: images={imageCount} seconds={loopSeconds:.3f} rate={(imageCount / loopSeconds if loopSeconds > 0 else 0.0):.1f} "
    f"load_seconds={loadSeconds:.3f} first_batch_seconds={firstBatchSeconds:.3f} write_seconds={writeSeconds:.3f} "
    f"preprocess_ms={speedMeans['preprocess']:.3f} inference_ms={speedMeans['inference']:.3f} postprocess_ms={speedMeans['postprocess']:.3f} "
    f"device={device} imgsz={args.imgsz or 'default'} half={args.half} batch={batchSize} workers={workers}",
    file=sys.stderr)
