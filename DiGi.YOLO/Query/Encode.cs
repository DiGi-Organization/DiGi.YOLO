namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Encodes a path as a YAML value of an ultralytics dataset file: backslashes become forward slashes, and the value is single-quoted when YAML would otherwise read part of it as a comment or a mapping.
        /// <para>Spaces are kept as they are. ultralytics hands the value to the file system unchanged, so a "%20" written here would name a directory that does not exist - every path under "user files" did. <see cref="Decode(string?)"/> still reads "%20" in files written before this change.</para>
        /// </summary>
        /// <param name="path">The path string to be encoded. This value can be null.</param>
        /// <returns>An encoded version of the path, or an empty string if the provided path is null or whitespace.</returns>
        public static string Encode(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return string.Empty;
            }

            string result = path!.Replace(@"\", "/");

            //" #" starts a comment and ": " a mapping in a plain YAML scalar; a leading quote or space would change how the scalar is read
            if (result.Contains(" #") || result.Contains(": ") || result.StartsWith(" ", StringComparison.CurrentCulture) || result.EndsWith(" ", StringComparison.CurrentCulture) || result.StartsWith("'", StringComparison.CurrentCulture) || result.StartsWith("\"", StringComparison.CurrentCulture))
            {
                result = string.Concat("'", result.Replace("'", "''"), "'");
            }

            return result;
        }
    }
}