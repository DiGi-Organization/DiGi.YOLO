namespace DiGi.YOLO
{
    public static partial class Modify
    {
        /// <summary>
        /// Writes the YOLO Python runner scripts and configuration files into the specified directory.
        /// <para>The scripts ship inside this assembly, so this works in any host that loads it. A YOLO folder sitting beside the assembly is used in preference, which lets a script be edited in a build output and tried without rebuilding.</para>
        /// <para>predict.py, train.py and export.py import utils.py, and Python resolves that against the directory the script sits in, so the files are only useful written together.</para>
        /// <para>The scripts are always rewritten, so a directory never keeps running a script of an older build. The template conf.yaml is the exception: it is data rather than a script, so it is written only when the directory has none and never replaces the conf.yaml of a dataset written there.</para>
        /// <para>The files are written by <see cref="Python.Modify.WriteScripts(System.Reflection.Assembly, string, string, System.Collections.Generic.IEnumerable{string}, string?, System.Collections.Generic.IEnumerable{string}?)"/> from the resources of this assembly.</para>
        /// </summary>
        /// <param name="directory">The target directory path where scripts will be written.</param>
        /// <returns>True if every script file was written; otherwise, false.</returns>
        public static bool WriteScripts(string? directory)
        {
            string[] fileNames =
            [
                Constants.FileName.Train,
                Constants.FileName.Validate,
                Constants.FileName.Predict,
                Constants.FileName.Check,
                Constants.FileName.Checkpoint,
                Constants.FileName.Export,
                Constants.FileName.Utils,
                Constants.FileName.Requirements,
                Constants.FileName.Conf
            ];

            //The template would otherwise replace the conf.yaml describing the dataset in this directory - every dataset written by Modify.Write lost its labels and absolute path that way
            return Python.Modify.WriteScripts(typeof(Query).Assembly, string.Format("{0}.{1}.", typeof(Query).Namespace, Constants.DirectoryName.YOLO), Constants.DirectoryName.YOLO, fileNames, directory, [Constants.FileName.Conf]);
        }
    }
}
