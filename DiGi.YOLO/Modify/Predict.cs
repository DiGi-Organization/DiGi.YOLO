using DiGi.YOLO.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace DiGi.YOLO
{
    public static partial class Modify
    {
        /// <summary>
        /// Runs the YOLO prediction script over a directory of images in a CPython process and reports how the run went.
        /// <para>The scripts are written into the working directory on every run, so a directory never keeps a script of an older build, a stale result file is removed so a failed run cannot be mistaken for this one, and the process is then run with its output streams captured. A source directory holding no images is answered without starting a process at all, because predict.py writes no result file in that case and the missing file would otherwise be indistinguishable from a crash.</para>
        /// <para>The ultralytics settings file is isolated in the working directory: the process is started with YOLO_CONFIG_DIR pointing at the .yolo-config folder of that directory, so the run never reads or rewrites the shared machine-wide settings file another ultralytics version uses.</para>
        /// <para>The run is synchronous. Cancelling it kills the interpreter and returns a result carrying a non-zero exit code rather than throwing. Only the interpreter is killed - this targets netstandard2.0, which has no overload for killing a whole process tree, so torch worker processes can outlive the cancellation.</para>
        /// </summary>
        /// <param name="yOLOPredictionOptions">The settings for the run.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>The result of the run, or <c>null</c> when the options are missing the interpreter, the weights, the source directory or the output path.</returns>
        public static YOLOPredictionResult? Predict(this YOLOPredictionOptions? yOLOPredictionOptions, CancellationToken cancellationToken = default)
        {
            if (yOLOPredictionOptions == null)
            {
                return null;
            }

            string? pythonPath = yOLOPredictionOptions.PythonPath;
            string? modelPath = yOLOPredictionOptions.ModelPath;
            string? sourceDirectory = yOLOPredictionOptions.SourceDirectory;
            string? outputPath = yOLOPredictionOptions.OutputPath;
            string? workingDirectory = yOLOPredictionOptions.WorkingDirectory;

            if (string.IsNullOrWhiteSpace(pythonPath) || string.IsNullOrWhiteSpace(modelPath) || string.IsNullOrWhiteSpace(sourceDirectory) || string.IsNullOrWhiteSpace(outputPath))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(workingDirectory))
            {
                workingDirectory = Path.GetDirectoryName(outputPath);
                if (string.IsNullOrWhiteSpace(workingDirectory))
                {
                    return null;
                }
            }

            //Resolved once, so that the file the runner deletes and reads back is the file the process is told to write. The process runs in a directory of its own, so a relative path would not mean the same thing on both sides.
            modelPath = Query.NormalizedPath(modelPath) ?? modelPath;
            outputPath = Query.NormalizedPath(outputPath) ?? outputPath;
            sourceDirectory = Query.NormalizedPath(sourceDirectory) ?? sourceDirectory;
            workingDirectory = Query.NormalizedPath(workingDirectory) ?? workingDirectory;

            if (!Directory.Exists(sourceDirectory))
            {
                return new YOLOPredictionResult(-1, 0, outputPath, null, null, [string.Format("Source directory does not exist: {0}", sourceDirectory)], DateTimeOffset.Now, DateTimeOffset.Now);
            }

            //The extensions predict.py globs for
            List<string> paths_Image = [];
            foreach (string searchPattern in new string[] { "*.jpg", "*.jpeg", "*.png" })
            {
                paths_Image.AddRange(Directory.GetFiles(sourceDirectory, searchPattern));
            }

            DateTimeOffset start = DateTimeOffset.Now;

            if (paths_Image.Count == 0)
            {
                return new YOLOPredictionResult(0, 0, outputPath, [], null, null, start, DateTimeOffset.Now);
            }

            if (!Directory.Exists(workingDirectory))
            {
                Directory.CreateDirectory(workingDirectory);
            }

            //Rewritten on every run, as the preflight does, never only when missing: a working directory outlives builds, and an older predict.py handed a flag it does not know exits with argparse's code 2 (DiGi-Organization/DiGi.YOLO#24). predict.py imports utils.py, and Python resolves that against the directory the script sits in, so the two are written together
            WriteScripts(workingDirectory);

            string? directory_Output = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(directory_Output) && !Directory.Exists(directory_Output))
            {
                Directory.CreateDirectory(directory_Output);
            }

            //A result file left by an earlier run would otherwise be read back as this run's answer
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            //The resolved paths, so that the file the runner deletes and reads back is the file the process is told to write
            YOLOPredictionOptions yOLOPredictionOptions_Resolved = new(yOLOPredictionOptions)
            {
                ModelPath = modelPath,
                OutputPath = outputPath,
                SourceDirectory = sourceDirectory,
                WorkingDirectory = workingDirectory
            };

            string? arguments = Query.PredictArguments(yOLOPredictionOptions_Resolved);
            if (arguments is null)
            {
                return null;
            }

            //Isolates the ultralytics settings file in the working directory, so the run never reads or rewrites the shared machine-wide settings file another ultralytics version uses
            Dictionary<string, string> environmentVariables = Query.ConfigEnvironmentVariables(workingDirectory!);

            (int exitCode, List<string> standardOutput, List<string> standardError) = Query.ExecuteProcess(pythonPath!, arguments, workingDirectory!, environmentVariables, cancellationToken);

            List<string>? values = exitCode == 0 && File.Exists(outputPath) ? [.. File.ReadAllLines(outputPath)] : null;

            return new YOLOPredictionResult(exitCode, paths_Image.Count, outputPath, values, standardOutput, standardError, start, DateTimeOffset.Now);
        }

        /// <summary>
        /// Runs the YOLO prediction script over a directory of images in a CPython process and returns the detections it found.
        /// <para>A convenience over <see cref="Predict(YOLOPredictionOptions?, CancellationToken)"/> for callers that only want the detections. A run that did not complete gives <c>null</c>, with no account of why - take the other overload when that matters, which for an unattended run it does.</para>
        /// </summary>
        /// <param name="pythonPath">The path of the CPython interpreter, or the name of one on PATH. Null searches PATH.</param>
        /// <param name="modelPath">The path of the trained weights file to score with.</param>
        /// <param name="sourceDirectory">The directory holding the images to score.</param>
        /// <param name="outputPath">The path of the bounding box result file to write.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>The detections, or <c>null</c> when the options could not be built or the run did not complete.</returns>
        public static BoundingBoxResultFile? Predict(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, CancellationToken cancellationToken = default)
        {
            return Predict(pythonPath, modelPath, sourceDirectory, outputPath, 32, cancellationToken);
        }

        /// <summary>
        /// Runs the YOLO prediction script over a directory of images in a CPython process with a custom batch size and returns the detections it found.
        /// <para>A convenience over <see cref="Predict(YOLOPredictionOptions?, CancellationToken)"/> for callers that only want the detections. A run that did not complete gives <c>null</c>, with no account of why - take the other overload when that matters, which for an unattended run it does.</para>
        /// </summary>
        /// <param name="pythonPath">The path of the CPython interpreter, or the name of one on PATH. Null searches PATH.</param>
        /// <param name="modelPath">The path of the trained weights file to score with.</param>
        /// <param name="sourceDirectory">The directory holding the images to score.</param>
        /// <param name="outputPath">The path of the bounding box result file to write.</param>
        /// <param name="batchSize">The number of images passed to the model in a single inference batch.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>The detections, or <c>null</c> when the options could not be built or the run did not complete.</returns>
        public static BoundingBoxResultFile? Predict(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, int batchSize, CancellationToken cancellationToken = default)
        {
            YOLOPredictionOptions? yOLOPredictionOptions = Create.YOLOPredictionOptions(pythonPath, modelPath, sourceDirectory, outputPath, null, 0.1, batchSize);
            if (yOLOPredictionOptions == null)
            {
                return null;
            }

            return Create.BoundingBoxResultFile(Predict(yOLOPredictionOptions, cancellationToken: cancellationToken));
        }
    }
}