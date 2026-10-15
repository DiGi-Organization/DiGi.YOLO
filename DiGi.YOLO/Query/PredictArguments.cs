using DiGi.YOLO.Classes;
using System.Globalization;
using System.IO;
using System.Text;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Builds the command line arguments that run predict.py for the given options: the script path followed by its flags.
        /// <para>The paths are taken as given, so pass options whose paths are already resolved - <see cref="Modify.Predict(YOLOPredictionOptions?, System.Threading.CancellationToken)"/> does. Numbers are written in the invariant culture, because argparse parses them with float() and int(), which read a decimal point and nothing else.</para>
        /// <para>The settings that change the detections are passed only when asked for: --imgsz only for a positive multiple of 32, --half only when on. Without them the model is called exactly as earlier builds called it (DiGi-Organization/DiGi.YOLO#24). --workers is always passed, a negative value as 0, because it changes only the time a run takes. A batch size below one is passed as 32, the script's own default.</para>
        /// </summary>
        /// <param name="yOLOPredictionOptions">The options of the run.</param>
        /// <returns>The arguments, or <c>null</c> when the options are missing the weights, the source directory, the output path or the working directory.</returns>
        public static string? PredictArguments(this YOLOPredictionOptions? yOLOPredictionOptions)
        {
            if (yOLOPredictionOptions == null)
            {
                return null;
            }

            string? modelPath = yOLOPredictionOptions.ModelPath;
            string? sourceDirectory = yOLOPredictionOptions.SourceDirectory;
            string? outputPath = yOLOPredictionOptions.OutputPath;
            string? workingDirectory = yOLOPredictionOptions.WorkingDirectory;

            if (string.IsNullOrWhiteSpace(modelPath) || string.IsNullOrWhiteSpace(sourceDirectory) || string.IsNullOrWhiteSpace(outputPath) || string.IsNullOrWhiteSpace(workingDirectory))
            {
                return null;
            }

            static string Quoted(string? value)
            {
                return string.Concat("\"", value, "\"");
            }

            StringBuilder stringBuilder = new();
            stringBuilder.Append(Quoted(Path.Combine(workingDirectory, Constants.FileName.Predict)));
            stringBuilder.Append(" --model ").Append(Quoted(modelPath));
            stringBuilder.Append(" --source ").Append(Quoted(sourceDirectory));
            stringBuilder.Append(" --output ").Append(Quoted(outputPath));
            stringBuilder.Append(" --conf ").Append(yOLOPredictionOptions.Confidence.ToString("R", CultureInfo.InvariantCulture));

            int batchSize = yOLOPredictionOptions.BatchSize < 1 ? 32 : yOLOPredictionOptions.BatchSize;
            stringBuilder.Append(" --batch ").Append(batchSize.ToString(CultureInfo.InvariantCulture));

            if (yOLOPredictionOptions.ImageSize is int imageSize && imageSize > 0 && imageSize % 32 == 0)
            {
                stringBuilder.Append(" --imgsz ").Append(imageSize.ToString(CultureInfo.InvariantCulture));
            }

            if (yOLOPredictionOptions.HalfPrecision)
            {
                stringBuilder.Append(" --half");
            }

            int workers = yOLOPredictionOptions.Workers < 0 ? 0 : yOLOPredictionOptions.Workers;
            stringBuilder.Append(" --workers ").Append(workers.ToString(CultureInfo.InvariantCulture));

            return stringBuilder.ToString();
        }
    }
}
