using DynamicHeuristicAlgorithm.Utils;
using DynamicHeuristicAlgorithmCore.GameInterface;
using DynamicHeuristicAlgorithmCore.HeuristicInterface;
using DynamicHeuristicAlgorithmCore.PlayerInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using DynamicHeuristicAlgorithmCore.Utils;
using System.Threading;
using System.Diagnostics;

namespace DynamicHeuristicAlgorithm
{
    public partial class DynamicHeuristicAlgorithmRunner : Form
    {
        private string statisticsFilePath;
        private string dynamicHeuristicsFilePath;

        public DynamicHeuristicAlgorithmRunner(string statisticsFilePath, string dynamicHeuristicsFilePath)
        {
            InitializeComponent();
            Console.SetOut(new MultiTextWriter(new ControlWriter(consoleOutputTextBox), Console.Out));
            Properties.Settings.Default.SettingChanging += ChangePlayButtonTextEventHandler;
            Properties.Settings.Default.SettingsSaving += ChangePlayButtonTextBackEventHandler;
            this.statisticsFilePath = statisticsFilePath;
            this.dynamicHeuristicsFilePath = dynamicHeuristicsFilePath;
            openSquaresBonusHeuristicWeightCounter.Visible = openSquareBonusHeuristicCheckBox.Checked;
            largeValuesOnEdgeHeuristicWeightCounter.Visible = largeValuesOnEdgeHeuristicCheckBox.Checked;
            nonMonotonicLinesPenaltyHeuristicWeightCounter.Visible = nonMonotonicLinesPenaltyHeuristicCheckBox.Checked;
            numberOfMergesHeuristicWeightCounter.Visible = numberOfMergesHeuristicCheckBox.Checked;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Environment.Exit(Environment.ExitCode);
        }

        private void ChangePlayButtonTextBackEventHandler(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired)
            {
                Logger.LogInfo("Settings saved.");
                playButton.Text = "Play";
                playInViewButton.Text = "Play in view";
            }
        }

        private void ChangePlayButtonTextEventHandler(object sender, SettingChangingEventArgs e)
        {
            if (!InvokeRequired)
            {
                playButton.Text = "Save and play";
                playInViewButton.Text = "Save and play in view";
            }
        }

        private RadioButton GetSelectedRadioButtonInGroup(GroupBox group)
        {
            return group.Controls.OfType<RadioButton>().Where(radio => radio.Checked).Single();
        }

        private CheckBox[] GetSelectedCheckBoxesInGroup(GroupBox group)
        {
            return group.Controls.OfType<CheckBox>().Where(checkBox => checkBox.Checked).ToArray();
        }

        private NumericUpDown[] GetSelectedNumericUpDownsInGroup(GroupBox group)
        {
            return group.Controls.OfType<NumericUpDown>().Where(numericUpDown => numericUpDown.Visible).ToArray();
        }

        private void consoleOutputTextBox_TextChanged(object sender, EventArgs e)
        {
            ControlExtensions.Suspend(consoleOutputTextBox);
            consoleOutputTextBox.SelectionStart = consoleOutputTextBox.Text.Length;
            consoleOutputTextBox.ScrollToCaret();
            ControlExtensions.Resume(consoleOutputTextBox);
        }

