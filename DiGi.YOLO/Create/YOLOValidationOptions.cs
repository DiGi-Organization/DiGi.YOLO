using DiGi.YOLO.Classes;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        /// <summary>
        /// Builds the options for one run of the YOLO validation script, resolving the interpreter, normalizing the paths and then checking that the combination can actually make a run.
        /// <para>The <see cref="Classes.YOLOValidationOptions"/> constructors only assign, so this is where the work belongs. The split, image size, batch and confidence keep their defaults (test, 640, 16, the ultralytics default) and are set on the returned options.</para>
        /// </summary>
        /// <param name="pythonPath">The path of the CPython interpreter, or the name of one on PATH. Null searches PATH.</param>
        /// <param name="modelPath">The path of the weights file to validate, an existing .pt checkpoint.</param>
        /// <param name="configurationFilePath">The path of the dataset configuration file (conf.yaml).</param>
        /// <param name="workingDirectory">The directory the process runs in and the scripts are kept in. Null uses the directory holding the configuration file.</param>
        /// <returns>The options, or <c>null</c> when no interpreter was found, the configuration file does not exist, or the weights file does not exist or is not a .pt checkpoint.</returns>
        public static YOLOValidationOptions? YOLOValidationOptions(string? pythonPath, string? modelPath, string? configurationFilePath, string? workingDirectory = null)
        {
            string? pythonPath_Resolved = Python.Query.PythonPath(pythonPath);
            string? modelPath_Resolved = Python.Query.NormalizedPath(modelPath);
            string? configurationFilePath_Resolved = Python.Query.NormalizedPath(configurationFilePath);

            if (string.IsNullOrWhiteSpace(pythonPath_Resolved))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(modelPath_Resolved) || !File.Exists(modelPath_Resolved) || Query.ModelKind(modelPath_Resolved) != Enums.ModelKind.Checkpoint)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(configurationFilePath_Resolved) || !File.Exists(configurationFilePath_Resolved))
            {
                return null;
            }

            string? workingDirectory_Resolved = Python.Query.NormalizedPath(workingDirectory) ?? Python.Query.NormalizedPath(Path.GetDirectoryName(configurationFilePath_Resolved));

            if (string.IsNullOrWhiteSpace(workingDirectory_Resolved))
            {
                return null;
            }

            return new YOLOValidationOptions()
            {
                ConfigurationFilePath = configurationFilePath_Resolved,
                ModelPath = modelPath_Resolved,
                PythonPath = pythonPath_Resolved,
                WorkingDirectory = workingDirectory_Resolved
            };
        }
    }
}
