using DiGi.Python.Classes;
using DiGi.YOLO.Classes;
using DiGi.YOLO.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace DiGi.YOLO
{
    public static partial class Modify
    {
        /// <summary>
        /// Runs the YOLO validation script in a CPython process and reports the box mAP of a weights file on one split of a dataset.
        /// <para>Run once per weights file on the same split to compare detectors - the frozen train8 and each training candidate on the test split, for instance. The weights are hashed before the run, so every result names exactly which file it measured. The scripts are rewritten in the working directory first, the weights are preflighted with <see cref="Query.YOLOEnvironmentResult(string?, string?, string?, CancellationToken)"/>, and the ultralytics settings file is isolated in the .yolo-config folder of the working directory.</para>
        /// <para>The run is synchronous. Cancelling it kills the interpreter and returns a result carrying a non-zero exit code rather than throwing.</para>
        /// </summary>
        /// <param name="yOLOValidationOptions">The settings for the run.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>The result of the run, or <c>null</c> when the options are missing the interpreter, the weights or the configuration file.</returns>
        public static YOLOValidationResult? Validate(this YOLOValidationOptions? yOLOValidationOptions, CancellationToken cancellationToken = default)
        {
            if (yOLOValidationOptions == null)
            {
                return null;
            }

            string? pythonPath = yOLOValidationOptions.PythonPath;
            string? modelPath = yOLOValidationOptions.ModelPath;
            string? configurationFilePath = yOLOValidationOptions.ConfigurationFilePath;

            if (string.IsNullOrWhiteSpace(pythonPath) || string.IsNullOrWhiteSpace(modelPath) || string.IsNullOrWhiteSpace(configurationFilePath))
            {
                return null;
            }

            modelPath = Python.Query.NormalizedPath(modelPath) ?? modelPath;
            configurationFilePath = Python.Query.NormalizedPath(configurationFilePath) ?? configurationFilePath;

            string? workingDirectory = Python.Query.NormalizedPath(yOLOValidationOptions.WorkingDirectory) ?? Python.Query.NormalizedPath(Path.GetDirectoryName(configurationFilePath));
            if (string.IsNullOrWhiteSpace(workingDirectory))
            {
                return null;
            }

            Category split = yOLOValidationOptions.Split;

            DateTimeOffset start = DateTimeOffset.Now;

            YOLOValidationResult Refused(string? modelSHA256, IEnumerable<string> messages)
            {
                return new YOLOValidationResult(-1, modelPath, modelSHA256, split, null, null, null, messages, start, DateTimeOffset.Now);
            }

            //val.py names the splits after the keys of conf.yaml; training images are not a validation split
            string? split_Name = split == Category.Train ? null : Query.DirectoryName(split);
            if (string.IsNullOrWhiteSpace(split_Name))
            {
                return Refused(null, [string.Format("Split {0} cannot be validated on; use Validate or Test.", split)]);
            }

            if (Query.ModelKind(modelPath) != ModelKind.Checkpoint || !File.Exists(modelPath))
            {
                return Refused(null, [string.Format("Weights are not an existing .pt checkpoint: {0}", modelPath)]);
            }

            if (!File.Exists(configurationFilePath))
            {
                return Refused(null, [string.Format("Configuration file does not exist: {0}", configurationFilePath)]);
            }

            if (yOLOValidationOptions.ImageSize < 32 || yOLOValidationOptions.Batch < 1 || (yOLOValidationOptions.Confidence is double confidence && (double.IsNaN(confidence) || confidence < 0 || confidence > 1)))
            {
                return Refused(null, [string.Format(CultureInfo.InvariantCulture, "Invalid parameters: imgsz {0}, batch {1}, conf {2}.", yOLOValidationOptions.ImageSize, yOLOValidationOptions.Batch, yOLOValidationOptions.Confidence)]);
            }

            string? modelSHA256 = Python.Query.FileSHA256(modelPath);

            try
            {
                if (!Directory.Exists(workingDirectory))
                {
                    Directory.CreateDirectory(workingDirectory);
                }

                //Always rewritten, never only when missing, so a directory never runs a val.py of an older build
                WriteScripts(workingDirectory);
            }
            catch (Exception exception)
            {
                return Refused(modelSHA256, [string.Format("Failed to prepare working directory '{0}': {1}", workingDirectory, exception.Message)]);
            }

            YOLOEnvironmentResult yOLOEnvironmentResult = Query.YOLOEnvironmentResult(pythonPath, modelPath, workingDirectory, cancellationToken);
            if (!yOLOEnvironmentResult.Runnable)
            {
                List<string> messages = ["Environment preflight failed."];
                if (yOLOEnvironmentResult.Messages != null)
                {
                    messages.AddRange(yOLOEnvironmentResult.Messages);
                }

                return Refused(modelSHA256, messages);
            }

            pythonPath = yOLOEnvironmentResult.PythonPath ?? pythonPath;

            static string Quoted(string? value)
            {
                return string.Concat("\"", value, "\"");
            }

            StringBuilder stringBuilder_Arguments = new();
            stringBuilder_Arguments.Append(Quoted(Path.Combine(workingDirectory, Constants.FileName.Validate)));
            stringBuilder_Arguments.Append(" --model ").Append(Quoted(modelPath));
            stringBuilder_Arguments.Append(" --data ").Append(Quoted(configurationFilePath));
            stringBuilder_Arguments.Append(" --split ").Append(split_Name);
            stringBuilder_Arguments.Append(" --imgsz ").Append(yOLOValidationOptions.ImageSize.ToString(CultureInfo.InvariantCulture));
            stringBuilder_Arguments.Append(" --batch ").Append(yOLOValidationOptions.Batch.ToString(CultureInfo.InvariantCulture));

            //argparse parses --conf with float(), which reads a decimal point and nothing else
            if (yOLOValidationOptions.Confidence is double confidence_Value)
            {
                stringBuilder_Arguments.Append(" --conf ").Append(confidence_Value.ToString("R", CultureInfo.InvariantCulture));
            }

            if (!string.IsNullOrWhiteSpace(yOLOValidationOptions.Device))
            {
                stringBuilder_Arguments.Append(" --device ").Append(Quoted(yOLOValidationOptions.Device));
            }

            Dictionary<string, string> environmentVariables = Query.ConfigEnvironmentVariables(workingDirectory!);

            PythonProcessResult pythonProcessResult = Python.Query.ExecuteProcess(pythonPath!, stringBuilder_Arguments.ToString(), workingDirectory!, environmentVariables, cancellationToken);
            int exitCode = pythonProcessResult.ExitCode;
            List<string> standardOutput = pythonProcessResult.StandardOutput ?? [];
            List<string> standardError = pythonProcessResult.StandardError ?? [];

            (double? mAP50, double? mAP50_95) = Query.YOLOValidationOutput(standardOutput);

            return new YOLOValidationResult(exitCode, modelPath, modelSHA256, split, mAP50, mAP50_95, standardOutput, standardError, start, DateTimeOffset.Now);
        }
    }
}