        private void setHeuristicsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked &&
                GetSelectedRadioButtonInGroup(chooseGameGroupBox) == game2048RadioButton)
            {
                setHeuristicsGroupBox.Visible = true;
            }
            else
            {
                setHeuristicsGroupBox.Visible = false;
            }

            AIOptionsGroupBox.Visible = ((RadioButton)sender).Checked;
        }

        private void dynamicHeuristicRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AIOptionsGroupBox.Visible = ((RadioButton)sender).Checked;
            dynamicHeuristicsGroupBox.Visible = ((RadioButton)sender).Checked;
        }

        private void game2048RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked &&
                GetSelectedRadioButtonInGroup(modeGroupBox) == setHeuristicsRadioButton)
            {
                setHeuristicsGroupBox.Visible = true;
            }
            else
            {
                setHeuristicsGroupBox.Visible = false;
            }
        }

        private void playYourselfRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            playButton.Enabled = !((RadioButton)sender).Checked;
        }

        private void clearConsoleButton_Click(object sender, EventArgs e)
        {
            consoleOutputTextBox.Text = "";
        }

        private void purgeLogsButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all the logs?",
                "Deleting logs.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Logger.PurgeAllLogs();
            }
        }

        private void deleteStatisticsButton_Click(object sender, EventArgs e)
        {
            string filepath = GetGameName() + "\\" + GetModeName() + "\\" +
                                  recursionDepthCounter.Value;
            if (MessageBox.Show("Are you sure you want to delete all files from " + filepath + "?",
                "Deleting statistics.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                IEnumerable<string> files = Directory.Exists(statisticsFilePath + filepath) ? 
                    Directory.EnumerateFiles(statisticsFilePath + filepath) : new List<string>();
                if (files.Count() == 0)
                {
                    Logger.LogInfo("No files found at " + filepath + ".");
                }
                foreach (string file in files)
                {
                    File.Delete(file);
                    Logger.LogInfo("Deleted file " + file + ".");
                }
            }
        }

        private void purgeDynamicHeuristicDataButton_Click(object sender, EventArgs e)
        {
            string filepath = GetGameName() + "\\" + GetDynamicHeuristicName();
            if (MessageBox.Show("Are you sure you want to delete file " + filepath + 
                "\\" + recursionDepthCounter.Value + "?",
                "Deleting dynamic heuristic data.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Directory.Exists(dynamicHeuristicsFilePath + filepath))
                {
                    string file = dynamicHeuristicsFilePath + filepath + "\\" + recursionDepthCounter.Value;
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                        Logger.LogInfo("Deleted file " + file + ".");
                    }
                    else
                    {
                        Logger.LogInfo("File not found at " + filepath + ".");
                    }
                }
                else
                {
                    Logger.LogInfo("File not found at " + filepath + ".");
                }
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            BlockUI();
            Logger.LogDebug("Starting new thread to handle the game.");
            Thread gameThread = new Thread(new ThreadStart(StartThreadStart));
            Logger.LogDebug("Started new thread " + gameThread.ManagedThreadId);
            gameThread.Start();
        }

        private void playInViewButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            BlockUI();
            Logger.LogDebug("Starting new thread to handle the game in view.");
            Thread gameThread = new Thread(new ThreadStart(StartInViewThreadStart));
            Logger.LogDebug("Started new thread " + gameThread.ManagedThreadId);
            gameThread.Start();
        }

        private void BlockUI()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(BlockUI));
            }
            else
            {
                playButton.Enabled = false;
                playInViewButton.Enabled = false;
                purgeLogsButton.Enabled = false;
                purgeDynamicHeuristicDataButton.Enabled = false;
                deleteStatisticsButton.Enabled = false;
                clearConsoleButton.Enabled = false;
            }
        }

        private void UnblockUI()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UnblockUI));
            }
            else
            {
                if (GetModeName() != "playYourself") playButton.Enabled = true;
                playInViewButton.Enabled = true;
                purgeLogsButton.Enabled = true;
                purgeDynamicHeuristicDataButton.Enabled = true;
                deleteStatisticsButton.Enabled = true;
                clearConsoleButton.Enabled = true;
            }
        }

        private void StartInViewThreadStart()
        {
            try
            {
                AutoResetEvent block = new AutoResetEvent(false);
                Player player = GetPlayer();
                switch (GetModeName())
                {
                    case "playYourself":
                        {
                            Game game = GetGame();
                            StartNewGameInView(game, player, block);
                            block.WaitOne();
                        }
                        break;
                    case "setHeuristics":
                    case "dynamicHeuristic":
                        {
                            uint runs = (uint)numberOfRunsCounter.Value;
                            for (uint i = 0; i < runs; ++i)
                            {
                                Game game = GetGame();
                                Logger.LogInfo("Game no. " + (i + 1) + ".");
                                StartNewGameInView(game, player, block);
                                block.WaitOne();
                                if (saveStatisticsCheckBox.Checked)
                                {
                                    SaveStatistics(game, player);
                                }
                                if(GetModeName() == "dynamicHeuristic")
                                {
                                    AIPlayer aiPlayer = (AIPlayer)player;
                                    aiPlayer.TeachDynamicHeuristic(game.GetGameStatistics());
                                    SaveDynamicHeuristicData(aiPlayer);
                                }
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                Logger.LogDebug("Thread " + Thread.CurrentThread.ManagedThreadId + " ended.");
                UnblockUI();
            }
        }

        private void StartThreadStart()
        {
            try
            {
                switch (GetModeName())
                {
                    case "setHeuristics":
                        {
                            Player player = GetPlayer();
                            uint runs = (uint)numberOfRunsCounter.Value;
                            if (GetGameName() == "2048")
                            {
                                Game game = GetGame();
                                for (uint i = 0; i < runs; ++i)
                                {
                                    try
                                    {
                                        Logger.LogInfo("Game no. " + (i + 1) + ".");
                                        StartNewGame(game, player);
                                        if (saveStatisticsCheckBox.Checked)
                                        {
                                            SaveStatistics(game, player);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Logger.LogError(e);
                                        Logger.LogError("Running game no. + " + (i + 1) + " failed.");
                                    }
                                }
                            }
                            else
                            {
                                Thread[] threads = new Thread[Math.Min(runs, 4)];
                                for (uint i = 0; i < threads.Length; ++i)
                                {
                                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                                    parameters.Add("player", player);
                                    parameters.Add("startIndex", (uint)Math.Floor((double)(i * runs) / threads.Length));
                                    parameters.Add("endIndex", (uint)Math.Floor((double)((i + 1) * runs) / threads.Length));
                                    threads[i] = new Thread(new ParameterizedThreadStart(RunGamesThreadStart));
                                    threads[i].IsBackground = true;
                                    threads[i].Start(parameters);
                                }
                                for (uint i = 0; i < threads.Length; ++i)
                                {
                                    threads[i].Join();
                                }
                            }
                        }
                        break;
                    case "dynamicHeuristic":
                        {
                            switch(GetDynamicHeuristicName())
                            {
                                case "mapDynamicHeuristic":
                                case "neuralNetworkDynamicHeuristic":
                                    {
                                        Player player = GetPlayer();
                                        uint runs = (uint)numberOfRunsCounter.Value;
                                        for(uint i = 0; i < runs; ++i)
                                        {
                                            try
                                            {
                                                Game game = GetGame();
                                                Logger.LogInfo("Game no. " + (i + 1) + ".");
                                                StartNewGame(game, player);
                                                if (saveStatisticsCheckBox.Checked)
                                                {
                                                    SaveStatistics(game, player);
                                                }
                                                
                                                ((AIPlayer)player).TeachDynamicHeuristic(game.GetGameStatistics());
                                            }
                                            catch (Exception e)
                                            {
                                                Logger.LogError(e);
                                                Logger.LogError("Running game no. + " + (i + 1) + " failed.");
                                            }
                                        }
                                        AIPlayer aiPlayer = (AIPlayer)player;
                                        SaveDynamicHeuristicData(aiPlayer);
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                Logger.LogDebug("Thread " + Thread.CurrentThread.ManagedThreadId + " ended.");
                Logger.FlushAllLogs();
                UnblockUI();
            }
        }

        private void RunGamesThreadStart(object parameters)
        {
            try
            {
                Dictionary<string, object> p = (Dictionary<string, object>)parameters;
                uint start = (uint)p["startIndex"];
                uint end = (uint)p["endIndex"];
                Player player = (Player)p["player"];
                Game game = GetGame();
                for (uint i = start; i < end; ++i)
                {
                    try
                    {
                        Logger.LogInfo("Game no. " + (i + 1) + ".");
                        StartNewGame(game, player);
                        if (saveStatisticsCheckBox.Checked)
                        {
                            SaveStatistics(game, player);
                        }
                    }
                    catch(Exception e)
                    {
                        Logger.LogError(e);
                        Logger.LogError("Running game no. + " + (i + 1) + " failed.");
                    }
                }
            }
            catch(Exception e)
            {
                try
                {
                    Logger.LogError(e);
                }
                catch(Exception ex)
                {
                    return;
                }
            }
        }

        private void StartNewGameInView(Game game, Player player, AutoResetEvent block)
        {
            Logger.LogInfo("Starting new game in view.");
            Form newGameForm = GameViewFactory.GetGameViewAsForm(game, player);
            newGameForm.FormClosed += new FormClosedEventHandler((sender, args) =>
            {
                block.Set();
            });

            Application.Run(newGameForm);
        }

        private void StartNewGame(Game game, Player player)
        {
            Logger.LogInfo("Starting new game.");
            try
            {
                game.PlayGame(new HashSet<Player>() { player });
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
            
        }

        private ReaderWriterLockSlim statisticsFileLock = new ReaderWriterLockSlim();

        private void SaveStatistics(Game game, Player player)
        {
            AIPlayer ai = player as AIPlayer;
            if (ai != null)
            {
                string filepath = GetGameName() + "\\" + GetModeName() + "\\" +
                                  recursionDepthCounter.Value + "\\";
                Directory.CreateDirectory(statisticsFilePath + filepath);
                string filename = filepath + ai.HeuristicsToString() + ".csv";
                Logger.LogDebug("Thread " + Thread.CurrentThread.ManagedThreadId + " - Waiting to get access to statistics file.");
                statisticsFileLock.EnterWriteLock();
                Logger.LogInfo("Saving statistics to " + filename + ".");
                game.GetGameStatistics().SaveStatistics(statisticsFilePath + filename);
                statisticsFileLock.ExitWriteLock();
            }
        }

        private void SaveDynamicHeuristicData(AIPlayer player)
        {
            string filepath = GetGameName() + "\\" + GetDynamicHeuristicName();
            Directory.CreateDirectory(dynamicHeuristicsFilePath + filepath);
            string filename = filepath + "\\" + recursionDepthCounter.Value;
            Logger.LogInfo("Saving dynamic heuristic data to " + filename + ".");
            player.SaveDynamicHeuristicData(dynamicHeuristicsFilePath + filename);
        }

        private Player GetPlayer()
        {
            string modeName = GetModeName();
            Logger.LogInfo("Selected mode: " + modeName);
            return PlayerFactory.GetPlayerByNameAndParameters(modeName, GetParameters(modeName, GetGameName()));
        }

        private Dictionary<string, object> GetParameters(string modeName, string gameName)
        {
            switch(modeName)
            {
                case "playYourself":
                    return GetGameOptions(gameName);
                case "setHeuristics":
                    return GetSetHeuristicsAndOptions(gameName);
                case "dynamicHeuristic":
                    return GetDynamicHeuristicOptions(GetDynamicHeuristicName());
                default:
                    return new Dictionary<string, object>();
            }
        }

        private Dictionary<string, object> GetGameOptions(string gameName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("gameName", gameName);
            return parameters;
        }

        private Dictionary<string, object> GetDynamicHeuristicOptions(string dynamicHeuristicName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            Logger.LogInfo("Setting recursion depth.");
            uint recursionDepth = (uint)recursionDepthCounter.Value;
            parameters.Add("recursionDepth", recursionDepth);
            Logger.LogInfo("Recursion depth set to " + recursionDepth + ".");
            Logger.LogInfo("Setting dynamic heuristic.");
            string filename = dynamicHeuristicsFilePath + GetGameName() + "\\" + dynamicHeuristicName +
                                "\\" + recursionDepth;
            int numberOfInputs = GetNumberOfInputs();
            Heuristic heuristic = HeuristicFactory.GetHeuristicByName(dynamicHeuristicName, 1, 
                                    new Dictionary<string, object>()
                                    {
                                        { "filename", filename },
                                        { "numberOfInputs", numberOfInputs },
                                        { "gameName", GetGameName() }
                                    });
            parameters.Add("dynamicHeuristic", heuristic);
            return parameters;
        }

        private int GetNumberOfInputs()
        {
            string gameName = GetGameName();
            switch(gameName)
            {
                case "TicTacToe": return 9;
                case "2048": return 16;
                default: throw new NotImplementedException(gameName + " is not implemented.");
            }
        }

        private Dictionary<string, object> GetSetHeuristicsAndOptions(string gameName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            #region RecursionDepth
            Logger.LogInfo("Setting recursion depth.");
            uint recursionDepth = (uint)recursionDepthCounter.Value;
            parameters.Add("recursionDepth", recursionDepth);
            Logger.LogInfo("Recursion depth set to " + recursionDepth + ".");
            #endregion

            #region SetHeuristics
            Logger.LogInfo("Setting heuristics.");
            string[] names = new string[0];
            double[] weights = new double[0];
            switch (gameName)
            {
                case "ConnectFour":
                    names = new string[] { "connectFourHeuristic" };
                    weights = new double[] { 1 };
                    break;
                case "TicTacToe":
                    names = new string[] { "ticTacToeHeuristic" };
                    weights = new double[] { 1 };
                    break;
                case "2048":
                    {
                        CheckBox[] selectedHeuristics = GetSelectedCheckBoxesInGroup(setHeuristicsGroupBox);
                        List<string> namesList = selectedHeuristics.OrderBy(checkBox => checkBox.Name)
                                    .Select(checkBox => checkBox.Name.Substring(0, checkBox.Name.IndexOf("CheckBox")))
                                    .ToList();
                        namesList.Add("2048Heuristic");
                        names = namesList.ToArray();
                        NumericUpDown[] selectedWeights = GetSelectedNumericUpDownsInGroup(setHeuristicsGroupBox);
                        List<double> weightsList = selectedWeights.OrderBy(numericUpDown => numericUpDown.Name)
                                    .Select(numericUpDown => (double)numericUpDown.Value)
                                    .ToList();
                        weightsList.Add(1);
                        weights = weightsList.ToArray();
                    }
                    break;
            }
            
            
            Heuristic[] setHeuristics = HeuristicFactory.GetHeuristicsByNames(names, weights);
            for(int i = 0; i < names.Length; ++i)            {
                Logger.LogInfo("Heuristic " + names[i] + " with weight " + weights[i]);
            }
            parameters.Add("setHeuristics", setHeuristics);
            #endregion

            return parameters;
        }

        private Game GetGame()
        {
            string gameName = GetGameName();
            Logger.LogInfo("Selected game: " + gameName);
            return GameFactory.GetGameByName(gameName);
        }

        private string GetGameName()
        {
            string selectedGameRadioButtonName = GetSelectedRadioButtonInGroup(chooseGameGroupBox).Name;
            return  selectedGameRadioButtonName.Substring(4,
                        selectedGameRadioButtonName.IndexOf("RadioButton") - 4);
        }

        private string GetModeName()
        {
            string selectedModeRadioButtonName = GetSelectedRadioButtonInGroup(modeGroupBox).Name;
            return selectedModeRadioButtonName.Substring(0,
                        selectedModeRadioButtonName.IndexOf("RadioButton"));
        }

        private string GetDynamicHeuristicName()
        {
            string selectedDynamicHeuristicRadioButtonName = GetSelectedRadioButtonInGroup(dynamicHeuristicsGroupBox).Name;
            return selectedDynamicHeuristicRadioButtonName.Substring(0,
                        selectedDynamicHeuristicRadioButtonName.IndexOf("RadioButton"));
        }

        private void openLogsButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Logger.LoggerPath);
        }

        private void openStatisticsButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", statisticsFilePath.TrimEnd('\\'));
        }

        private void openSquareBonusHeuristicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            openSquaresBonusHeuristicWeightCounter.Visible = ((CheckBox)sender).Checked;
        }

        private void largeValuesOnEdgeHeuristicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            largeValuesOnEdgeHeuristicWeightCounter.Visible = ((CheckBox)sender).Checked;
        }

        private void nonMonotonicLinesPenaltyHeuristicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            nonMonotonicLinesPenaltyHeuristicWeightCounter.Visible = ((CheckBox)sender).Checked;
        }

        private void numberOfMergesHeuristicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            numberOfMergesHeuristicWeightCounter.Visible = ((CheckBox)sender).Checked;
        }
    }
}
