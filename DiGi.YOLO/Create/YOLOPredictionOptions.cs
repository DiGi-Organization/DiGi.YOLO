using DiGi.YOLO.Classes;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        /// <summary>
        /// Builds the options for one run of the YOLO prediction script, resolving the interpreter, normalizing the paths and then checking that the combination can actually make a run.
        /// <para>The <see cref="Classes.YOLOPredictionOptions"/> constructors only assign, so this is where the work belongs. It resolves first and validates afterwards, because the interpreter is usually given by name rather than by path and a name cannot be checked until it has been looked up.</para>
        /// <para>The working directory is not created here. It is created by <see cref="Modify.Predict(Classes.YOLOPredictionOptions?, System.Threading.CancellationToken)"/>, along with the scripts that have to sit in it.</para>
        /// </summary>
        /// <param name="pythonPath">The path of the CPython interpreter, or the name of one on PATH. Null searches PATH.</param>
        /// <param name="modelPath">The path of the trained weights file to score with.</param>
        /// <param name="sourceDirectory">The directory holding the images to score.</param>
        /// <param name="outputPath">The path of the bounding box result file to write.</param>
        /// <param name="workingDirectory">The directory the process runs in and the scripts are kept in. Null uses the directory holding the output file.</param>
        /// <param name="confidence">The confidence threshold a detection has to reach to be reported.</param>
        /// <returns>The options, or <c>null</c> when no interpreter was found, a required path is missing, or the confidence is not a value between zero and one.</returns>
        public static YOLOPredictionOptions? YOLOPredictionOptions(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, string? workingDirectory = null, double confidence = 0.1)
        {
            return YOLOPredictionOptions(pythonPath, modelPath, sourceDirectory, outputPath, workingDirectory, confidence, 32);
        }

        /// <summary>
        /// Builds the options for one run of the YOLO prediction script with a custom batch size, resolving the interpreter, normalizing the paths and then checking that the combination can actually make a run.
        /// <para>The <see cref="Classes.YOLOPredictionOptions"/> constructors only assign, so this is where the work belongs. It resolves first and validates afterwards, because the interpreter is usually given by name rather than by path and a name cannot be checked until it has been looked up.</para>
        /// <para>The working directory is not created here. It is created by <see cref="Modify.Predict(Classes.YOLOPredictionOptions?, System.Threading.CancellationToken)"/>, along with the scripts that have to sit in it.</para>
        /// </summary>
        /// <param name="pythonPath">The path of the CPython interpreter, or the name of one on PATH. Null searches PATH.</param>
        /// <param name="modelPath">The path of the trained weights file to score with.</param>
        /// <param name="sourceDirectory">The directory holding the images to score.</param>
        /// <param name="outputPath">The path of the bounding box result file to write.</param>
        /// <param name="workingDirectory">The directory the process runs in and the scripts are kept in. Null uses the directory holding the output file.</param>
        /// <param name="confidence">The confidence threshold a detection has to reach to be reported.</param>
        /// <param name="batchSize">The number of images passed to the model in a single inference batch.</param>
        /// <returns>The options, or <c>null</c> when no interpreter was found, a required path is missing, the confidence is not a value between zero and one, or the batch size is less than one.</returns>
        public static YOLOPredictionOptions? YOLOPredictionOptions(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, string? workingDirectory, double confidence, int batchSize)
        {
            string? pythonPath_Resolved = Python.Query.PythonPath(pythonPath);
            string? modelPath_Resolved = Python.Query.NormalizedPath(modelPath);
            string? sourceDirectory_Resolved = Python.Query.NormalizedPath(sourceDirectory);
            string? outputPath_Resolved = Python.Query.NormalizedPath(outputPath);

            if (string.IsNullOrWhiteSpace(pythonPath_Resolved))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(modelPath_Resolved) || !File.Exists(modelPath_Resolved))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(sourceDirectory_Resolved) || !Directory.Exists(sourceDirectory_Resolved))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(outputPath_Resolved))
            {
                return null;
            }

            //Derived only once the output path is known to be there, because Path.GetDirectoryName throws on a null argument outside .NET Core
            string? workingDirectory_Resolved = Python.Query.NormalizedPath(workingDirectory) ?? Python.Query.NormalizedPath(Path.GetDirectoryName(outputPath_Resolved));

            if (string.IsNullOrWhiteSpace(workingDirectory_Resolved))
            {
                return null;
            }

            if (double.IsNaN(confidence) || confidence < 0 || confidence > 1 || batchSize < 1)
            {
                return null;
            }

            return new YOLOPredictionOptions()
            {
                BatchSize = batchSize,
                Confidence = confidence,
                ModelPath = modelPath_Resolved,
                OutputPath = outputPath_Resolved,
                PythonPath = pythonPath_Resolved,
                SourceDirectory = sourceDirectory_Resolved,
                WorkingDirectory = workingDirectory_Resolved
            };
        }
    }
}