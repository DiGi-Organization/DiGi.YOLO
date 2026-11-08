namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Decodes a YAML path value of an ultralytics dataset file: surrounding single or double quotes are removed, URL-encoded spaces written by earlier versions become spaces, and forward slashes become backslashes.
        /// </summary>
        /// <param name="path">The encoded path string to be decoded.</param>
        /// <returns>The decoded path string, or an empty string if the provided path is null or whitespace.</returns>
        public static string? Decode(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return string.Empty;
            }

            string result = path!.Trim();

            if (result.Length >= 2 && result.StartsWith("'", StringComparison.CurrentCulture) && result.EndsWith("'", StringComparison.CurrentCulture))
            {
                result = result.Substring(1, result.Length - 2).Replace("''", "'");
            }
            else if (result.Length >= 2 && result.StartsWith("\"", StringComparison.CurrentCulture) && result.EndsWith("\"", StringComparison.CurrentCulture))
            {
                result = result.Substring(1, result.Length - 2);
            }

            return result.Replace("%20", " ").Replace("/", @"\");
        }
    }
}