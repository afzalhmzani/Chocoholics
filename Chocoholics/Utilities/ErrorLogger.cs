using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Chocoholics.Utilities
{
    public class ErrorLogger
    {
        private const string ERROR_LOG_BASE = @"C:\temp\errorlog.txt";
        private static int _logsCreated = 0;
        private static int _numTries = 0;
        private static string _currentPath = ERROR_LOG_BASE;

        public static string LogPath
        {
            get
            {
                return ERROR_LOG_BASE;
            }
        }
        public static void WriteError(string message)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(_currentPath, true))
                {
                    sr.WriteLine(message);
                }
            }
            catch (IOException)
            {
                _numTries++;
                if (_numTries <= 5)
                {
                    System.Threading.Thread.Sleep(10000);
                    WriteError(message);
                }
                else
                {
                    _currentPath = NextErrorLogPath();
                    WriteError(message);
                }
            }
            
        }

        private static string NextErrorLogPath()
        {
            _logsCreated++;

            // get just name
            string filename = _currentPath.Split('\\').Last();
            string name = filename.Split('.').First();

            // now trim the number off the end
            string numsRemoved = Regex.Match(name, @"^[^\d]+").Value;

            string newPath = ERROR_LOG_BASE.Trim('.').First() + numsRemoved + ".txt";
            return newPath;
        }

        /// <summary>
        /// Deletes the log file.
        /// </summary>
        public static void DeleteLog()
        {
            System.IO.File.Delete(ERROR_LOG_BASE);
        }

        /// <summary>
        /// Opens the log file in the default viewer.
        /// </summary>
        public static void OpenLog()
        {
            System.Diagnostics.Process.Start(ERROR_LOG_BASE);
        }
    }
}
