using DiGi.YOLO.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Represents the configuration settings for a YOLO project, including directory paths and labels.
    /// </summary>
    public class ConfigurationFile
    {
        private readonly string? directory;
        private readonly Dictionary<Category, string?> directoryNames = [];
        private readonly HashSet<Label> labels = [];
        private readonly List<string>? messages;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFile"/> class.
        /// </summary>
        public ConfigurationFile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFile"/> class with specified directory paths and labels.
        /// </summary>
        /// <param name="directory">The base root directory path.</param>
        /// <param name="trainDirectoryName">The relative name of the training directory.</param>
        /// <param name="validateDirectoryName">The relative name of the validation directory.</param>
        /// <param name="testDirectoryName">The relative name of the test directory.</param>
        /// <param name="labels">A collection of labels to be associated with this configuration.</param>
        public ConfigurationFile(string? directory, string? trainDirectoryName, string? validateDirectoryName, string? testDirectoryName, IEnumerable<Label>? labels)
            : this(directory, trainDirectoryName, validateDirectoryName, testDirectoryName, labels, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFile"/> class with specified directory paths, labels and the messages reading the file produced.
        /// </summary>
        /// <param name="directory">The base root directory path.</param>
        /// <param name="trainDirectoryName">The relative name of the training directory.</param>
        /// <param name="validateDirectoryName">The relative name of the validation directory.</param>
        /// <param name="testDirectoryName">The relative name of the test directory.</param>
        /// <param name="labels">A collection of labels to be associated with this configuration.</param>
        /// <param name="messages">The messages reading the file produced, such as a fall-back of the base directory, or <c>null</c> when there were none.</param>
        public ConfigurationFile(string? directory, string? trainDirectoryName, string? validateDirectoryName, string? testDirectoryName, IEnumerable<Label>? labels, IEnumerable<string>? messages)
        {
            this.messages = messages == null ? null : [.. messages];

            this.directory = directory;

            directoryNames[Category.Train] = trainDirectoryName;
            directoryNames[Category.Validate] = validateDirectoryName;
            directoryNames[Category.Test] = testDirectoryName;

            if (labels != null)
            {
                foreach (Label label in labels)
                {
                    if (label == null)
                    {
                        continue;
                    }

                    this.labels.Add(label);
                }
            }
        }

        /// <summary>
        /// Gets the base root directory path.
        /// </summary>
        public string? Directory
        {
            get
            {
                return directory;
            }
        }

        /// <summary>
        /// Retrieves all categories defined within the configuration.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="Category"/> values.</returns>
        public IEnumerable<Category> GetCategories()
        {
            return directoryNames.Keys;
        }

        /// <summary>
        /// Gets the full combined path for a specific category.
        /// </summary>
        /// <param name="category">The category for which to retrieve the full directory path.</param>
        /// <returns>The absolute path combining the base directory and the category folder, or <see langword="null"/> if not found or empty.</returns>
        public string? GetDirectory(Category category)
        {
            if (!directoryNames.TryGetValue(category, out string? directoryNames_Temp) || string.IsNullOrWhiteSpace(directoryNames_Temp))
            {
                return null;
            }

            return System.IO.Path.Combine(directory, directoryNames_Temp);
        }

        /// <summary>
        /// Gets the relative directory name for a specific category.
        /// </summary>
        /// <param name="category">The category for which to retrieve the folder name.</param>
        /// <returns>The relative directory name, or <see langword="null"/> if not found or empty.</returns>
        public string? GetDirectoryNames(Category category)
        {
            if (!directoryNames.TryGetValue(category, out string? result) || string.IsNullOrWhiteSpace(result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Gets the collection of labels associated with this configuration.
        /// </summary>
        public IEnumerable<Label> Labels
        {
            get
            {
                return labels;
            }
        }

        /// <summary>
        /// Gets the messages reading the file produced, such as a base directory that did not exist and was replaced by the directory of the file, or <c>null</c> when there were none.
        /// </summary>
        public List<string>? Messages
        {
            get
            {
                return messages;
            }
        }

        /// <summary>
        /// Returns a string representation of the configuration file, formatted for output or storage.
        /// </summary>
        /// <returns>A formatted string containing the base path, category paths, and label names.</returns>
        public override string? ToString()
        {
            List<string> values = [string.Format(CultureInfo.CurrentCulture, "path: {0}", Query.Encode(directory))];
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                if (!directoryNames.TryGetValue(category, out string? directoryName))
                {
                    directoryName = string.Empty;
                }

                values.Add(string.Format(CultureInfo.CurrentCulture, "{0}: {1}", category.DirectoryName(), Query.Encode(directoryName)));
            }

            values.Add("names:");
            foreach (Label label in labels)
            {
                if (label == null)
                {
                    continue;
                }
                values.Add(string.Format(CultureInfo.CurrentCulture, "   {0}", label.ToString()));
            }

            return string.Join(Environment.NewLine, values);
        }
    }
}