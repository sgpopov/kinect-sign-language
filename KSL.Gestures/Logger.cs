namespace KSL.Gestures.Logger
{
    using System;
    using System.IO;

    public sealed class Logger
    {
        private static string filePath = @"D:\log.txt";

        private static FileMode fileMode = FileMode.Append;

        private static FileAccess fileAccess = FileAccess.Write;

        private static readonly Logger instance = new Logger();

        static Logger() { }

        private Logger() { }

        public static Logger getInstance
        {
            get { return instance; }
        }

        public void logMessage(string message, errorFlag flag)
        {
            using (FileStream fs = new FileStream(filePath, fileMode, fileAccess))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                string text = String.Format("[{0}] {1} {2}", DateTime.Now, getErrorLogFlag(flag), message);
                sw.WriteLine(text);
            }
        }

        private static string getErrorLogFlag(errorFlag flag)
        {
            string errorDesc = String.Empty;

            switch (flag)
            {
                case errorFlag.SentenceBuilderState:
                    errorDesc = "Sentence builder state:";
                    break;
                case errorFlag.SentenceDetected:
                    errorDesc = "Detected:";
                    break;
                case errorFlag.WordDetected:
                    errorDesc = "Detected:";
                    break;
                case errorFlag.WordRemove:
                    errorDesc = "Removed:";
                    break;
                case errorFlag.WordAdded:
                    errorDesc = "Added:";
                    break;
                default:
                    errorDesc = "Uknown:";
                    break;
            }

            return errorDesc;
        }
    }

    public enum errorFlag
    {
        WordDetected,
        SentenceDetected,
        SentenceBuilderState,
        WordRemove,
        WordAdded
    }
}
