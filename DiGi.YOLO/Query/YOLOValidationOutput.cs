using System.Collections.Generic;
using System.Globalization;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Reads the box mAP values val.py prints at the end of a run from its standard output.
        /// <para>The output is scanned from the end and the last line under each prefix wins. Values are read with the invariant culture - Python prints a decimal point whatever the machine's culture - and a value outside [0, 1] is rejected.</para>
        /// </summary>
        /// <param name="standardOutput">The lines val.py wrote to standard output.</param>
        /// <returns>The mAP at IoU 0.5 and the mAP averaged over IoU 0.5 to 0.95; each is <c>null</c> when its line is missing or cannot be read.</returns>
        public static (double? MAP50, double? MAP50_95) YOLOValidationOutput(IEnumerable<string>? standardOutput)
        {
            double? mAP50 = null;
            double? mAP50_95 = null;

            if (standardOutput == null)
            {
                return (mAP50, mAP50_95);
            }

            static double? Value(string value)
            {
                if (!double.TryParse(value.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double result))
                {
                    return null;
                }

                if (double.IsNaN(result) || result < 0 || result > 1)
                {
                    return null;
                }

                return result;
            }

            List<string> lines = [.. standardOutput];

            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string? line = lines[i]?.Trim();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                //"mAP50:" is not a prefix of "mAP50-95:", so the two lines cannot be confused
                if (mAP50 == null && line!.StartsWith(Constants.OutputPrefix.MAP50, StringComparison.CurrentCulture))
                {
                    mAP50 = Value(line.Substring(Constants.OutputPrefix.MAP50.Length));
                }
                else if (mAP50_95 == null && line!.StartsWith(Constants.OutputPrefix.MAP50_95, StringComparison.CurrentCulture))
                {
                    mAP50_95 = Value(line.Substring(Constants.OutputPrefix.MAP50_95.Length));
                }

                if (mAP50 != null && mAP50_95 != null)
                {
                    break;
                }
            }

            return (mAP50, mAP50_95);
        }
    }
}
