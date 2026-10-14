# DiGi.YOLO

**DiGi.YOLO** is a C# engineering and architectural software library suite designed for BIM and CAD integrations (such as Revit, RhinoCommon, Grasshopper, and Dynamo BIM).

---

## 🏗️ Project Architecture & Assemblies

The repository contains the following core components and assemblies:
* **[DiGi.YOLO](DiGi.YOLO)** (Path: `DiGi.YOLO\DiGi.YOLO`)

---

## 📖 Documentation & Guides

Comprehensive guides and operational documentation are available in the [DiGi.YOLO GitHub Wiki](https://github.com/DiGi-Organization/DiGi.YOLO/wiki):
* **[Year Built Prediction Pipeline](https://github.com/DiGi-Organization/DiGi.YOLO/wiki/Year-Built-Prediction-Pipeline):** End-to-end architecture, frozen weights provenance, Python requirements, database row scoping, and superseding the legacy file-based workflow.
* **[Running Scripts Manually](https://github.com/DiGi-Organization/DiGi.YOLO/wiki/Running-Scripts-Manually):** Standalone execution guide for `predict.py`, `train.py`, and `export.py`.
* **[ConsoleApp Operator Guide (DiGi.GIS.YOLO.UI)](https://github.com/DiGi-Organization/DiGi.GIS.YOLO.UI/wiki/Using-the-ConsoleApp):** Complete operational manual for the headless runner `DiGi.GIS.YOLO.UI.ConsoleApp.exe`.

---

## 🤖 YOLO Model & Execution Pipeline

### Frozen Weights Provenance
The pipeline depends on one frozen checkpoint, `YOLO/models/model.pt`. Since 2026-10-08 that is **`train9_fresh`**, selected by the detector gate of [DiGi.GIS.YOLO.UI#12](https://github.com/DiGi-Organization/DiGi.GIS.YOLO.UI/issues/12) and shipped together with the year-built regressor fitted to its features ([DiGi.GIS.ML#13](https://github.com/DiGi-Organization/DiGi.GIS.ML/issues/13)). The values below are read out of the checkpoint itself (`version`, `date`, `train_args`) and its run's `results.csv`, not recorded by hand:

| | `train9_fresh` (shipped) | `train8` (previous; the rollback) |
|---|---|---|
| Architecture | YOLO26x (`yolo26x.yaml`), 58 810 878 parameters, `nc = 1` `{0: 'Building'}` | YOLOv8x (`yolov8x.yaml`), 68 153 571 parameters, `nc = 1` |
| Saved | 2026-10-07 (best epoch) | 2025-05-23 |
| ultralytics | 8.4.165 | 8.3.130 |
| Epochs run / best | 150 / 145 (val mAP50-95 0.9327) | 150 |
| Patience | 50 | 100 |
| Image size / batch / seed | 640 / 16 / 0 | 640 / 16 / 0 |
| Optimizer / AMP | `auto` / on | `auto` / on |
| **Started from** | **`base/yolo26x.pt`**, SHA-256 `9fdd44a31c504547ffb81d2c6d9e6dac3493c8eaa8b0398d3f43bae6c7003e92`. `train_args.model` reads `…\train9_fresh\weights\last.pt` because the run was resumed twice, once from the tray and once automatically; the true start is the base checkpoint | `runs/detect/train7/weights/best.pt`, a continuation of `train7` |
| Dataset | rebuilt from the database by `--dataset` of DiGi.GIS.YOLO.UI#13: 25 008 labelled buildings over 217 counties, Train / Validate / Test 18 057 / 1 995 / 4 956, 228 569 images | lost; only the weights survive |
| Bytes | 118 333 605 | 136 730 810 |
| SHA-256 | `2dd833e438ffcb1352ae7675063c9f0c97ca1c39ce6410a0bfab96e8b3cbdc9a` | `c79d2edfb776c913494d698cd1899ed1a6c92d7caad594b674d39ce5ada7ea38` |

**Gate** (2026-10-07, same Test split; first-detection-year error in years against the label; *clean* = Test buildings `train8` cannot have seen, n = 179):

| Weights | Test mAP50 / mAP50-95 | All MAE / RMSE / exact | Clean MAE / RMSE / exact |
|---|---|---|---|
| `train8` | 0.979 / 0.813 | 0.503 / 1.907 / 0.883 | 2.235 / 4.342 / 0.598 |
| **`train9_fresh`** (selected) | 0.993 / 0.934 | 0.353 / 1.789 / 0.935 | 1.855 / 4.223 / 0.704 |

**Rejected candidate:** `train9_continue` (YOLOv8x continued from `train8`, 100 epochs, SHA-256 `382a9041af92e1e086704f214ee74ffaa46e14037d082724710b583eaee29bf8`): Test mAP 0.993 / 0.930; all 0.338 / 1.716 / 0.937; clean 1.883 / 4.196 / 0.704. It was practically tied with `train9_fresh`, and the gate's tie-break names the fresh candidate for its fully known history.

The shipped weights live in the git-ignored `user files/YOLO/models/model.pt`, the only file of `YOLO` the runner deployment carries. `train8`, the rejected candidate and the ONNX exports are kept in the training directory outside the workspace, as rollback and evaluation baselines.

To read these back from any `.pt` without installing torch: the file is a zip, and `data.pkl` inside it unpickles to a dictionary carrying `version`, `date` and `train_args`.

### Pretrained Base Checkpoint
New detectors are trained from the latest ultralytics pretrained weights rather than continued from `train8` alone ([#17](https://github.com/DiGi-Organization/DiGi.YOLO/issues/17)). The checkpoint is fetched once, never downloaded implicitly at train time, and stored in the git-ignored `user files/YOLO/models/base/`:

| | |
|---|---|
| File | `yolo26x.pt` (COCO, 80 classes) |
| Source | [ultralytics/assets `v8.4.0`](https://github.com/ultralytics/assets/releases/download/v8.4.0/yolo26x.pt) |
| Written by | ultralytics 8.3.222, 2025-12-30 |
| Parameters | 58 993 368 |
| Bytes | 118 667 365 |
| SHA-256 | `9fdd44a31c504547ffb81d2c6d9e6dac3493c8eaa8b0398d3f43bae6c7003e92` |

ultralytics 8.3.130 cannot load it; `check.py` reports a warning when the installed ultralytics is older than the version that wrote the model it is given. An ONNX export of a YOLO26 detector made with `nms` at its default (`None`, no NMS embedded) answers the raw `[batch, 4 + nc, 8400]` one-to-many head layout, so the in-process decoder is unchanged. Under ultralytics 8.4.165, passing `nms=False` would select the one-to-one NMS-free head and change the output shape.

Both start points train under 8.4.165: a 3-epoch smoke run (2026-09-29, RTX 5090, batch 16, imgsz 640, 240 images pseudo-labelled by `model.pt`) completed from `yolo26x.pt` and from `model.pt`, and each `best.pt` reloads and predicts. YOLO26 trains without the DFL loss term, so its loss columns differ from `train8`'s. Real runs belong to the argument-driven `train.py` ([#16](https://github.com/DiGi-Organization/DiGi.YOLO/issues/16)).

### Frozen ONNX Export Provenance
The same detector is also scored in process, without an interpreter, by
[DiGi.YOLO.ONNX](https://github.com/DiGi-Organization/DiGi.YOLO.ONNX). That path consumes an ONNX export of the checkpoint above, produced once by `export.py`. The export is as frozen as the checkpoint it came from, so it is recorded the same way - by a digest read off the artefact:

| | `train9_fresh` (current) | `train8` (previous) |
|---|---|---|
| Exported | 2026-10-07 ([DiGi.YOLO.ONNX#2](https://github.com/DiGi-Organization/DiGi.YOLO.ONNX/issues/2)) | 2026-09-03 |
| Exported by | ultralytics 8.4.165, Python 3.13, torch 2.7.0+cu128, onnx 1.22.0, onnxslim 0.1.96 | ultralytics 8.3.130, torch 2.7.0+cu128, onnx 1.22.0, onnxslim 0.1.96 |
| Flags | `format=onnx`, `imgsz=640`, `opset=12`, `dynamic=True`, `simplify=True`, `half=False`, `nms` unset ([#20](https://github.com/DiGi-Organization/DiGi.YOLO/issues/20)) | the same, with `nms=False` (under 8.3.130 only "do not embed NMS") |
| Metadata | `end2end: False` | — |
| Bytes | 224 047 962 | 273 083 173 |
| SHA-256 | `27ec80105e0215cde9cf091989310446c8703a49a30b5826ee0efea3382471a8` | `7cfb1a79209fa27a43f07a2151dfebaad3baedf93c94bc25a92a6bdbc4040213` |

Both graphs are `nc = 1` (`{0: 'Building'}`) and answer `[batch, 5, anchors]` (8 400 at 640). `dynamic=True` is what lets the C# runner feed whole batches; a static export pins the batch to one. `nms` is left at its default (`None`, no NMS embedded in the graph) - suppression stays on the C# side, where it can be matched to the thresholds ultralytics applies internally (IoU `0.7`, at most `300` detections) rather than baked into the graph. Under ultralytics 8.4.165, explicitly passing `nms=False` would select the one-to-one NMS-free head (output shape `[batch, 300, 6]`), which is not the layout the in-process decoder expects.

The export is not in git. The runner does not read it, so it is not deployed either. It is kept in the training directory and beside DiGi.YOLO.ONNX's parity fact.

### Python Helper Scripts & Requirements
`DiGi.YOLO` embeds Python helper scripts (`train.py`, `val.py`, `predict.py`, `export.py`, `check.py`, `utils.py`, `requirements.txt`, `conf.yaml`) as binary resources.
* **Script Export:** Callers can extract these runner scripts without instantiating a `YOLOModel` by calling `Modify.WriteScripts(targetDirectory)`. The scripts are rewritten on every call; the template `conf.yaml` is written only into a directory that has none, so it never replaces the `conf.yaml` of a dataset.
* **Training (`train.py`) and validation (`val.py`):** argument driven - see *Training a Detector from C#* below.
* **Inference (`predict.py`):** Supports command-line options:
  - `--model`: Path to trained YOLO `.pt` model weights file (default: `YOLO/models/model.pt`).
  - `--source`: Path to input image file or directory containing images (default: `YOLO/input`).
  - `--conf`: Confidence threshold float (default: `0.1`).
  - `--output`: Output filepath for bounding box results (`.bbrf`) in write mode (`"w"`) (default: `YOLO/output/results.bbrf`).
* **Export (`export.py`):** Turns the frozen checkpoint into the ONNX graph the in-process detector scores with. Options: `--model`, `--output`, `--imgsz` (default `640`), `--opset` (default `12`), `--static` (fixed axes instead of a dynamic batch). It prints the size and SHA-256 of what it wrote, which is what the provenance table above records. This is a one-off preparation step - it is why removing the Python dependency removes it from every *run* rather than from the repository.
* **Python Environment:** `pip install -r requirements.txt`. `ultralytics` is pinned exactly (`==8.4.165`; the shipped `train9_fresh` was trained and written by 8.4.165; the previous `train8` was written by 8.3.130, and 8.4.165 was adopted in #17 only after reproducing its detections on 1 000 held images - identical counts, box edges within 0.017 px) because a different ultralytics can be a different detector; `torch` is a floor (`>=2.6`) because its wheels are specific to a platform and CUDA build. The file itself carries the reasoning. `onnx` and `onnxslim` sit under an export-only heading there: `export.py` needs them and nothing that runs a prediction does.
* **Two ultralytics environments:** the main Python above carries the pinned 8.4.165; 8.3.130 is kept in the git-ignored `user files/YOLO/venv-ultralytics-8.3.130/` venv for the frozen `train8` checkpoint's parity and export path. The two must not share a settings file: ultralytics reads and writes one `settings.json` per machine, and the schemas differ (8.3.130 is v0.0.6, 8.4.165 is v0.0.8 with the `comet`/`openvino_msg` keys). Whichever version runs after the other finds a schema it does not expect, rewrites the file, prints a settings notice to stdout - into the stream `check.py` carries its JSON payload in - and, in the 8.3.130 direction, resets the settings to its own defaults, losing custom values such as `runs_dir` or `datasets_dir` without notice.
* **Settings isolation (`YOLO_CONFIG_DIR`):** every run the C# runners start (the preflight `Query.YOLOEnvironmentResult`, `Modify.Predict`, and the training of #16) sets `YOLO_CONFIG_DIR` to a `.yolo-config` folder inside its working directory, so the settings file the run reads and writes lives in that working directory and is never the shared machine-wide one. The venv is isolated the same way for interactive use by its own activation scripts - `Scripts/activate`, `Scripts/Activate.ps1` and `Scripts/activate.bat` set `YOLO_CONFIG_DIR` to a `.yolo-config` folder inside the venv and restore the previous value on deactivate. The venv is git-ignored, so that part is a machine-local setup; the three lines to add are:
  ```bash
  export YOLO_CONFIG_DIR="$VIRTUAL_ENV/.yolo-config"                 # Scripts/activate
  $env:YOLO_CONFIG_DIR = Join-Path $env:VIRTUAL_ENV ".yolo-config"   # Scripts/Activate.ps1
  set "YOLO_CONFIG_DIR=%VIRTUAL_ENV%\.yolo-config"                   # Scripts/activate.bat
  ```
  The two versions write different paths under one directory - 8.3.130 writes `<dir>\settings.json`, 8.4.165 writes `<dir>\Ultralytics\settings.json` - which is why one working directory can host both; if a future ultralytics changes that layout, the isolation breaks, and the `YOLOEnvironmentResult_SettingsIsolation` test in `DiGi.YOLO.xUnit` pins both paths. The first run in a fresh working directory still prints the one-time `Creating new Ultralytics Settings` notice; afterwards the runs are quiet.
* **`check.py` stdout contract:** the JSON payload sits between the `YOLO_CHECK_JSON_BEGIN` and `YOLO_CHECK_JSON_END` marker lines; everything else on stdout - the ultralytics banner and settings notices included - is noise a caller must not parse.

### Running a Prediction from C#
`Modify.Predict` runs `predict.py` in a CPython process and reports the run. `DiGi.Scripting.Python` is IronPython and cannot host `ultralytics`/`torch`, so it is not an alternative.

```csharp
YOLOPredictionOptions? yOLOPredictionOptions = Create.YOLOPredictionOptions(null, pathWeights, directorySourceImages, pathBoundingBoxResultFile);

YOLOPredictionResult? yOLOPredictionResult = yOLOPredictionOptions.Predict(cancellationToken);

BoundingBoxResultFile? boundingBoxResultFile = Create.BoundingBoxResultFile(yOLOPredictionResult);
```

* `Create.YOLOPredictionOptions(...)` resolves the interpreter (a `null` path searches `PATH` for `python`, then `python3`), normalises the paths and returns `null` when the combination cannot make a run.
* The runner writes the scripts into the working directory when they are missing, removes a stale `.bbrf` so a failed run cannot be read as this one, and answers a source directory holding no images without starting a process.
* `YOLOPredictionResult` carries the exit code, the tail of both output streams, the image count and the run's `DateTimeOffset` bounds. `Create.BoundingBoxResultFile(result)` gives `null` for a run that did not complete.
* Cancelling kills the interpreter only - `netstandard2.0` has no process-tree kill, so torch worker processes can outlive it.

### Training a Detector from C#
`Modify.Train` runs `train.py` and `Modify.Validate` runs `val.py`, the same way `Modify.Predict` runs `predict.py` ([#16](https://github.com/DiGi-Organization/DiGi.YOLO/issues/16)). A dataset is written with `Modify.Write(YOLOModel)`, whose `conf.yaml` carries an absolute `path:` and the labels.

```csharp
YOLOTrainingOptions? yOLOTrainingOptions = Create.YOLOTrainingOptions(null, pathStartWeights, pathConfigurationFile);
yOLOTrainingOptions!.Name = "train9_fresh";

YOLOTrainingResult? yOLOTrainingResult = yOLOTrainingOptions.Train(cancellationToken);

YOLOValidationOptions? yOLOValidationOptions = Create.YOLOValidationOptions(null, yOLOTrainingResult?.WeightsPath, pathConfigurationFile);
YOLOValidationResult? yOLOValidationResult = yOLOValidationOptions.Validate(cancellationToken);
```

| `train.py` argument | Default | `YOLOTrainingOptions` |
|---|---|---|
| `--model` | `YOLO/models/model.pt` | `ModelPath` - start weights, a local file: a `.pt` checkpoint (`model.pt` to continue the shipped detector, or `base/yolo26x.pt` for a fresh start) or a `.yaml` architecture definition. Nothing is downloaded by name |
| `--data` | `conf.yaml` | `ConfigurationFilePath` - always passed absolute |
| `--epochs` / `--patience` | `150` / `50` | `Epochs` / `Patience` - upper bound and early stopping |
| `--imgsz` / `--batch` / `--seed` | `640` / `16` / `0` | `ImageSize` / `Batch` / `Seed` - `train8`'s values |
| `--project` / `--name` | ultralytics defaults | `Project` (always passed, `<working>\runs\detect` by default) / `Name` |
| `--device` | ultralytics default | `Device` |
| `--amp` / `--no-amp` | on | `Amp` |

* **Start weights** are identified by the runner before the process starts - path, SHA-256 and kind (`checkpoint` / `definition`) on `YOLOTrainingResult` - because the output streams keep only their tail. `train.py` also prints them, and a checkpoint's `train_args` (for `train8` the only surviving record of its settings).
* **Output weights** are read from the block `train.py` prints last (`Weights:`, `Bytes:`, `SHA256:`, `AMP:`) and confirmed against the file on disk; `Succeeded` requires the match.
* **Never into `YOLO/models`:** a run whose project folder lies inside a `YOLO\models` folder is refused, and ultralytics numbers a taken run name rather than reusing its directory, so no run replaces the frozen `model.pt`.
* **Preflight and isolation:** a checkpoint is preflighted with `Query.YOLOEnvironmentResult` (an ultralytics too old for the checkpoint is refused), and the run gets its own `YOLO_CONFIG_DIR`. The scripts are rewritten before every run, so a directory never trains with a `train.py` of an older build.
* **Stall detection ([#22](https://github.com/DiGi-Organization/DiGi.YOLO/issues/22)):** a training that stops producing output for `YOLOTrainingOptions.InactivityTimeout` (default 15 minutes, `null` or non-positive to disable) is ended together with the worker processes it started - a deadlocked run leaves every process alive at 0 % CPU holding the GPU - and reported through `YOLOTrainingResult.Stalled` with the reason in the standard-error tail, distinct from a cancellation and from a crash. A piped training writes a progress line per batch during every phase, so 15 minutes is a large margin over the sub-second cadence of a healthy run. Cancelling a run ends the whole process tree as well.
* **Downloads at train time:** ultralytics' AMP check downloads `yolo26n.pt` into the `weights` folder of the working directory and, offline, silently trains in full precision - `YOLOTrainingResult.Amp` reports the precision actually used. It also downloads `Arial.ttf` into the settings directory. Neither changes the start weights.
* **YOLO26 loss columns:** a YOLO26 run has no `dfl_loss` in its `results.csv`; nothing here reads it.
* **Validation:** `val.py --split val|test` (default `test`) prints `mAP50:` and `mAP50-95:`; `YOLOValidationResult` carries both with the SHA-256 of the weights it measured, so a gate table names exactly which file each row is.

#### Resuming an interrupted run
A run stopped mid-epoch (a power cut, a killed interpreter, a closed console) leaves an unfinished `<project>\<name>\weights\last.pt` that still carries its optimizer and EMA state. `Modify.Train` continues it when `YOLOTrainingOptions.ResumePath` names that file ([#21](https://github.com/DiGi-Organization/DiGi.YOLO/issues/21)):

```csharp
YOLOTrainingOptions yOLOTrainingOptions = new()
{
    PythonPath = pathPython,
    ResumePath = Path.Combine(pathProject, "train9", "weights", "last.pt"),
    Device = "0",
    WorkingDirectory = pathDatasetDirectory
};

YOLOTrainingResult? yOLOTrainingResult = yOLOTrainingOptions.Train(cancellationToken);
```

```powershell
python train.py --resume "C:\YOLO\runs\detect\train9\weights\last.pt" --device 0
```

* **What is resumable:** a checkpoint ultralytics left unfinished. It stores `epoch >= 0` and an optimizer state right up to the last epoch; a finished run's `last.pt` is stripped to `epoch = -1` with no optimizer, and nothing can be resumed from it. `Query.YOLOCheckpointInformation(path)` reads either - the 1-based completed `Epoch`, the `Epochs` ceiling, `Finished`, `DataPath`, `Project`, `Name` and the raw `TrainArguments` - with `checkpoint.py` and no ultralytics.
* **What a resume may change:** `train.py` passes **only** `--resume` and `--device`. Ultralytics restores every other argument from the checkpoint's `train_args`; its `check_resume` accepts a handful of overrides (`imgsz`, `batch`, `device`, `patience`, `close_mosaic`, ...), ignores the rest with a warning, and would **silently start a fresh run** if handed a finished checkpoint - so the guard that refuses one is in `train.py`, not delegated to ultralytics. The epoch ceiling is fixed by the checkpoint: a different ceiling is a new run, not a resume.
* **Refusals before launch:** `Modify.Train` refuses, naming the reason and starting no process, a resume path that is missing or not a `.pt`, a finished checkpoint, a checkpoint whose `train_args.data` no longer exists, and a run folder inside a `YOLO\models` folder.
* **Not bit-identical:** a resumed run restarts the data loader's random state, so it is not byte-for-byte the uninterrupted run. `YOLOTrainingResult.Resumed` is `true` and `ResumedFromEpoch` names the 1-based epoch it entered (a checkpoint with one completed epoch resumes into epoch 2), so a provenance table can say so.
* **An interruption costs up to one full epoch:** `last.pt` is written only after the epoch's validation, so a run cut mid-epoch (a stall ended by the inactivity limit, a crash, a power cut) resumes at the start of that epoch and trains it in full again.
* **Launched by hand:** a console-launched run aborts if its console window is closed (`forrtl: error (200): program aborting due to window-CLOSE event` - the Intel Fortran runtime numpy/torch load). Start it with `pythonw`, or keep the console open. A hand-written wrapper must keep `train.py`'s `if __name__ == "__main__":` guard, because Windows data loader workers re-import the main module. Runs started by `Modify.Train` have no console to close.

---

## 📐 Core Architectural Pattern (DiGi.Core Pattern)

This project strictly separates **Data Models** (anemic schemas) from **Business/Calculation Logic** (static extension methods). All new features must strictly follow this pattern.

```mermaid
graph TD
    subgraph "Data Models (Anemic)"
        C[Classes]
        I[Interfaces]
        E[Enums]
    end
    subgraph "Business Logic (Static Extensions)"
        Q[Query Class]
        M[Modify Class]
        Cr[Create Class]
    end
    C -->|Query / Read| Q
    C -->|Modify / Mutate| M
    C -->|Create / Instantiate| Cr
```

### 1. Data Models (Classes, Interfaces, Enums)
* **Classes:** Place in the `/Classes` directory (Namespace: `[Project].Classes`). Keep them simple and lightweight (properties and basic constructors only). **Do NOT** put complex logic inside these classes.
* **Interfaces:** Place in the `/Interfaces` directory (Namespace: `[Project].Interfaces`).
* **Enums:** Place in the `/Enums` directory (Namespace: `[Project].Enums`).

### 2. Business Logic (Extension Methods)
ALL complex functionalities, including operations on classes, interfaces, and enums, MUST be implemented as **Extension Methods** inside static partial classes in `/Query`, `/Modify`, `/Create`, or `/Convert` directories:
* **Query (Read/Extract):** Static partial class `Query` returning results based on a query without modifying the source object.
* **Modify (Update/Mutate):** Static partial class `Modify` modifying the state or properties of the existing object in place.
* **Create (Instantiate):** Static partial class `Create` instantiating and returning a new object.
* **Convert (Parse/Format/Transform):** Static partial class `Convert` converting, formatting, or transforming an object into another representation.

---

## 💻 Coding Guidelines for Developers & AI Agents

To maintain codebase health, performance, and compatibility within Visual Studio 2026 / C# 10+ environments, all developers and AI agents must strictly comply with these guidelines.

### 1. General Coding Standards
1. **English only** — identifiers and comments.
2. **Explicit typing — no `var`** (unless the compiler forces it, e.g. anonymous types). Use target-typed `new(...)` when the type is declared (avoids IDE0090): `PointNode pointNode = new();`. Use collection expressions `[]` for collections (avoids IDE0028): `List<int> numbers = [];`, `int[] array = [1, 2, 3];`.
3. **Variable naming:** start with the type name in camelCase, adding a `_`-suffixed qualifier when needed (`PointNode pointNode_Base`, `pointNode_Temp`).
   - **Collections:** don't prefix with the collection type — use the element type pluralized (`FilterConditions`, not `Conditions`/`listConditions`; `FilterGroups`, not `Groups`/`listGroups`).
   - **Property matching its value type:** if a value type is fully descriptive and unique in the class, name the property after the type (`public AggregateFunction AggregateFunction { get; set; }`).
   - **Primitives** may use plain camelCase (`double tolerance`, `string name`, `int count`).
4. **Zero warnings/analyzer messages** — nullability, parameter validation, clean code.
5. **C# 10+ / C# 13/14** (`LangVersion` ≥ 10) — modern features (enhanced pattern matching, target-typed `new`, collection expressions, `System.Threading.Lock`, etc.) are fine within these architectural constraints. **Namespaces must be block-scoped** (as in every example below); file-scoped namespaces are disallowed and enforced via `.editorconfig` (`csharp_style_namespace_declarations = block_scoped`). See `Coding - Editor Config.md` for the unified baseline rules.
6. **Parameter Line Breaks (`<= 7` Rule):** If a method, constructor, or delegate declaration has 7 or fewer parameters, keep them on a single line however long the line becomes. Multi-line parameter lists are reserved for 8 or more parameters (strictly one parameter per line, enforced via `DIGI0001`). Call sites prefer single-line but allow multi-line formatting when arguments are complex expressions, lambdas, or object initializers.
   - **Correct (<= 7 parameters):**
     ```csharp
     public void Calculate(double centerX, double centerY, double radius, double? storeyHeight = null)
     {
     }
     ```
   - **Incorrect (<= 7 parameters):**
     ```csharp
     public void Calculate(
         double centerX,
         double centerY,
         double radius,
         double? storeyHeight = null)
     {
     }
     ```
   - **Correct (>= 8 parameters, one per line):**
     ```csharp
     public void Calculate(
         double centerX,
         double centerY,
         double radius,
         double? storeyHeight,
         double wallThickness,
         double slabThickness,
         string materialName,
         CancellationToken cancellationToken = default)
     {
     }
     ```
7. **Async method naming:** All asynchronous method names must end with `Async`.
   - **Example:**
     ```csharp
     public async Task<IActionResult> GetDetailsByReferenceAsync([FromQuery(Name = "reference")] string? reference)
     ```
8. **`CancellationToken` is always the LAST parameter (CA1068).** This holds for every method — public, private, static, extension, local — and for every overload. When adding a new optional parameter to an existing signature, insert it *before* the token; never append after it.
   - **Correct:**
     ```csharp
     public static async Task<bool> ClearAsync(NpgsqlConnection? npgsqlConnection, string tableName, int commandTimeout = 30, CancellationToken cancellationToken = default)
     ```
   - **Incorrect** — appending after the token is the usual way this rule gets broken:
     ```csharp
     public static async Task<bool> ClearAsync(NpgsqlConnection? npgsqlConnection, string tableName, CancellationToken cancellationToken = default, int commandTimeout = 30)
     ```
   - The `<param>` tags in the XML doc block must be reordered to match, so the docs still mirror the signature exactly.
   - **Pass the token by name at call sites** — `cancellationToken: cancellationToken` — whenever intervening parameters are left at their defaults. Positional calls silently rebind if the signature is ever reordered again; named arguments turn a reordering into a compile error rather than a wrong-argument bug.
   - **Detection:** `grep -rnE "CancellationToken [a-zA-Z_]+( = default)?, " --include=*.cs .` — every hit that is not the final parameter is a violation.
9. **Simplify member access (IDE0002/IDE0001) — but verify the binding first.** Inside the `DiGi` root, drop any namespace qualifier the compiler does not need; a `DiGi.` prefix on a type that already resolves is redundant noise.
   - **Correct** — in `namespace DiGi.GIS.PostgreSQL.UI.Classes`, `Serilog` resolves up the enclosing chain to `DiGi.Serilog`:
     ```csharp
     Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Import failed");
     ```
   - **The exception — innermost-namespace shadowing.** C# resolves the FIRST segment against each enclosing namespace from innermost outwards, and once it binds there is **no fallback**. From `DiGi.GIS.PostgreSQL.UI.Classes`, `WebAPI` binds to `DiGi.GIS.WebAPI` (not `DiGi.WebAPI`), so the qualifier must stay:
     ```csharp
     postResponse = await DiGi.WebAPI.Query.GetAsync<Building>(httpClient, requestUri, postOptions);
     ```
     The same trap applies to `Core`, `Geometry`, `Analytical` and any other segment that repeats at several depths.
   - **Method:** remove the qualifier, then **rebuild**. A shadowed name usually fails with CS0234/CS0246 — restore the prefix and leave a short comment saying why. Never shorten a qualifier you have not compiled. If BOTH namespaces expose a matching member, the shortened form compiles and silently calls the wrong one — keep the qualifier regardless of the analyzer suggestion.
10. **Project Structure:** Assume the C# codebase consists of multiple SEPARATE projects, not a single monolithic solution. Handle namespaces and references accordingly.
11. **Output Optimization:** Prioritize highest code quality and output token minimization. Skip conversational filler, polite introductions, and conclusions. Output only the necessary code, logic, or requested explanations.
12. **Temporary code markers:** code that exists only until a migration completes is tagged `TODO [MarkerName]:` at every site, where `MarkerName` is PascalCase and names the migration rather than the issue (`[ReferenceFormat]`, `[ReferencedObjectIndexes]`) — one tag reused everywhere, so `grep -rn "MarkerName"` returns the whole deletion checklist.
   - Every marker states its **removal condition**: the observable fact that makes deletion safe ("once every deployed database has run this DDL at least once"), not just that the code is temporary. Name the tracking issue when there is one.
   - Inline comment at the site; file header above the `using` block when the whole file is temporary (`DiGi.Core/Query/TryParseLegacy.cs`); `[TEMPORARY]` as the first token of the XML `<summary>` when removing a whole public member would be a public-API change (`DiGi.GIS.WebAPI.UI/Controllers/SolarController.cs`).
   - Mark only what is actually temporary — permanent code shipped alongside it must not carry the tag.
13. **`ToString()` is not a key.** `Range<T>.ToString()` and `$"[{min}, {max}]"` follow `CurrentCulture`, so a dictionary keyed on them files `[0,5, 12,25]` under pl-PL and nothing throws. Anything used as an identity - a dictionary key, a stored reference, a hash input - renders through `CultureInfo.InvariantCulture` (`"R"` for floating point with `-0.0` folded, `G29` for decimal, ticks for `DateTime`); `DiGi.Typology.Visual.Query.Key` is the reference renderer and its fact re-runs the assertions under `pl-PL`. An `object`-typed value comes back from a JSON reload as `double`, so such a key must also be width-agnostic.
14. **A member resolved by name through reflection is a contract on the whole hierarchy.** `Typology.Query.RuleData` calls `GetMethod(nameof(RuleData))`, which silently forbids any derived rule from hiding `RuleData` with `new`. Document such a lookup at the reflection site and on the base type, prefer a non-generic interface member while the design is open, and probe `GetMethod` behaviour with a scratch app rather than reasoning about it.
15. **No caching in an optimization unless the request explicitly allows it.** No static `Dictionary`/`ConcurrentDictionary`, memoized reflection or cached `MethodInfo`/`Type` lookups: a cache adds static mutable state, thread-safety obligations and unbounded memory to a library every host loads (the `DiGi.Core` caches in `Description`, `Serialize`, `Value` and `Clone` were all rolled back). Remove allocations, avoid repeated enumeration, build a one-pass `HashSet`/`Dictionary`; if a cache really is the fix, propose it with the measurement and ask first.

---

### 2. Architecture & Project Structure (DiGi.Core Pattern)
Data models are strictly separated from business logic (anemic models + static extension methods). Follow this structure for all new features.

**Data models:**
- **Classes** → `/Classes`, ns `[Project].Classes` — lightweight (properties + basic constructors only), **no** complex logic.
- **Interfaces** → `/Interfaces`, ns `[Project].Interfaces`.
- **Enums** → `/Enums`, ns `[Project].Enums`.

**Business logic** — all complex behavior is an extension method in one of static partial classes; never create a manager/service class:
- **`Query`** (`/Query`) — returns a result from a query; does NOT modify the source (e.g. translating dynamic filter groups into SQL/parameterized commands).
- **`Modify`** (`/Modify`) — modifies the state/properties of the existing object.
- **`Create`** (`/Create`) — creates and returns a completely new object from input data.
- **`Convert`** (`/Convert`, subdirs `/Convert/To[TargetArea]` e.g. `/Convert/ToSystem`, `/Convert/ToEPW`, `/Convert/ToDiGi`) — converts/formats/transforms an object or raw components into another representation; method names follow `To[TargetArea]_[TargetType]` (`ToSystem_String`, `ToSystem_DateTime`, `ToEPW_DateTime`).

### Exception — interface-contract members are implemented ON the class
The anemic-model + static-extension rule governs behavior that is **not** part of an interface the `/Classes` type implements. When a method is declared on an interface the class implements, it MUST be a normal **instance method on that class** — C# offers no other way to satisfy the contract, and moving it to a `Query`/`Modify` extension leaves the interface unimplemented (CS0535).

This is the deliberate design for **behavior-rich geometry primitives**. `DiGi.Geometry`'s `Ellipse2D`, `Circle2D`, `Segment2D`, `Polygon2D`, `Rectangle2D`, their spatial counterparts, etc. implement rich behavioral interfaces and therefore carry their behavior as instance methods — for example `IBoundable2D.GetBoundingBox()`, `ITransformable2D.Transform(...)`, `IMovable2D.Move(...)`, and `IClosedCurve2D.{GetInternalPoint, InRange, Inside, GetArea}`. These types are **not** anemic, and that is correct.

- **Do not "migrate" a geometry primitive's instance methods to `Query`/`Modify` extensions, and do not flag them as anemic-model violations.** Deleting a contract implementation breaks the interface and diverges from the entire library.
- **Before proposing to move or remove such a method, check the interface chain first** (the `I*2D` hierarchy under `Planar/Interfaces` / `Spatial/Interfaces`). Only behavior that is genuinely not a contract member — and that belongs to a data model rather than a geometry primitive — goes into the static partial classes.
- **Private helpers are allowed on such a class.** The "strictly avoid private methods" rule below is scoped to the static partial utility classes (`Query`/`Modify`/`Create`/`Convert`), not to `/Classes` types that implement behavioral interfaces.

### Constructors stay cheap — the work belongs in a `Create` factory
**A constructor on a `/Classes` type assigns and clones. Nothing else.** No validation sweep, no normalisation, no cleanup pass, no geometric or numeric computation — not even an `O(n)` scan over a collection the caller just handed over. A constructor sits on the hot path of every clone, every copy constructor and every deserialization, and a caller who already holds clean data must not pay for a check it does not need.

- **Any such work goes into a `Create` factory** named after the type it returns, at `/Create/[TypeName].cs`. The factory does the work, then calls the plain constructor. It returns the type as **nullable** and returns `null` when the input cannot make a valid object — the guard is a return value, not an exception.
- **Order inside the factory:** materialise and filter the input → run the cleanup → *then* check the result is still valid. Validating before the cleanup measures the wrong thing: a ring of three positions that repeats a corner passes a "three or more" check and then becomes a two-corner polygon.
- **Document the split on both sides.** The constructor's `<summary>` points at the factory for callers whose data is not already clean; the factory's `<summary>` says what it removes and why the constructor does not.

Reference: `DiGi.Geometry.Planar.Create.Polygon2D(IEnumerable<Point2D?>?, double)` and `DiGi.Geometry.Spatial.Create.Polygon3D(IEnumerable<Point3D?>?, double)` both drop points repeating their predecessor via `Modify.RemoveDuplicates(..., closed, tolerance)` *before* checking the corner count, while `Polygon2D`'s constructors store whatever they are given.

```csharp
// /Classes — plain assignment, no work
public Polygon2D(IEnumerable<Point2D>? point2Ds)
    : base(point2Ds)
{
}

// /Create — the work lives here, and the guard runs after it
public static Polygon2D? Polygon2D(this IEnumerable<Point2D?>? point2Ds, double tolerance = DiGi.Core.Constants.Tolerance.Distance)
{
    if (point2Ds == null)
    {
        return null;
    }

    List<Point2D> point2Ds_Temp = [];
    foreach (Point2D? point2D in point2Ds)
    {
        if (point2D != null)
        {
            point2Ds_Temp.Add(point2D);
        }
    }

    point2Ds_Temp.RemoveDuplicates(true, tolerance);

    if (point2Ds_Temp.Count < 3)
    {
        return null;
    }

    return new Polygon2D(point2Ds_Temp);
}
```

### File organisation — one member per file
- **`Query`/`Modify`/`Create` hold exactly one public method per file, and the file is named after that method** (`/Spatial/Query/NearestIndexes.cs` holds `NearestIndexes`). Do **not** group related methods into one file — `TryGetNearestIndexes`, `NearestIndexes` and `NearestNeighbors` are three files, not one.
  - **Overloads are the same method and stay together.** Every `Triangle3D(...)` overload lives in `Triangle3D.cs`; the plural `Triangle3Ds(...)` is a different method name and gets `Triangle3Ds.cs`.
  - A helper promoted to `public static` under the encapsulation rule below gets its own file too, named after the helper.
  - **`Convert` is the exception** and keeps its file-per-TARGET-type layout, `/Convert/To[TargetArea]/[TargetType].cs`.
- **Nested types get their own file, `[Outer].[Inner].cs`**, beside the outer type's file, carrying only the nested type and declaring the outer type `partial` — `/Spatial/Classes/PointCloud3D.Point.cs` and `/Spatial/Classes/PointCloud3D.Enumerator.cs` sit next to `/Spatial/Classes/PointCloud3D.cs`. Keep the type nested; promoting it to top level changes the public API and the bare name rarely stands alone (`Point`, `Enumerator`). The repeated outer `partial` declaration carries no XML `<summary>`, per the "do not document `partial` class declarations" rule.

### Method Encapsulation and Reusability in Utility Classes
- **Strictly avoid creating private methods** within `Query`, `Convert`, `Modify`, and similar partial utility classes.
- If a helper method has well-defined inputs, no side effects, and high reusability, implement it as a **public static method** within the appropriate partial class (e.g., `Query`, `Convert`, `Modify`).
- If a helper method is strictly single-use or specific to a narrow scope, implement it as a **local function (inline method)** directly inside the method you are currently implementing.

### Convert Class Pattern (conversion methods)
`public static partial class Convert` is the **first choice** for any method that transforms an object into another representation — including performance-oriented variants that avoid defensive cloning. Never implement a conversion as an instance method on a `/Classes` model; model classes stay anemic.

The pattern, as established across the `Convert` folders (reference: `DiGi.Geometry/Planar/Convert`):

- **Folder/file layout:** `/Convert/To[TargetArea]/[TargetType].cs` — one file per TARGET type, named after the target type; all source-type overloads converting to that target live in that file (e.g. `ToNTS/LinearRing.cs`, `ToDiGi/Polygon2D.cs`, `ToNTS/Coordinates.cs`).
- **Method shape:** `public static` **extension method on the SOURCE type**; reference-type parameters are nullable; return `null` for null/invalid input instead of throwing.
- **Naming:** plain `To[TargetArea](...)` when the source type has a single natural target in that area — the target is then distinguished by the source overload (`ToNTS(this Point2D?)` → `Coordinate`, `ToNTS(this Segment2D?)` → `LineSegment`, `ToNTS(this IPolygonal2D?)` → `LinearRing`). Use the suffixed form `To[TargetArea]_[TargetType](...)` when the same source converts to several targets in one area (`ToNTS_LineString(this Segment2D?)` and `ToNTS_Polygon(this IPolygonal2D?)` beside the plain overloads above; `ToDiGi_Polygon2Ds(this Polygon?)` beside `ToDiGi(this Polygon?)` → `PolygonalFace2D`).
- **Non-cloning access for a conversion:** add a **public** opt-out overload of the model's existing getter — `Segmentable2D.GetPoints(bool clone)`, whose `<summary>` says the caller must not mutate the list it returns for `clone: false` — and consume that from `Convert`. Never an `internal` accessor.

### Naming Conventions for Query Partial Class
- Enforce a property-like naming convention for methods inside the `Query` class.
- **Do not use verbs as prefixes** (e.g., avoid `Get`, `Find`, `Calculate`).
  - *Example:* `GetBoundingBox()` must be named `BoundingBox()`.
- **Exceptions:** Verbs indicating boolean checks or safe-retrieval patterns are required. Allowed prefixes are `Is`, `Has`, and `Try`.
  - *Examples:* `IsPlanar()`, `HasMaterial()`, `TryConvert()`.

## Project assets — `files/` vs `user files/` (NEVER commit secrets)
Runtime assets a project copies to its output belong in one of two solution-root folders, chosen by
sensitivity. **Secrets, credentials and machine-specific configuration MUST go in `user files/`,
never in `files/`.** Both are copied to the build output by a `.csproj` target; the difference is git.

- **`files/`** — committed to source control. Non-sensitive, environment-agnostic deployment assets
  shared by everyone (e.g. `web.config`, `app_offline.htm.bak`). Copied by a `CopyFiles` target:
  ```xml
  <Target Name="CopyFiles" AfterTargets="Build">
    <ItemGroup>
      <_Files Include="$(ProjectDir)..\files\**\*.*" />
    </ItemGroup>
    <Copy SourceFiles="@(_Files)" DestinationFiles="@(_Files->'$(OutputPath)%(RecursiveDir)%(Filename)%(Extension)')" SkipUnchangedFiles="true" />
  </Target>
  ```
- **`user files/`** — git-**ignored**. Fragile / user-specific / secret data: database connection
  configs (`*.conf` with host/user/password), API keys, local paths, per-machine settings. Copied by
  a `CopyUserFiles` target specifying `AfterTargets="CopyFiles"` so user files overwrite any duplicates
  copied by `CopyFiles`:
  ```xml
  <Target Name="CopyUserFiles" AfterTargets="CopyFiles">
    <ItemGroup>
      <_UserFiles Include="$(ProjectDir)..\user files\**\*.*" />
    </ItemGroup>
    <Copy SourceFiles="@(_UserFiles)" DestinationFiles="@(_UserFiles->'$(OutputPath)%(RecursiveDir)%(Filename)%(Extension)')" SkipUnchangedFiles="true" />
  </Target>
  ```
  - **Generated output also belongs here.** Test reports, diagnostic dumps, benchmark logs and text
    logs written during a run go to `user files/reports/` — never to `files/`. In tests, resolve the
    folder with `assembly.ReportsDirectory()` rather than a hardcoded path (see §7).
  - **`user files/` ships with the build.** `CopyUserFiles` flattens it into `bin` and `Deploy.ps1`
    carries `bin` to the hosts, so it holds only what the deployed tool reads at runtime. Training inputs
    (alternative weights, base weights, reference tables, training options and reports) live in a training
    directory outside the workspace; the Year Built runner extension deploys from an allowlist, of `YOLO`
    only `model.pt` (`Coding - YOLO.md` §3, §5).

**Overriding Rule:** In case of duplicate relative file paths between `files/` and `user files/`, assets from `user files/` MUST ALWAYS take precedence and override assets from `files/`. Specifying `AfterTargets="CopyFiles"` ensures `CopyUserFiles` runs strictly after `CopyFiles` to overwrite any duplicates.

**Enforcement:** the solution-root `.gitignore` must contain the case-insensitive rule
`[Uu]ser [Ff]iles/`. Verify with `git check-ignore -v "user files/<file>"` — git must report the rule
as the reason the file is ignored. If a new solution needs runtime secrets and lacks this rule, add
it before dropping any secret in. Reference implementations: `DiGi.GIS.PostgreSQL.UI`,
`DiGi.GIS.PostgreSQL.WebAPI` (both hold `GIS_PostgreSQL_Main.conf` in an ignored `user files/`).

**Decision rule when placing a runtime asset:** would committing it leak a secret, or break another
developer's / the server's machine-specific setup? If yes → `user files/`; otherwise → `files/`.

- **Script configurations (PowerShell)**: PowerShell scripts requiring machine-specific, secret, or environment-specific paths (e.g., local backup paths or cloud storage directories) must load these settings from a `.conf` file inside the `user files/` directory, rather than hardcoding them in the scripts or introducing custom `.gitignore` records.

## Host dependencies — `HintPath` drops a library's NuGet packages

DiGi projects reference each other with `<Reference><HintPath>..\..\X\bin\X.dll</HintPath>`, never
`<ProjectReference>`. A raw assembly reference is **opaque to NuGet**, and the DiGi class libraries do
not copy their own NuGet dependencies into their `bin` — so a library's third-party dependencies never
reach a host that consumes it by `HintPath`.

> **When a `HintPath`-referenced library needs a NuGet package, re-declare that `PackageReference` on
> the deployed host (the `Exe` / `WinExe` / `Microsoft.NET.Sdk.Web` project) at the identical version.**

- The chain runs deeper than the direct reference: `DiGi.Geometry` → `DiGi.Math` → `MathNet.Numerics`.
  Audit the whole closure, not just the assemblies listed in the `.csproj`.
- Do **NOT** use `CopyLocalLockFileAssemblies=true` on the netstandard2.0 library — it bloats its `bin`
  with `System.*` 4.3.0 shims.
- `<ProjectReference>` consumers (siblings, `.xUnit`, `.Rhino`) are unaffected; NuGet flows normally.

**The failure signature is a partial result, not an error.** `FileNotFoundException` is thrown per item
deep inside a loop, so a batch run completes and reports success while silently delivering less than it
should — one county produced models for 65 % of 33 687 buildings and reported success. A green build and
a green test suite prove nothing, because the `.xUnit` projects re-declare these packages themselves.
**When a run completes but delivers less than it should, check the host's output directory for missing
assemblies before investigating the data.**

**Extension hosts are one probing set.** `DiGi.GIS.WebAPI`, `DiGi.GLTF.WebAPI`, `DiGi.Communication.WebAPI`
and `DiGi.User.WebAPI` deploy into `DiGi.WebAPI.WindowsService\bin\extensions\<name>` and are loaded into
`AssemblyLoadContext.Default` with cross-directory `AssemblyDependencyResolver`s. Audit the host output
**together with** its `extensions\*` folders, and declare a shared dependency once on
`DiGi.WebAPI.WindowsService` — that is already how `Microsoft.OpenApi` and `Serilog` reach the extensions.

Verify after building — both read compiled output, not project files:
```powershell
PowerShell -ExecutionPolicy Bypass -File ".\CheckHostDependencies.ps1"
```
```powershell
PowerShell -NoProfile -ExecutionPolicy Bypass -File ".\BuildAll.ps1" -Configuration Release -CheckDependencies
```
Each deployment unit declares its reviewed exceptions inside `CheckHostDependencies.ps1`, every one with a
stated reason — an unexplained entry there re-hides the exact class of bug the script exists to find.

---

### 3. Reference Comparison (`IReference` / `IUniqueReference`)

> **Never compare two interface-typed references with `==` or `!=`. Use `Core.Query.Equals(reference_1, reference_2)`.**

This is not a style preference. `==` between two interface-typed operands compiles to **reference equality**, silently returns `false` for two equal references, and the compiler emits no warning. It has already produced an infinite loop in `BuildingModelShellUpdater` and mis-attributed geometry in `ShellByPlaneSplitSolver`.

**Why the operators do not apply.** For `a == b`, C# gathers user-defined operator candidates from the **static types of the operands and their base classes** — an interface contributes none. The `==`/`!=` operators live on `SerializableReference`, so the comparison is correct as soon as **one** side is a concrete `SerializableReference`-derived type (or the `null` literal).

| Static type of the operands | What `==` compiles to | Verdict |
|---|---|---|
| both interfaces (`IReference`, `IUniqueReference`, `ISerializableReference`, …) | predefined reference equality | **silent bug** |
| at least one `SerializableReference`-derived (`GuidReference`, `TypeReference`, …) | `SerializableReference.operator ==` → `Equals` | correct |
| one side is the `null` literal | null check | correct |
| `.ToString()` on both sides | string comparison | correct, but allocates |

This cannot be fixed by adding operators: interfaces contribute no operator candidates, a `operator ==(IReference, IReference)` declared in a helper class is **CS0563**, and C# 11 static abstract interface operators dispatch only through a constrained generic type parameter (and require net7.0+, while `DiGi.Core` targets `netstandard2.0`).

**The compounding trap — clone-per-call accessors.** Many model properties return `Core.Query.Clone(field)` and therefore hand back a **new instance on every read**, so `face.UniqueReference == face.UniqueReference` is `false` — the same face compared with itself. Read the property into a local before using it; never call it inside a predicate that runs per element (it is also an allocation per iteration).

| Intent | Use |
|---|---|
| Are these two references the same reference? | `Core.Query.Equals(reference_1, reference_2)` (null-safe, two nulls are equal) |
| Look up / group / de-duplicate | `Dictionary`, `HashSet`, `List.Find`/`FindAll`/`FindIndex`/`Contains` — already correct, they route through `Equals`/`GetHashCode` |
| I need the concrete API | pattern-match: `if (uniqueReference is GuidReference guidReference)` |
| Is this the same *instance* of a model object? | compare its `Guid` — a reference identifies the referenced object, not the object holding it |

```csharp
// WRONG - both operands are IUniqueReference, this is reference equality and never matches
int index = faces.FindIndex(x => x.UniqueReference == face.UniqueReference);
```

```csharp
// CORRECT - hoist the clone-returning accessor into a local, then compare by value
IUniqueReference? uniqueReference = face.UniqueReference;

int index = faces.FindIndex(x => Core.Query.Equals(x?.UniqueReference, uniqueReference));
```

**Do not assume an `IReference` is a `SerializableReference` — never cast to it.** `ListClusterReference<TKey_1, TKey_2>` implements `IReference` directly, and `IUniqueReference` has two class branches (`UniqueReference` and `UniqueExternalReference<T>`) with no common base below `SerializableReference`.

---

### 4. XML Documentation Standards
All public constructors, properties, methods, and enum values must be fully documented using XML comments:
* **Code preservation & sync:** Edit only `///` comments — never change C# logic. Add missing tags, and rewrite any existing comment that is outdated, inaccurate, or describes logic/parameters that no longer exist.
* **Explicit typing:** No `var` in any code snippet you touch.
* **Partial classes:** Don't document the class declaration itself when marked `partial`; document only its members.
* **Exhaustive coverage:** Every public member must have an accurate, up-to-date description.
* **Quality over speed** — prioritize accuracy and alignment with the code's actual behavior.
* **Reference context:** For each referenced library, ingest its sibling XML doc file (`LibraryName.dll` → `LibraryName.xml`, same directory) for accurate cross-referencing, terminology, and external type/parameter descriptions.
* **Signature matching:** Docs must match signatures exactly — remove `<param>` tags for parameters that no longer exist, add tags for new ones. Document all `<param>`, `<returns>`, and `<typeparam>` to avoid CS1591/CS1573.
* **Single summary:** Exactly one `<summary>` per element. When updating, overwrite the old one — never append. Do a final pass to strip any redundant tags.
* **No empty lines** inside doc blocks (no blank line or bare `///`) — they break Visual Studio IntelliSense tooltip rendering. Use `<para>` for paragraph breaks:

   ```csharp
   // INCORRECT — a blank line splits the block
   /// <summary>
   /// Calculates the total volume of the selected Revit elements.

   /// This operation might take a while on large BIM models.
   /// </summary>

   // CORRECT — use <para>
   /// <summary>
   /// Calculates the total volume of the selected Revit elements.
   /// <para>This operation might take a while on large BIM models.</para>
   /// </summary>
   ```

---

### 5. API Reference Documentation Locating
To minimize token consumption and avoid parsing full implementation files, you MUST consult the generated Markdown documentation first when exploring type schemas, namespaces, and public API interfaces:
To save tokens, consult the generated Markdown API docs before parsing `.cs` source when exploring type schemas, namespaces, or public API.

- **Path:** `documentation/API/[AssemblyName]/` in each active workspace — one directory per assembly, split by **namespace** (e.g. `DiGi.Core.Classes.md`). These files hold exact signatures and `<summary>` descriptions for all public classes, constructors, methods, properties, and enums.
- **Fallback:** if `documentation/API/` is absent, scan the C# source and `/bin/*.xml` files.

---

### 6. Serialization Pattern (SerializableObject / ISerializableObject)
Classes under `/Classes` needing JSON persistence, cloning, or polymorphic deserialization MUST inherit `DiGi.Core.Classes.SerializableObject` in this exact shape (reflection-driven — no manual JSON parsing).

1. **Marker interfaces** per project under `/Interfaces` (mirroring `DiGi.GIS.Interfaces.IGISObject`/`IGISSerializableObject`):
   ```csharp
   // /Interfaces/I<Project>Object.cs
   public interface I<Project>Object : DiGi.Core.Interfaces.IObject
   {
   }

   // /Interfaces/I<Project>SerializableObject.cs
   public interface I<Project>SerializableObject : I<Project>Object, DiGi.Core.Interfaces.ISerializableObject
   {
   }
   ```
   Every serializable class implements `I<Project>SerializableObject` (e.g. `public class Holiday : SerializableObject, IEPWSerializableObject`).
2. **Fields:** `private readonly`, each `[JsonInclude, JsonPropertyName(nameof(PublicPropertyName))]` — always `nameof(...)`, never a hardcoded string literal.
3. **Three constructors, always in this order:**
   - **Primary** (plain params, assigns fields) — no `base(...)` call needed.
   - **Copy** `ClassName(ClassName? classNameInstance) : base(classNameInstance)`, copying every field:
     - Primitive/value-type fields and strings: copy by value.
     - `List<T>`/`IList<T>` of **primitives**: `new List<T>(source)` (or `null` if source is `null`).
     - `IList<T>` of **nested `SerializableObject`-derived items**: clone element-by-element filtering nulls (see the excerpt below). Do NOT pipe the `IEnumerable<T>.Clone<T>()` extension into an `IList<T>` field — it returns `List<T?>?`, a nullable-element mismatch against a non-nullable `IList<T>` field.
     - A single nested `SerializableObject` reference: `field = Core.Query.Clone(source.field);`.
   - **JSON** `ClassName(JsonObject? jsonObject) : base(jsonObject)` — pure delegation, empty body.
4. **Properties:** `[JsonIgnore]` get-only, returning the backing field (the field attribute handles serialization — do not also serialize through the property).
5. **Project file:** `.csproj` needs a `<Reference Include="DiGi.Core"><HintPath>..\..\DiGi.Core\bin\DiGi.Core.dll</HintPath></Reference>` and a `<PackageReference Include="System.Text.Json" .../>` matching the version used elsewhere (check `DiGi.Core.csproj`).

### Example — simple class with primitive fields (`/Classes/Holiday.cs`)
```csharp
using DiGi.Core.Classes;
using DiGi.EPW.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.EPW.Classes
{
    public class Holiday : SerializableObject, IEPWSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Name))]
        private readonly string? name;

        [JsonInclude, JsonPropertyName(nameof(Date))]
        private readonly string? date;

        public Holiday(string? name, string? date)
        {
            this.name = name;
            this.date = date;
        }

        public Holiday(Holiday? holiday)
            : base(holiday)
        {
            if (holiday != null)
            {
                name = holiday.name;
                date = holiday.date;
            }
        }

        public Holiday(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        [JsonIgnore]
        public string? Name
        {
            get
            {
                return name;
            }
        }

        [JsonIgnore]
        public string? Date
        {
            get
            {
                return date;
            }
        }
    }
}
```

### Example — nested list of `SerializableObject` items (copy-constructor excerpt)
```csharp
public HolidaysDaylightSaving(HolidaysDaylightSaving? holidaysDaylightSaving)
    : base(holidaysDaylightSaving)
{
    if (holidaysDaylightSaving != null)
    {
        leapYearObserved = holidaysDaylightSaving.leapYearObserved;

        if (holidaysDaylightSaving.holidays != null)
        {
            holidays = [];
            foreach (Holiday holiday in holidaysDaylightSaving.holidays)
            {
                if (Core.Query.Clone(holiday) is Holiday holiday_Temp)
                {
                    holidays.Add(holiday_Temp);
                }
            }
        }
    }
}
```

### Example — `List<double>` of primitives (copy-constructor excerpt)
```csharp
public GroundTemperature(GroundTemperature? groundTemperature)
    : base(groundTemperature)
{
    if (groundTemperature != null)
    {
        depth = groundTemperature.depth;
        monthlyValues = groundTemperature.monthlyValues == null ? null : new List<double>(groundTemperature.monthlyValues);
    }
}
```

---

### 7. Automatic Tests (xUnit)
1. **One test project per project:** `[ProjectName].xUnit` (e.g. `DiGi.Core.xUnit`, `DiGi.Geometry.xUnit`).
2. **`public partial class Facts`** holds all test methods (one shared class per namespace).
3. **Files under `/Facts`.**
4. **Namespace matches the test project** (e.g. `namespace DiGi.Core.xUnit`).
5. **`Xunit` is global-usinged** by project config — do NOT add `using Xunit;`.
6. **`[Fact]`** marks test methods.
7. **Name the method** after the class/property/method under test (`Color()`, `PlanarIntersectionResult_Performance()`).
8. **XML `<summary>` on every test** describing what is tested — no empty lines inside the block (they break VS tooltips); use `<para>` for paragraph breaks.

#### 📂 Shared Test Data Files (Fixtures)
When a test needs an on-disk input file (`.gmf`, `.json`, `.epw`, …), use the **one shared `files` directory** — do NOT add a per-project data folder.

1. **Location:** `DiGi.Test/files/` (the `DiGi.Test` repo sits beside the other `DiGi.*` repos under the `DiGi` workspace root; from a `DiGi.Test/<ProjectName>.xUnit/` dir it is `../files/`). The path is given relative to the workspace root because this guideline lives in the separate `DiGi.Maintenance` repo.
2. **Add a fixture:** drop the file into `DiGi.Test/files/` and reference it by file name only. Files are read **in place** (not copied to build output) — no `<None CopyToOutputDirectory>` entry needed.
3. **Resolve the path:** `Core.xUnit.Query.FilePath(System.Reflection.Assembly.GetExecutingAssembly(), "<fileName>")` returns the absolute path to `DiGi.Test/files/<fileName>`; for the directory itself use `assembly.FilesDirectory()`. Both live in `DiGi.Core.xUnit/Query/` (`FilePath.cs`, `FilesDirectory.cs`) and resolve by walking up from the test assembly's `bin/<ProjectName>.xUnit/` output. `FilePath` `Assert`s the directory resolves, so a `null`/missing result fails the test cleanly.
4. **No `using` needed** — call it fully qualified as `Core.xUnit.Query.FilePath(...)`; it resolves via the same innermost-enclosing-namespace lookup as `Core.xUnit.Query.SerializationCheck(...)`, as long as the test namespace nests under `DiGi`. Add `using System.Reflection;` (or fully qualify `Assembly`).
5. **Example:**
   ```csharp
   using System.Reflection;
   // ...
   string? path = Core.xUnit.Query.FilePath(Assembly.GetExecutingAssembly(), "0207_GML.gmf");
   Assert.False(string.IsNullOrWhiteSpace(path));
   Assert.True(System.IO.File.Exists(path));
   ```
   References: `DiGi.GIS.xUnit/Facts/OrtoDatas.cs`, `DiGi.EPW.xUnit/Facts/EPWFile.cs`, `DiGi.Geometry.xUnit/Facts/InRange.cs`.
6. **Large binaries** (multi-MB `.gmf`, etc.) are git-tracked (not ignored) — prefer a representative-but-minimal sample, and consider Git LFS if size becomes a concern.

#### 📄 Test Reports & Diagnostic Outputs
Input fixtures are read from `files/`; everything a test **writes** goes to `DiGi.Test/user files/reports/`.

1. **Rule:** ALL reports, text dumps, benchmark logs and diagnostic output produced during test execution must be written to `user files/reports/` — never to `files/`, and never to a hardcoded machine path. `user files/` is git-ignored, so test output never lands in a commit.
2. **Resolve the folder:** `Core.xUnit.Query.ReportsDirectory(Assembly.GetExecutingAssembly())` or `assembly.ReportsDirectory()` (both resolve **and create** `DiGi.Test/user files/reports/`). For the parent folder use `assembly.UserFilesDirectory()`. Helpers live in `DiGi.Core.xUnit/Query/` beside `FilePath.cs` / `FilesDirectory.cs`.
3. **Example:**
   ```csharp
   using System.Reflection;
   // ...
   string? pathReportsDirectory = Core.xUnit.Query.ReportsDirectory(Assembly.GetExecutingAssembly());
   Assert.False(string.IsNullOrWhiteSpace(pathReportsDirectory));

   string pathReport = System.IO.Path.Combine(pathReportsDirectory!, "Diagnostic_Report.txt");
   System.IO.File.WriteAllLines(pathReport, reportLines);
   ```
   References: `DiGi.CityGML.xUnit/Facts/InspectDuplicates.cs`, `DiGi.GIS.Analytical.xUnit/Facts/BuildingModel_Enclosed.cs`.

#### Browser Testing (Interactive DoD)
Verify *interactive* front-end behaviour (panel toggles, drag-resize with clamps, keyboard operability, `localStorage` persistence, responsive stacking, shared header/footer collapse) in a **real browser** instead of only reading the code. Full recipe in `Coding - Browser Testing.md`.

1. **Confirm the toolchain on THIS machine first — availability is per-machine.** Probe Python + pip, Playwright (`pip show playwright`), and an installed Chromium-based browser (Microsoft Edge, Chrome, or Playwright's own Chromium); install whatever is missing. Do not treat any observed versions as a fixed requirement.
2. **Run with the host shell, not the isolated sandbox** — the sandbox has no host filesystem, no network, and cannot reach `localhost`. Keep test scripts and screenshots in the scratchpad so the repo stays clean.
3. **Recipe:** start the app from the build output with a fixed `ASPNETCORE_URLS`, poll a cheap endpoint until it returns 200, then drive it with `page.click` / `keyboard.press` / a `page.mouse` step-drag; assert computed styles, `aria-expanded`, `localStorage`, and no horizontal overflow; `set_viewport_size` for responsive breakpoints; **terminate the server in a `finally`**.
4. **Gotchas:** a collapsed panel measures 0 — open it before measuring (the `localStorage` value is the source of truth); drag with `page.mouse` steps, not a one-shot `.drag_to()`; settle before asserting; **rebuild before re-verifying a `.cshtml` change** (Razor views compile at build time, while CSS/JS serve live from source).
5. **Verify rendered output, not state:** a toggle whose flags flip is not a toggle whose effect is visible — assert a screenshot-region luminance that moves with the toggle and restores after toggling back; a pixel-minimum across several parameter values isolates parameter-independent artefacts; GPU cost comes from `EXT_disjoint_timer_query_webgl2` in a headed browser with vsync off (rAF cadence is CPU submit time; headless SwiftShader numbers are unusable).
6. **Not for:** pure server-side/C# logic (use xUnit, see §7) or a one-off "does it render" check (a `curl` of the endpoint is enough).

---

### 8. Branch Synchronization & Versioning Protocol
1. **Version branch only:** run only when the active branch is a bare SemVer `*.*.*` (e.g. `0.8.2`, `1.12.0`). Skip anything with text, prefix, or suffix (`feature/login`, `v0.8.2`, `0.8.2-beta`, `main`).
2. **Differs from main:** run only for repos where the active branch differs from `main`; skip repos where they are identical.

#### 🔄 Synchronization Workflow (Execution Steps)
1. **Sync with main:** merge the version branch into `main` so both hold the exact same codebase, with no pending diffs.
2. **Bump patch:** increment the third version digit by 1 (`0.8.2` → `0.8.3`).
3. **Branch off main** using that new version name.
4. **Update `Directory.Build.props`** (if present): set `<Major>`/`<Minor>`/`<Build>` to the new version's components and commit on the new branch before pushing.
5. **Push & track:** push both `main` and the new version branch to `origin`, using `-u` on the new branch so it tracks properly (`git push -u origin <version_branch>`).

---

### 9. Full Guideline Set
This block is the condensed, always-applicable subset. The canonical, task-specific guidelines live in
`DiGi.Maintenance/documentation/AI Guidelines/` (path relative to the workspace root, since they sit in
the separate `DiGi.Maintenance` repo). Read the one matching the task rather than all of them; each is
also mirrored per repository as a skill under `.agents/skills/<skill-name>/SKILL.md`.

| Guideline | Read it when |
|---|---|
| `Coding - General.md` | Writing or editing any C# production code; adding a NuGet package to a `HintPath`-referenced library. |
| `Coding - Editor Config.md` | Configuring or auditing `.editorconfig` code style and diagnostic severities. |
| `Coding - API Documentation.md` | Looking up a public signature — read `documentation/API/` before `.cs` source. |
| `Coding - References.md` | Comparing, keying or de-duplicating an `IReference` / `IUniqueReference`. |
| `Coding - Automatic Tests.md` | Writing xUnit tests, shared fixtures, or test report output. |
| `Coding - Geometry.md` | Orienting, closing, triangulating, hashing or sweeping geometry — `SunDirection` points away from the sun, `Vector3D.Unit` is never null, `IsClosed` is not monotonic in tolerance, sub-tolerance corners hang `Triangulate`, symmetric fixtures cannot catch a mirror. |
| `Coding - ComputeSharp.md` | Writing or changing a ComputeSharp `IComputeShader` — never combine an odd root constant count (`ConstantBufferSize / 4`) with an odd resource count (silently wrong results on NVIDIA RTX 5090); reorder or pad fields, then update the layout guard fact. |
| `Coding - YOLO.md` | YOLO Year Built detector — runner modes, `model.pt` resolution, the first-detection year built predictor, training data and training scratch outside the workspace (never in `user files/`), deploying the runner extension from an allowlist (only `model.pt`). |
| `Coding - Templates.md` | Scaffolding a solution/project from `templates/`. |
| `Coding - WebAPI GLTF.md` | Building or extending a Web API on the `DiGi.GLTF` 3D framework. |
| `Coding - WebAPI Contracts.md` | Changing a WebAPI route/parameter, or writing an HTTP client of one; adding a controller constructor (exactly one public) or returning a DiGi object (`Content(Core.Convert.ToSystem_String(x), "application/json")`, never `Ok(x)`); client timeouts. |
| `Coding - WebAPI Simple Authorization.md` | Simple API-key-based tiered authorization for WebAPI controllers (deny-by-default, `key` request header, `.conf` assets, `Deploy.ps1` alignment). |
| `Coding - Deployed WebAPI.md` | Verifying a change against the live API at `api.digiproject.uk` (read-only GET; never in `DiGi.Test`); which per-prefix Swagger document to fetch (`/swagger/<prefix>/swagger.json`) to keep context small. |
| `Coding - Browser Testing.md` | Verifying interactive front-end behaviour in a real browser (Playwright driving an installed Chromium-based browser) — panel toggles, drag-resize with clamps, keyboard operability, `localStorage` persistence, responsive stacking, shared header/footer collapse; confirm the toolchain on THIS machine first. |
| `Coding - GIS Administrative Data.md` | Touching `administrative_areal_2d`, `building_2d`, or anything keyed by a county code or id. |
| `Coding - PostgreSQL.md` | Designing schemas, composite unique constraints, batching, timeouts, or converters in PostgreSQL/Npgsql. |
| `Coding - PostgreSQL Distributed Queue Processing.md` | Distributed bulk update queues — table schema (`claimed_at`, `created_at`, natural uniqueness), atomic lease claims (`FOR UPDATE SKIP LOCKED`), native interval arithmetic, explicit batch acknowledgment, and non-destructive observation. |
| `XML Documentation - Create.md` / `- Audit.md` | Adding missing `<summary>` docs, or auditing docs against current signatures. |
| `GitHub Wiki - General.md` / `- Home.md` / `- Benchmark.md` | Editing a wiki page, a `Home` landing page, or a `Benchmark` performance page. |
| `GitHub - Branch Pull.md` / `- Branch Synchronization.md` | Pulling repos to their highest SemVer branch, or running the release/patch-bump workflow. |
| `GitHub - Issues.md` | Creating, commenting on and closing issues — mandatory labels + default assignee, `--body-file`, verifying premises first, and **blocking relationships as GitHub issue dependencies** (`gh api … /dependencies/blocked_by`, cross-repository, set at blocker creation, verified with the `blocking` GET; a blocked issue is not started). |
| `GitHub - Plan Files.md` | Keeping the repository free of plan files — plans live outside the working tree, no plan/scratch `*.md` is ever committed or pushed, and the default is deleting the temporary implementation plan when the issue closes (no archiving into the repo; explicit user instruction wins). |
| `GitHub - Sub-Issues.md` | Creating sub-issues / sub-tasks for a feature — the tracking-issue pattern: a parent tracking issue with a Sub-issues table + one self-contained sub-issue per repository, each referencing the parent. |

> **One data rule worth knowing before it bites you:** a GIS county `code` does **not** identify one row.
> BDOT10k stores one `administrative_areal_2d` feature per polygon part, so 406 county rows cover 380
> codes, and 18 counties have several. Key every write and lookup by county **`id`**, give every
> `LIMIT`/`FirstOrDefault` over that table an explicit `ORDER BY`, and never "deduplicate" those rows —
> for `2412 rybnicki` the largest polygon is only 52 % of the county. Two corollaries that have each
> cost real data: **the number of county ids a caller sent is not evidence about how many parts the code
> has**, so resolve every item against `building_2d` rather than trusting a single id; and a **read** of
> a table keyed on a building must pass `fallbackByReference: true`, because it defaults to `false` and
> a row under a sibling part is then silently not returned. Full model in
> `Coding - GIS Administrative Data.md`.
