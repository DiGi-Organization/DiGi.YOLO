using DiGi.Python.Classes;
using DiGi.YOLO.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Probes Python interpreter candidates to detect whether the machine can execute YOLO workloads, returning environment details and dependency versions.
        /// <para>Checks candidate interpreters on PATH in order and reports the first interpreter that is runnable. Never throws an exception; probe failures or invalid interpreters are returned with <see cref="YOLOEnvironmentResult.Runnable"/> set to <c>false</c> and diagnostic reasons in <see cref="YOLOEnvironmentResult.Messages"/>. Non-fatal findings are returned in <see cref="YOLOEnvironmentResult.Warnings"/> and do not affect <see cref="YOLOEnvironmentResult.Runnable"/>.</para>
        /// <para>The probe isolates the ultralytics settings file in its working directory through YOLO_CONFIG_DIR, so switching ultralytics versions between probes no longer rewrites or loses the other's settings, and it reads the JSON payload of check.py from between the script's marker lines rather than from whatever line happens to start with a brace.</para>
        /// </summary>
        /// <param name="pythonPath">The path of the CPython interpreter, a command name on PATH, or <c>null</c> to search PATH.</param>
        /// <param name="modelPath">The path of the trained model file to probe for compatibility, or <c>null</c>.</param>
        /// <param name="cancellationToken">The token that cancels probing.</param>
        /// <returns>The result of the environment preflight check.</returns>
        public static YOLOEnvironmentResult YOLOEnvironmentResult(string? pythonPath, string? modelPath, CancellationToken cancellationToken = default)
        {
            return YOLOEnvironmentResult(pythonPath, modelPath, null, cancellationToken);
        }

        /// <summary>
        /// Probes Python interpreter candidates in a specified working directory context to detect whether the machine can execute YOLO workloads.
        /// <para>The ultralytics settings file is isolated in the working directory: the probe points YOLO_CONFIG_DIR at its .yolo-config folder, and reads the JSON payload of check.py from between the script's marker lines.</para>
        /// </summary>
        /// <param name="pythonPath">The path of the CPython interpreter, a command name on PATH, or <c>null</c> to search PATH.</param>
        /// <param name="modelPath">The path of the trained model file to probe for compatibility, or <c>null</c>.</param>
        /// <param name="workingDirectory">The directory where scripts are written and executed, or <c>null</c> to use temporary storage. The ultralytics settings file of the probe is isolated in this directory.</param>
        /// <param name="cancellationToken">The token that cancels probing.</param>
        /// <returns>The result of the environment preflight check.</returns>
        public static YOLOEnvironmentResult YOLOEnvironmentResult(string? pythonPath, string? modelPath, string? workingDirectory, CancellationToken cancellationToken = default)
        {
            DateTimeOffset start = DateTimeOffset.Now;

            string? path_Model = Python.Query.NormalizedPath(modelPath) ?? modelPath;
            string? path_Working = Python.Query.NormalizedPath(workingDirectory) ?? workingDirectory;

            if (string.IsNullOrWhiteSpace(path_Working))
            {
                path_Working = Path.Combine(Path.GetTempPath(), "DiGi_YOLO_Preflight");
            }

            Dictionary<string, string> environmentVariables = new();

            try
            {
                if (!Directory.Exists(path_Working))
                {
                    Directory.CreateDirectory(path_Working);
                }

                //Always rewritten, never only when missing: the probe must run the check.py that shipped with this
                //build. A preflight directory persists between runs, so a guard that wrote once and then skipped would
                //keep executing the probe of whichever build first touched the directory - the exact stale-script failure
                //that makes a preflight fix appear to do nothing. WriteScripts is idempotent and small, so the cost is a
                //few file copies per probe.
                Modify.WriteScripts(path_Working);

                //Isolates the ultralytics settings file in the working directory: without YOLO_CONFIG_DIR every run
                //reads and writes the shared machine-wide settings file, so whichever version runs after the other
                //rewrites the file it does not expect, prints a settings notice on stdout and loses the custom values
                //the other version had stored. Creation can fail on a read-only working directory, which the probe
                //answers as a failed preflight rather than throwing
                environmentVariables = ConfigEnvironmentVariables(path_Working!);
            }
            catch (Exception exception)
            {
                return new YOLOEnvironmentResult(false, pythonPath, null, null, null, null, path_Model, null, [string.Format("Failed to prepare working directory '{0}': {1}", path_Working, exception.Message)], null, start);
            }

            List<string> candidates = Python.Query.PythonPaths(pythonPath);
            if (candidates.Count == 0)
            {
                string message = string.IsNullOrWhiteSpace(pythonPath) ? "No Python interpreter found on PATH." : string.Format("Interpreter path '{0}' was not found.", pythonPath);
                return new YOLOEnvironmentResult(false, pythonPath, null, null, null, null, path_Model, null, [message], null, start);
            }

            static string Quoted(string? value)
            {
                return string.Concat("\"", value, "\"");
            }

            string scriptPath = Path.Combine(path_Working, Constants.FileName.Check);
            string arguments_Base = Quoted(scriptPath);
            if (!string.IsNullOrWhiteSpace(path_Model))
            {
                arguments_Base = string.Concat(arguments_Base, " --model ", Quoted(path_Model));
            }

            List<string> messages_Accumulated = [];
            List<string> warnings_Accumulated = [];

            foreach (string candidate in candidates)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    messages_Accumulated.Add("Environment preflight probe was cancelled.");
                    break;
                }

                PythonProcessResult pythonProcessResult = Python.Query.ExecuteProcess(candidate, arguments_Base, path_Working!, environmentVariables, cancellationToken);
                int exitCode = pythonProcessResult.ExitCode;
                List<string> standardOutput = pythonProcessResult.StandardOutput ?? [];
                List<string> standardError = pythonProcessResult.StandardError ?? [];

                if (exitCode != 0)
                {
                    string errorDetail = standardError.Count > 0 ? string.Join(Environment.NewLine, standardError) : string.Format("Process exited with code {0}", exitCode);
                    messages_Accumulated.Add(string.Format("Interpreter candidate '{0}' failed preflight run: {1}", candidate, errorDetail));
                    continue;
                }

                //The payload sits between the check.py markers, so a settings notice or any other line printed before it is never picked up
                string? line_Json = Python.Query.MarkedJson(standardOutput, Constants.Marker.CheckJsonBegin, Constants.Marker.CheckJsonEnd);

                if (string.IsNullOrWhiteSpace(line_Json))
                {
                    messages_Accumulated.Add(string.Format("Interpreter candidate '{0}' returned no JSON payload.", candidate));
                    continue;
                }

                try
                {
                    JsonNode? jsonNode = JsonNode.Parse(line_Json!);
                    if (jsonNode == null)
                    {
                        messages_Accumulated.Add(string.Format("Interpreter candidate '{0}' returned invalid JSON.", candidate));
                        continue;
                    }

                    bool runnable = jsonNode["runnable"]?.GetValue<bool>() ?? false;
                    string? pythonVersion = jsonNode["python_version"]?.ToString();
                    string? ultralyticsVersion = jsonNode["ultralytics_version"]?.ToString();
                    string? torchVersion = jsonNode["torch_version"]?.ToString();
                    bool? cudaAvailable = jsonNode["cuda_available"] is JsonValue cudaValue && cudaValue.TryGetValue(out bool cudaBool) ? cudaBool : null;
                    string? modelUltralyticsVersion = jsonNode["model_ultralytics_version"]?.ToString();

                    List<string> messages_Candidate = [];
                    if (jsonNode["messages"] is JsonArray jsonArray)
                    {
                        foreach (JsonNode? item in jsonArray)
                        {
                            if (item != null)
                            {
                                messages_Candidate.Add(item.ToString());
                            }
                        }
                    }

                    List<string> warnings_Candidate = [];
                    if (jsonNode["warnings"] is JsonArray jsonArray_Warnings)
                    {
                        foreach (JsonNode? item in jsonArray_Warnings)
                        {
                            if (item != null)
                            {
                                warnings_Candidate.Add(item.ToString());
                            }
                        }
                    }

                    if (runnable)
                    {
                        return new YOLOEnvironmentResult(true, candidate, pythonVersion, ultralyticsVersion, torchVersion, cudaAvailable, path_Model, modelUltralyticsVersion, messages_Candidate, warnings_Candidate, start);
                    }

                    string prefix = string.Format("Candidate '{0}': ", candidate);
                    if (messages_Candidate.Count == 0 && warnings_Candidate.Count == 0)
                    {
                        messages_Accumulated.Add(string.Concat(prefix, "Not runnable."));
                    }
                    else
                    {
                        foreach (string msg in messages_Candidate)
                        {
                            messages_Accumulated.Add(string.Concat(prefix, msg));
                        }

                        foreach (string warning in warnings_Candidate)
                        {
                            warnings_Accumulated.Add(string.Concat(prefix, warning));
                        }
                    }
                }
                catch (Exception exception)
                {
                    messages_Accumulated.Add(string.Format("Interpreter candidate '{0}' output parsing error: {1}", candidate, exception.Message));
                }
            }

            string? primaryPath = candidates.Count > 0 ? candidates[0] : pythonPath;
            return new YOLOEnvironmentResult(false, primaryPath, null, null, null, null, path_Model, null, messages_Accumulated, warnings_Accumulated, start);
        }
    }
}