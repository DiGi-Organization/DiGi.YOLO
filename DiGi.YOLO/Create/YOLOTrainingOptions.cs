using DiGi.YOLO.Classes;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        /// <summary>
        /// Builds the options for one run of the YOLO training script, resolving the interpreter, normalizing the paths and then checking that the combination can actually make a run.
        /// <para>The <see cref="Classes.YOLOTrainingOptions"/> constructors only assign, so this is where the work belongs. It resolves first and validates afterwards, because the interpreter is usually given by name rather than by path and a name cannot be checked until it has been looked up.</para>
        /// <para>The hyperparameters keep their defaults (150 epochs, patience 50, imgsz 640, batch 16, seed 0, AMP on) and are set on the returned options; <see cref="Modify.Train(Classes.YOLOTrainingOptions?, System.Threading.CancellationToken)"/> rejects values that cannot make a run. <see cref="Classes.YOLOTrainingOptions.Project"/> is set to the "runs\detect" folder of the working directory, always absolute.</para>
        /// </summary>
        /// <param name="pythonPath">The path of the CPython interpreter, or the name of one on PATH. Null searches PATH.</param>
        /// <param name="modelPath">The path of the start weights: an existing .pt checkpoint or .yaml architecture definition.</param>
        /// <param name="configurationFilePath">The path of the dataset configuration file (conf.yaml).</param>
        /// <param name="workingDirectory">The directory the process runs in and the scripts are kept in. Null uses the directory holding the configuration file.</param>
        /// <returns>The options, or <c>null</c> when no interpreter was found, the configuration file does not exist, or the start file does not exist or is neither a .pt nor a .yaml file.</returns>
        public static YOLOTrainingOptions? YOLOTrainingOptions(string? pythonPath, string? modelPath, string? configurationFilePath, string? workingDirectory = null)
        {
            string? pythonPath_Resolved = Python.Query.PythonPath(pythonPath);
            string? modelPath_Resolved = Python.Query.NormalizedPath(modelPath);
            string? configurationFilePath_Resolved = Python.Query.NormalizedPath(configurationFilePath);

            if (string.IsNullOrWhiteSpace(pythonPath_Resolved))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(modelPath_Resolved) || !File.Exists(modelPath_Resolved) || Query.ModelKind(modelPath_Resolved) == Enums.ModelKind.Undefined)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(configurationFilePath_Resolved) || !File.Exists(configurationFilePath_Resolved))
            {
                return null;
            }

            //Derived only once the configuration file is known to be there, because Path.GetDirectoryName throws on a null argument outside .NET Core
            string? workingDirectory_Resolved = Python.Query.NormalizedPath(workingDirectory) ?? Python.Query.NormalizedPath(Path.GetDirectoryName(configurationFilePath_Resolved));

            if (string.IsNullOrWhiteSpace(workingDirectory_Resolved))
            {
                return null;
            }

            return new YOLOTrainingOptions()
            {
                ConfigurationFilePath = configurationFilePath_Resolved,
                ModelPath = modelPath_Resolved,
                Project = Path.Combine(workingDirectory_Resolved, "runs", "detect"),
                PythonPath = pythonPath_Resolved,
                WorkingDirectory = workingDirectory_Resolved
            };
        }
    }
}
