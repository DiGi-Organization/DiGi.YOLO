namespace DiGi.YOLO.Constants
{
    /// <summary>
    /// Provides the line prefixes the training and validation scripts print their results under, shared by the scripts' output contract and the parsers that read it back.
    /// </summary>
    public static class OutputPrefix
    {
        /// <summary>
        /// The prefix of the line train.py prints the path of the best weights file under.
        /// </summary>
        public const string Weights = "Weights:";

        /// <summary>
        /// The prefix of the line train.py and export.py print the size of the written file under, in bytes.
        /// </summary>
        public const string Bytes = "Bytes:";

        /// <summary>
        /// The prefix of the line train.py and export.py print the lowercase hexadecimal SHA-256 digest of the written file under.
        /// </summary>
        public const string SHA256 = "SHA256:";

        /// <summary>
        /// The prefix of the line train.py prints the automatic mixed precision actually used under, True or False.
        /// </summary>
        public const string AMP = "AMP:";

        /// <summary>
        /// The prefix of the line train.py prints, before a resumed run and again in its success block, the 1-based epoch training resumes into under.
        /// <para>Printed in both places because the start of a long run is evicted from the tail <see cref="Python.Query.ExecuteProcess(string, string, string, System.Collections.Generic.Dictionary{string, string}?, System.Threading.CancellationToken)"/> keeps, so only the success block copy survives for the parser.</para>
        /// </summary>
        public const string ResumeEpoch = "Resume epoch:";

        /// <summary>
        /// The prefix of the line train.py prints, before a resumed run and again in its success block, the epoch ceiling restored from the checkpoint under.
        /// <para>The ceiling is fixed by the checkpoint; a different one is a new run, not a resume.</para>
        /// </summary>
        public const string ResumeEpochs = "Resume epochs:";

        /// <summary>
        /// The prefix of the line val.py prints the box mAP at IoU 0.5 under.
        /// </summary>
        public const string MAP50 = "mAP50:";

        /// <summary>
        /// The prefix of the line val.py prints the box mAP averaged over IoU 0.5 to 0.95 under.
        /// </summary>
        public const string MAP50_95 = "mAP50-95:";
    }
}
