using _2048Core;
using DynamicHeuristicAlgorithmCore.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicHeuristicAlgorithm
{

    static class Program
    {

#if DEBUG
        static int logLevel = 1; // DEBUG
        static long logSize = 500L * 1024L * 1024L;
        static string logFileName = GetProjectFolderPath() + "\\\\Logs\\\\Debug\\\\log";
#else
        static int logLevel = 2; // INFO
        static long logSize = 100L * 1024L * 1024L;
        static string logFilePath = GetProjectFolderPath() + "\\Logs\\Release";
        static string logFileName = logFilePath + "\\log";
#endif
        static string statisticsFilePath = GetProjectFolderPath() + "\\Statistics\\";
        static string dynamicHeuristicsFilePath = GetProjectFolderPath() + "\\DynamicHeuristics\\";


        [STAThread]
        static void Main()
        {
            CreateProjectFoldersIfNeccessary();
            Logger.Initialize(logLevel, logFileName, logSize);
            Application.ApplicationExit += new EventHandler(Program.OnExit);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DynamicHeuristicAlgorithmRunner(statisticsFilePath, dynamicHeuristicsFilePath));
        }

        private static void CreateProjectFoldersIfNeccessary()
        {
            Directory.CreateDirectory(logFilePath);
            Directory.CreateDirectory(statisticsFilePath);
            Directory.CreateDirectory(dynamicHeuristicsFilePath);
        }

        static void OnExit(object sender, EventArgs args)
        {
            Logger.Dispose();
            Logger.DisposeError();
        }

        static string GetProjectFolderPath()
        {
            return Environment.CurrentDirectory;
        }
    }
}
