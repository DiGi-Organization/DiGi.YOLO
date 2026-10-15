using DiGi.YOLO.Classes;
using DiGi.YOLO.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiGi.YOLO
{
    public static partial class Modify
    {
        /// <summary>
        /// Writes the YOLO model data, including configuration files, images, and labels, to the filesystem.
        /// <para>The runner scripts are written first and the dataset's conf.yaml after them. The scripts include a template conf.yaml; <see cref="WriteScripts(string?)"/> no longer replaces an existing one, and writing the dataset's file last keeps it the file that counts either way.</para>
        /// <para>The "path:" of conf.yaml is written absolute, so ultralytics finds the images whatever directory it is started from rather than resolving the value against its own datasets directory.</para>
        /// </summary>
        /// <param name="yOLOModel">The YOLO model instance containing the data to be written.</param>
        /// <returns>True if the writing process was successful; otherwise, false.</returns>
        public static bool Write(this YOLOModel? yOLOModel)
        {
            if (yOLOModel == null || string.IsNullOrWhiteSpace(yOLOModel.Directory))
            {
                return false;
            }

            string? directory = Python.Query.NormalizedPath(yOLOModel.Directory);
            if (string.IsNullOrWhiteSpace(directory))
            {
                return false;
            }

            WriteScripts(directory);

            ConfigurationFile configurationFile_Model = yOLOModel.GetConfigurationFile() ?? new ConfigurationFile();

            ConfigurationFile configurationFile = new(
                directory,
                configurationFile_Model.GetDirectoryNames(Category.Train),
                configurationFile_Model.GetDirectoryNames(Category.Validate),
                configurationFile_Model.GetDirectoryNames(Category.Test),
                configurationFile_Model.Labels);

            File.WriteAllText(Path.Combine(directory, Constants.FileName.Conf), configurationFile.ToString());

            foreach (Category category in System.Enum.GetValues(typeof(Category)))
            {
                string? directory_Images = yOLOModel.GetDirectory_Images(directory, category);
                string? directory_Labels = yOLOModel.GetDirectory_Labels(directory, category);

                IEnumerable<Image> images = yOLOModel.GetImages(category);
                if (category == Category.Test && (images == null || images.Count() == 0))
                {
                    continue;
                }

                if (!Directory.Exists(directory_Images))
                {
                    Directory.CreateDirectory(directory_Images);
                }

                if (!Directory.Exists(directory_Labels))
                {
                    Directory.CreateDirectory(directory_Labels);
                }

                if (images == null || images.Count() == 0)
                {
                    continue;
                }

                foreach (Image image in images)
                {
                    string? path = image?.Path;
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        continue;
                    }

                    LabelFile? labelFile = yOLOModel.GetLabelFile(path) ?? new LabelFile();

                    string fileName_Image = Path.GetFileName(path);

                    string path_Image = Path.Combine(directory_Images, fileName_Image);

                    string path_Labels = Path.ChangeExtension(Path.Combine(directory_Labels, fileName_Image), ".txt");

                    //Compared as full paths: an image already saved in place under another spelling of the same path (relative, other casing) would otherwise be copied onto itself, which throws
                    if (!string.Equals(Python.Query.NormalizedPath(path), Python.Query.NormalizedPath(path_Image), System.StringComparison.OrdinalIgnoreCase))
                    {
                        File.Copy(path, path_Image, true);
                    }

                    File.WriteAllText(path_Labels, labelFile.ToString());
                }
            }

            return true;
        }

        /// <summary>
        /// Writes the contents of a bounding box result file to the specified file path.
        /// </summary>
        /// <param name="boundingBoxResultFile">The collection of bounding box results to write.</param>
        /// <param name="path">The destination file path where the results will be saved.</param>
        /// <returns>True if the file was written successfully; otherwise, false.</returns>
        public static bool Write(this BoundingBoxResultFile? boundingBoxResultFile, string? path)
        {
            if (boundingBoxResultFile == null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                return false;
            }

            List<string> values = [];
            foreach (BoundingBoxResult boundingBoxResult in boundingBoxResultFile)
            {
                string? value = boundingBoxResult?.ToString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }

                values.Add(value!);
            }

            File.WriteAllLines(path, values);
            return true;
        }
    }
}