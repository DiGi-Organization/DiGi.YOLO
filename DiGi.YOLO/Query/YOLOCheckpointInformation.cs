using DiGi.Python.Classes;
using DiGi.YOLO.Classes;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Reads what an ultralytics training checkpoint holds - the epoch it completed, whether it can still be resumed, the dataset and run folder it records, and the raw arguments it was trained with - by running checkpoint.py with the configured interpreter.
        /// <para>The script ships inside this assembly and is written into the working directory before it runs, with the ultralytics settings isolated in that directory's .yolo-config folder exactly as a training run isolates them, so nothing depends on what the machine-wide settings hold. The JSON payload is read from between the script's marker lines.</para>
        /// <para>Returns <c>null</c> for a missing or unreadable file, an interpreter that does not exist or cannot read the checkpoint, and a payload that is absent or malformed. The caller that refuses a resume names the reason from the properties - a finished checkpoint, a dataset file that no longer exists - rather than from a diagnostic string.</para>
        /// </summary>
        /// <param name="path">The path of the checkpoint (.pt) file to read.</param>
        /// <param name="pythonPath">The path of the CPython interpreter, a command name on PATH, or <c>null</c> to search PATH.</param>
        /// <param name="workingDirectory">The directory the script is written to and run in, or <c>null</c> to use temporary storage.</param>
        /// <param name="cancellationToken">The token that cancels the read.</param>
        /// <returns>The information the checkpoint holds, or <c>null</c> when it cannot be read.</returns>
        public static YOLOCheckpointInformation? YOLOCheckpointInformation(string? path, string? pythonPath = null, string? workingDirectory = null, CancellationToken cancellationToken = default)
        {
            string? path_Checkpoint = Python.Query.NormalizedPath(path) ?? path;
            if (string.IsNullOrWhiteSpace(path_Checkpoint) || !File.Exists(path_Checkpoint))
            {
                return null;
            }

            string? path_Python = Python.Query.PythonPath(pythonPath);
            if (string.IsNullOrWhiteSpace(path_Python))
            {
                return null;
            }

            string? path_Working = Python.Query.NormalizedPath(workingDirectory) ?? workingDirectory;
            if (string.IsNullOrWhiteSpace(path_Working))
            {
                path_Working = Path.Combine(Path.GetTempPath(), "DiGi_YOLO_Checkpoint");
            }

            Dictionary<string, string> environmentVariables;

            try
            {
                if (!Directory.Exists(path_Working))
                {
                    Directory.CreateDirectory(path_Working);
                }

                //Always rewritten, never only when missing: the read must run the checkpoint.py that shipped with
                //this build, not one an earlier build left in a persistent working directory
                Modify.WriteScripts(path_Working);
                environmentVariables = ConfigEnvironmentVariables(path_Working!);
            }
            catch
            {
                return null;
            }

            static string Quoted(string? value)
            {
                return string.Concat("\"", value, "\"");
            }

            static bool? ReadBool(JsonNode? jsonNode)
            {
                if (jsonNode is JsonValue jsonValue && jsonValue.TryGetValue(out bool value))
                {
                    return value;
                }

                return null;
            }

            static double? ReadDouble(JsonNode? jsonNode)
            {
                if (jsonNode is JsonValue jsonValue && jsonValue.TryGetValue(out double value))
                {
                    return value;
                }

                return null;
            }

            static int? ReadInt(JsonNode? jsonNode)
            {
                if (jsonNode is JsonValue jsonValue && jsonValue.TryGetValue(out int value))
                {
                    return value;
                }

                return null;
            }

            static string? ReadString(JsonNode? jsonNode)
            {
                if (jsonNode is JsonValue jsonValue && jsonValue.TryGetValue(out string? value))
                {
                    return value;
                }

                return null;
            }

            string scriptPath = Path.Combine(path_Working, Constants.FileName.Checkpoint);
            string arguments = string.Concat(Quoted(scriptPath), " --model ", Quoted(path_Checkpoint));

            PythonProcessResult pythonProcessResult = Python.Query.ExecuteProcess(path_Python!, arguments, path_Working!, environmentVariables, cancellationToken);
            int exitCode = pythonProcessResult.ExitCode;
            List<string> standardOutput = pythonProcessResult.StandardOutput ?? [];
            List<string> standardError = pythonProcessResult.StandardError ?? [];

            if (exitCode != 0)
            {
                return null;
            }

            string? line_Json = Python.Query.MarkedJson(standardOutput, Constants.Marker.CheckpointJsonBegin, Constants.Marker.CheckpointJsonEnd);
            if (string.IsNullOrWhiteSpace(line_Json))
            {
                return null;
            }

            JsonNode? jsonNode;

            try
            {
                jsonNode = JsonNode.Parse(line_Json!);
            }
            catch
            {
                return null;
            }

            if (jsonNode == null || !(ReadBool(jsonNode["readable"]) ?? false))
            {
                return null;
            }

            //ultralytics stores the 0-based index of the last epoch completed; the consumers name the completed count and the epoch a resume enters, both 1-based
            int? epochStored = ReadInt(jsonNode["epoch"]);
            int? epoch = epochStored != null && epochStored.Value >= 0 ? epochStored.Value + 1 : null;

            return new YOLOCheckpointInformation(
                ReadDouble(jsonNode["best_fitness"]),
                ReadString(jsonNode["data"]),
                epoch,
                ReadInt(jsonNode["epochs"]),
                ReadBool(jsonNode["finished"]) ?? true,
                ReadString(jsonNode["name"]),
                ReadString(jsonNode["project"]),
                jsonNode["train_args"]?.ToJsonString());
        }
    }
}
