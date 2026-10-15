using DiGi.Core.Classes;
using DiGi.YOLO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Represents what one run of the YOLO prediction script did: how it ended, what it said, and the result lines it produced.
    /// <para>The detections are kept as the raw lines of the bounding box result file rather than as parsed objects, so that a result read back from JSON is the same result that was written. Parse them with <see cref="Create.BoundingBoxResultFile(YOLOPredictionResult?)"/>.</para>
    /// </summary>
    public class YOLOPredictionResult : SerializableResult, IYOLOSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(End))]
        private readonly DateTimeOffset? end;

        [JsonInclude, JsonPropertyName(nameof(ExitCode))]
        private readonly int exitCode;

        [JsonInclude, JsonPropertyName(nameof(ImageCount))]
        private readonly int imageCount;

        [JsonInclude, JsonPropertyName(nameof(OutputPath))]
        private readonly string? outputPath;

        [JsonInclude, JsonPropertyName(nameof(StandardError))]
        private readonly List<string>? standardError;

        [JsonInclude, JsonPropertyName(nameof(StandardOutput))]
        private readonly List<string>? standardOutput;

        [JsonInclude, JsonPropertyName(nameof(Start))]
        private readonly DateTimeOffset? start;

        [JsonInclude, JsonPropertyName(nameof(Values))]
        private readonly List<string>? values;

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOPredictionResult"/> class.
        /// </summary>
        /// <param name="exitCode">The code the prediction process ended with, or -1 when the runner never got one.</param>
        /// <param name="imageCount">The number of images found in the source directory.</param>
        /// <param name="outputPath">The path of the bounding box result file the run was told to write.</param>
        /// <param name="values">The lines of the bounding box result file the run produced.</param>
        /// <param name="standardOutput">The trailing lines the process wrote to its standard output stream.</param>
        /// <param name="standardError">The trailing lines the process wrote to its standard error stream.</param>
        /// <param name="start">The moment the run began.</param>
        /// <param name="end">The moment the run ended.</param>
        public YOLOPredictionResult(
            int exitCode,
            int imageCount,
            string? outputPath,
            IEnumerable<string>? values,
            IEnumerable<string>? standardOutput,
            IEnumerable<string>? standardError,
            DateTimeOffset? start,
            DateTimeOffset? end)
        {
            this.exitCode = exitCode;
            this.imageCount = imageCount;
            this.outputPath = outputPath;
            this.values = values == null ? null : [.. values];
            this.standardOutput = standardOutput == null ? null : [.. standardOutput];
            this.standardError = standardError == null ? null : [.. standardError];
            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOPredictionResult"/> class by copying an existing result.
        /// </summary>
        /// <param name="yOLOPredictionResult">The source result to copy from.</param>
        public YOLOPredictionResult(YOLOPredictionResult? yOLOPredictionResult)
            : base(yOLOPredictionResult)
        {
            if (yOLOPredictionResult != null)
            {
                end = yOLOPredictionResult.end;
                exitCode = yOLOPredictionResult.exitCode;
                imageCount = yOLOPredictionResult.imageCount;
                outputPath = yOLOPredictionResult.outputPath;
                standardError = yOLOPredictionResult.standardError == null ? null : [.. yOLOPredictionResult.standardError];
                standardOutput = yOLOPredictionResult.standardOutput == null ? null : [.. yOLOPredictionResult.standardOutput];
                start = yOLOPredictionResult.start;
                values = yOLOPredictionResult.values == null ? null : [.. yOLOPredictionResult.values];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOPredictionResult"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the result data.</param>
        public YOLOPredictionResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets how long the run took, or <c>null</c> when either end of it is unknown.
        /// </summary>
        [JsonIgnore]
        public TimeSpan? Duration
        {
            get
            {
                if (start == null || end == null)
                {
                    return null;
                }

                return end.Value - start.Value;
            }
        }

        /// <summary>
        /// Gets the moment the run ended.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? End
        {
            get
            {
                return end;
            }
        }

        /// <summary>
        /// Gets the code the prediction process ended with. Zero means it ran to completion.
        /// <para>-1 is the runner's own code for a run it never handed to the interpreter or took back from it - the process could not be started, the source directory was gone, or the run was cancelled. <see cref="StandardError"/> carries the reason in the first two cases; a caller that cancelled already knows about the third.</para>
        /// </summary>
        [JsonIgnore]
        public int ExitCode
        {
            get
            {
                return exitCode;
            }
        }

        /// <summary>
        /// Gets the number of images found in the source directory.
        /// <para>Zero here with an exit code of zero is a run that had nothing to do, which is worth telling apart from a run that scored images and found nothing on them.</para>
        /// </summary>
        [JsonIgnore]
        public int ImageCount
        {
            get
            {
                return imageCount;
            }
        }

        /// <summary>
        /// Gets the path of the bounding box result file the run was told to write.
        /// </summary>
        [JsonIgnore]
        public string? OutputPath
        {
            get
            {
                return outputPath;
            }
        }

        /// <summary>
        /// Gets the trailing lines the process wrote to its standard error stream, at most <see cref="Python.Constants.Count.OutputLines"/> of them.
        /// </summary>
        [JsonIgnore]
        public List<string>? StandardError
        {
            get
            {
                return standardError;
            }
        }

        /// <summary>
        /// Gets the trailing lines the process wrote to its standard output stream, at most <see cref="Python.Constants.Count.OutputLines"/> of them.
        /// </summary>
        [JsonIgnore]
        public List<string>? StandardOutput
        {
            get
            {
                return standardOutput;
            }
        }

        /// <summary>
        /// Gets the moment the run began.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? Start
        {
            get
            {
                return start;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the run completed and produced its result file.
        /// </summary>
        [JsonIgnore]
        public bool Succeeded
        {
            get
            {
                return exitCode == 0 && values != null;
            }
        }

        /// <summary>
        /// Gets the lines of the bounding box result file the run produced, or <c>null</c> when it produced none.
        /// <para>An empty list is a run that scored images and detected nothing; <c>null</c> is a run that wrote no file at all.</para>
        /// </summary>
        [JsonIgnore]
        public List<string>? Values
        {
            get
            {
                return values;
            }
        }
    }
}