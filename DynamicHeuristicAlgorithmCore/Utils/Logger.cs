﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace DynamicHeuristicAlgorithmCore.Utils
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
        private static StreamWriter errorLogTarget = null;
        private static Dictionary<int, StreamWriter> threadsLogTargets = new Dictionary<int, StreamWriter>(); 
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
            OpenErrorLogFile();
        }

        private static bool OpenLogFile()
        {
            if(logFilename == null)
            {
                LogExternal(LogLevel.ERROR, "Can't open log, file path not specified.");
                return false;
            }

            for(int i = 0; i < MAX_LOG_FILES; ++i)
            {
                try
                {
                    Logger.allLogTarget = new StreamWriter(logFilename + i, true, allLogEncoding);
                    checkFileForWrite(allLogTarget);
                    return true;
                }
                catch (Exception e)
                {
                    if(e is IOException || e is DirectoryNotFoundException)
                    {
                        LogExternal(LogLevel.ERROR, e.Message);
                        LogInternalError(e.Message);
                    }
                    allLogTarget.Close();
                    allLogTarget.Dispose();
                    Logger.allLogTarget = null;
                }
            }
            LogExternal(LogLevel.ERROR, "Can't open log file at" + new DirectoryInfo(logFilename).Parent.FullName);
            LogInternalError("Can't open log file at" + new DirectoryInfo(logFilename).Parent.FullName);
            return false;
        }

        private static bool OpenThreadLogFile(int threadId)
        {
            if(logFilename == null)
            {
                LogExternal(LogLevel.ERROR, "Can't open thread log, file path not specified.");
                return false;
            }

            try
            {
                StreamWriter threadLog = new StreamWriter(logFilename + "Thread" + threadId, true, allLogEncoding);
                checkFileForWrite(threadLog);
                threadsLogTargets.Add(threadId, threadLog);
                return true;
            }
            catch (Exception e)
            {
                if (e is IOException || e is DirectoryNotFoundException)
                {
                    LogExternal(LogLevel.ERROR, e.Message);
                    LogInternalError(e.Message);
                }
            }
            LogExternal(LogLevel.ERROR, "Can't open thread log file at" + new DirectoryInfo(logFilename).Parent.FullName);
            LogInternalError("Can't open thread log file at" + new DirectoryInfo(logFilename).Parent.FullName);
            return false;
        }

        private static bool OpenErrorLogFile()
        {
            try
            {
                Logger.errorLogTarget = new StreamWriter(logFilename + "Error", true, allLogEncoding);
                return true;
            }
            catch (Exception e)
            {
                if (e is IOException || e is DirectoryNotFoundException)
                {
                    LogExternal(LogLevel.ERROR, e.Message);
                }
                Logger.errorLogTarget = null;
                return false;
            }
        }

        private static void Log(LogLevel logLevel, string message)
        {
            string logMessage = "[" + DateTime.Now.ToString() + " " + logLevel.ToString() + "]: " + message;
            LogExternal(logLevel, logMessage);
            LogInternal(logLevel, logMessage);
            LogInternalThread(logLevel, logMessage);
            if (logLevel == LogLevel.ERROR)
            {
                LogInternalError(logMessage);
            }
        }

        private static void LogInternalError(string logMessage)
        {
            if(errorLogTarget != null)
            {
                errorLogTarget.WriteLine(logMessage);
                errorLogTarget.Flush();
            }
        }

        private static void LogInternal(LogLevel logLevel, string message)
        {
            if (allLogTarget != null)
            {
                try
                {
                    checkFileForWrite(allLogTarget);
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

        private static void LogInternalThread(LogLevel logLevel, string message)
        {
            if(Thread.CurrentThread.IsBackground)
            {
                int threadId = Thread.CurrentThread.ManagedThreadId;
                if(!threadsLogTargets.ContainsKey(threadId))
                {
                    OpenThreadLogFile(threadId);
                }

                try
                {
                    checkFileForWrite(threadsLogTargets[threadId]);
                }
                catch (FileFullException e)
                {
                    return;
                }
                threadsLogTargets[threadId].WriteLine(message);
            }
        }

        private static void LogExternal(LogLevel logLevel, string message)
        {
            if (logLevel >= Logger.logLevel)
            {
                Console.WriteLine(message);
            }
        }

        private static void checkFileForWrite(StreamWriter logTarget)
        {
            if(logTarget.BaseStream.Length > MAX_LOG_LENGTH)
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
            FlushAllLogs();
        }

        public static void LogError(Exception ex)
        {
            string header = "[" + DateTime.Now.ToString() + " ERROR]: ";
            LogExternal(LogLevel.ERROR, header + ex.Message);
            LogInternal(LogLevel.ERROR, header + ex.GetType().Name + ": " + ex.Message + "\n" + ex.StackTrace);
            LogInternalThread(LogLevel.ERROR, header + ex.GetType().Name + ": " + ex.Message + "\n" + ex.StackTrace);
            LogInternalError(header + ex.GetType().Name + ": " + ex.Message + "\n" + ex.StackTrace);
            FlushAllLogs();
        }

        public static void Dispose()
        {
            if(allLogTarget != null)
            {
                allLogTarget.Flush();
                allLogTarget.Close();
                allLogTarget.Dispose();
            }

            foreach(KeyValuePair<int, StreamWriter> threadLogTarget in threadsLogTargets)
            {
                threadLogTarget.Value.Flush();
                threadLogTarget.Value.Close();
                threadLogTarget.Value.Dispose();
            }
            threadsLogTargets.Clear();
        }

        public static void DisposeError()
        {
            if(errorLogTarget != null)
            {
                errorLogTarget.Flush();
                errorLogTarget.Close();
                errorLogTarget.Dispose();
            }
        }

        public static void PurgeAllLogs()
        {
            Dispose();
            DisposeError();
            Array.ForEach(Directory.GetFiles(new DirectoryInfo(logFilename).Parent.FullName), File.Delete);
            OpenLogFile();
            OpenErrorLogFile();
        }

        public static string LoggerPath
        {
            get
            {
                string path = logFilename;
                string replaced = path;
                do
                {
                    path = replaced;
                    replaced = path.Replace("\\\\", "\\");
                }
                while (!path.Equals(replaced));
                return path.Replace("\\log","");
            }
        }

        public static void FlushAllLogs()
        {
            if (allLogTarget != null)
            {
                allLogTarget.Flush();
            }
        }

        private class FileFullException : Exception
        {
            public FileFullException(string message) : base(message)
            {
            }
        }
    }
}
