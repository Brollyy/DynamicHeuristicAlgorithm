using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DynamicHeuristicAlgorithm.Utils
{

    public static class Logger
    {
        private enum LogLevel
        {
            NONE = 0,
            DEBUG,
            INFO,
            ERROR
        }

        private static LogLevel logLevel = LogLevel.NONE;
        private static string logFilename = null;
        private static StreamWriter allLogTarget = null;
        private static Encoding allLogEncoding; // UTF8 default
        private static readonly int MAX_LOG_FILES = 10;
        private static long MAX_LOG_LENGTH = 0;  // 100MB default

        public static void Initialize(int logLevel, string allLogFilename, long allLogFilesize = 0, Encoding allLogEncoding = null)
        {
            Logger.logLevel = (LogLevel)logLevel;
            Logger.logFilename = allLogFilename;
            Logger.MAX_LOG_LENGTH = allLogFilesize > 0 ? allLogFilesize : 100L * 1024L * 1024L;
            Logger.allLogEncoding = allLogEncoding == null ? UnicodeEncoding.UTF8 : allLogEncoding;
            OpenLogFile();
        }

        private static bool OpenLogFile()
        {
            if(logFilename == null)
            {
                LogExternal(LogLevel.ERROR, "Can't open log, file not specified.");
                return false;
            }

            for(int i = 0; i < MAX_LOG_FILES; ++i)
            {
                try
                {
                    Logger.allLogTarget = new StreamWriter(logFilename + i, true, allLogEncoding);
                    checkFileForWrite();
                    return true;
                }
                catch (Exception e)
                {
                    if(e is IOException || e is DirectoryNotFoundException)
                    {
                        LogExternal(LogLevel.ERROR, e.Message);
                    }
                    Logger.allLogTarget = null;
                }
            }
            LogExternal(LogLevel.ERROR, "Can't open log file at" + new DirectoryInfo(logFilename).Parent.FullName);
            return false;
        }

        private static void Log(LogLevel logLevel, string message)
        {
            string logMessage = "[" + DateTime.Now.ToString() + " " + logLevel.ToString() + "]: " + message;
            LogExternal(logLevel, logMessage);
            LogInternal(logLevel, logMessage);
        }

        private static void LogInternal(LogLevel logLevel, string message)
        {
            if (allLogTarget != null)
            {
                try
                {
                    checkFileForWrite();
                }
                catch (FileFullException e)
                {
                    Dispose();
                    OpenLogFile();
                    if (allLogTarget == null)
                    {
                        return;
                    }
                }
                allLogTarget.WriteLine(message);
            }
        }

        private static void LogExternal(LogLevel logLevel, string message)
        {
            if (logLevel >= Logger.logLevel)
            {
                Console.WriteLine(message);
            }
        }

        private static void checkFileForWrite()
        {
            if(allLogTarget.BaseStream.Length > MAX_LOG_LENGTH)
            {
                throw new FileFullException("File's size exceeded maximum size of " + MAX_LOG_LENGTH + ".");
            }
        }

        public static void LogInfo(string message)
        {
            Log(LogLevel.INFO, message);
        }

        public static void LogDebug(string message)
        {
            Log(LogLevel.DEBUG, message);
        }

        public static void LogError(string message)
        {
            Log(LogLevel.ERROR, message);
        }

        public static void LogError(Exception ex)
        {
            string header = "[" + DateTime.Now.ToString() + " ERROR]: ";
            LogExternal(LogLevel.ERROR, header + ex.Message);
            LogInternal(LogLevel.ERROR, header + ex.GetType().Name + ": " + ex.Message + "\n" + ex.StackTrace);
        }

        public static void Dispose()
        {
            if(allLogTarget != null)
            {
                allLogTarget.Flush();
                allLogTarget.Close();
                allLogTarget.Dispose();
            }
        }

        public static void PurgeAllLogs()
        {
            Dispose();
            foreach(string file in Directory.GetFiles(new DirectoryInfo(logFilename).Parent.FullName))
            {
                File.Delete(file);
                LogExternal(LogLevel.INFO, "Deleted file " + file + ".");
            }
            Array.ForEach(Directory.GetFiles(new DirectoryInfo(logFilename).Parent.FullName), File.Delete);
            OpenLogFile();
        }

        private class FileFullException : Exception
        {
            public FileFullException(string message) : base(message)
            {
            }
        }
    }
}
