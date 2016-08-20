using System;
using System.IO;

namespace SuperReaperLib
{
    // TODO : Make adding a backslash to the file location automatic if it is not present.

    /// <summary>
    /// To use the logger create a Static instance of it.
    /// </summary>
    public class Logger
    {

        private string fileName;
        private string fileLocation;

        /// <summary>
        /// This will set the name of the log and location for the log to be stored.
        /// </summary>
        /// <param name="fileName"> File extension not required but recommended. </param>
        /// <param name="fileLocation"> MUST END WITH A BACKSLASH. </param>
        public Logger(string fileName, string fileLocation)
        {
            this.fileName = fileName;
            this.fileLocation = fileLocation;
        }

        /// <summary>
        /// Used for logging exceptions the format will be "(date, time), exception.type exceptionPrecursor".
        /// </summary>
        /// <param name="exceptionPrecursor"></param>
        /// <param name="exception"></param>
        public void LogException(string exceptionPrecursor, Exception exception)
        {
            LogWriter(exception.GetType() + " : ", exceptionPrecursor + " " + exception.ToString());
        }

        /// <summary>
        /// Used to log standard information, the format will be "Log : data"
        /// </summary>
        /// <param name="data"></param>
        public void Log(string data)
        {
            LogWriter("Log : ", data);
        }

        private void LogWriter(string logType, string dataToLog)
        {
            try
            {
                StreamWriter file = new StreamWriter(fileLocation + fileName, true);

                file.WriteLine("(" + DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToShortTimeString() + ")" + " " + logType + dataToLog);

                file.Close();
            }
            catch (Exception e) { Console.WriteLine("Err Exception occured when writing to Log file so errm yeah..." + e); }
        }

        /// <summary>
        /// Used to delete the log.
        /// </summary>
        public void ClearLog()
        {
            File.Delete(fileLocation + fileName);
        }

        public string getFileLocation() { return fileLocation; }
        public string getFileName() { return fileName; }
        public string getFullFilePath() { return fileLocation + fileName; }
    }
}
