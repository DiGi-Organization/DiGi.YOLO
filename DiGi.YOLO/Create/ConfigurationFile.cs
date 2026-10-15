using DiGi.YOLO.Classes;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        /// <summary>
        /// Parses an ultralytics dataset file (conf.yaml) from the specified path and creates a <see cref="ConfigurationFile"/> instance.
        /// <para>The file is read key by key. Blank lines, comment lines and trailing " #" comments are skipped. The label block after "names:" ends at the first line that is not an "&lt;int&gt;: &lt;name&gt;" entry, and a file without "names:" has no labels.</para>
        /// <para>The "path:" value is resolved against the directory of the file rather than against the current directory: a missing value means that directory, a relative value is combined with it. When the resolved directory does not exist - typically an absolute path written on another machine - the directory of the file is used instead and <see cref="ConfigurationFile.Messages"/> says so, because the images would otherwise read as none at all with no error.</para>
        /// </summary>
        /// <param name="path">The file system path to the configuration file.</param>
        /// <returns>A <see cref="ConfigurationFile"/> object if the file exists and is successfully parsed; otherwise, <c>null</c>.</returns>
        public static ConfigurationFile? ConfigurationFile(string? path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            List<string> values = [.. File.ReadAllLines(path)];
            if (values == null || values.Count == 0)
            {
                return null;
            }

            //A value is everything after the first colon, without a trailing comment; a quoted value keeps what it quotes
            static string Value(string value)
            {
                string result = value.Trim();
                if (result.StartsWith("'") || result.StartsWith("\""))
                {
                    return result;
                }

                int index = result.IndexOf(" #");
                return index < 0 ? result : result.Substring(0, index).TrimEnd();
            }

            string? directory = null;
            string? trainDirectoryName = null;
            string? validateDirectoryName = null;
            string? testDirectoryName = null;
            List<Label> labels = [];

            bool names = false;

            foreach (string line in values)
            {
                string value = line.Trim();

                if (value.Length == 0 || value.StartsWith("#"))
                {
                    continue;
                }

                int index = value.IndexOf(':');
                if (index < 1)
                {
                    names = false;
                    continue;
                }

                string key = value.Substring(0, index).Trim();
                string value_Key = Value(value.Substring(index + 1));

                if (names)
                {
                    if (int.TryParse(key, NumberStyles.Integer, CultureInfo.InvariantCulture, out int labelIndex))
                    {
                        string name = value_Key;
                        if (name.Length >= 2 && ((name.StartsWith("'") && name.EndsWith("'")) || (name.StartsWith("\"") && name.EndsWith("\""))))
                        {
                            name = name.Substring(1, name.Length - 2);
                        }

                        labels.Add(new Label(labelIndex, name));
                        continue;
                    }

                    names = false;
                }

                if (key == "path")
                {
                    directory = Query.Decode(value_Key);
                }
                else if (key == Query.DirectoryName(Enums.Category.Validate))
                {
                    validateDirectoryName = Query.Decode(value_Key);
                }
                else if (key == Query.DirectoryName(Enums.Category.Train))
                {
                    trainDirectoryName = Query.Decode(value_Key);
                }
                else if (key == Query.DirectoryName(Enums.Category.Test))
                {
                    testDirectoryName = Query.Decode(value_Key);
                }
                else if (key == "names")
                {
                    names = true;
                }
            }

            List<string>? messages = null;

            string? directory_File = Path.GetDirectoryName(Path.GetFullPath(path));
            if (!string.IsNullOrWhiteSpace(directory_File))
            {
                string? directory_Resolved = string.IsNullOrWhiteSpace(directory) ? directory_File : Python.Query.NormalizedPath(Path.Combine(directory_File, directory));
                if (string.IsNullOrWhiteSpace(directory_Resolved) || !Directory.Exists(directory_Resolved))
                {
                    messages = [string.Format("Dataset directory '{0}' does not exist; the directory of the configuration file '{1}' is used instead.", directory_Resolved ?? directory, directory_File)];
                    directory_Resolved = directory_File;
                }

                directory = directory_Resolved;
            }

            return new ConfigurationFile(directory, trainDirectoryName, validateDirectoryName, testDirectoryName, labels, messages);
        }
    }
}
