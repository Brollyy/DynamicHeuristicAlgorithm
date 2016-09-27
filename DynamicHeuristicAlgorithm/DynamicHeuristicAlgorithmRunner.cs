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

namespace DynamicHeuristicAlgorithm
{
    public partial class DynamicHeuristicAlgorithmRunner : Form
    {
        public DynamicHeuristicAlgorithmRunner()
        {
            InitializeComponent();
            Console.SetOut(new MultiTextWriter(new ControlWriter(consoleOutputTextBox), Console.Out));
            Properties.Settings.Default.SettingChanging += ChangePlayButtonTextEventHandler;
            Properties.Settings.Default.SettingsSaving += ChangePlayButtonTextBackEventHandler;
        }

        private void ChangePlayButtonTextBackEventHandler(object sender, CancelEventArgs e)
        {
            Logger.LogInfo("Settings saved.");
            playButton.Text = "Play";
        }

        private void ChangePlayButtonTextEventHandler(object sender, SettingChangingEventArgs e)
        {
            playButton.Text = "Save settings and play";
        }

        private RadioButton GetSelectedRadioButtonInGroup(GroupBox group)
        {
            return group.Controls.OfType<RadioButton>().Where(radio => radio.Checked).Single();
        }

        private CheckBox[] GetSelectedCheckBoxesInGroup(GroupBox group)
        {
            return group.Controls.OfType<CheckBox>().Where(checkBox => checkBox.Checked).ToArray();
        }

        private MaskedTextBox[] GetSelectedMaskedTextBoxesInGroup(GroupBox group)
        {
            return group.Controls.OfType<MaskedTextBox>().Where(maskedTextBox => maskedTextBox.Visible).ToArray();
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
            purgeDynamicHeuristicDataButton.Visible = ((RadioButton)sender).Checked;
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

        private void clearConsoleButton_Click(object sender, EventArgs e)
        {
            consoleOutputTextBox.Text = "";
        }

        private void purgeLogsButton_Click(object sender, EventArgs e)
        {
            Logger.PurgeAllLogs();
        }

        private void deleteStatisticsButton_Click(object sender, EventArgs e)
        {
            Logger.LogError("Statistics not implemented.");
        }

        private void purgeDynamicHeuristicDataButton_Click(object sender, EventArgs e)
        {
            Logger.LogError("Dynamic heuristic not implemented.");
        }

        Thread gameThread;

        private void playButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Logger.LogDebug("Starting new thread to handle the game run.");
            gameThread = new Thread(new ThreadStart(GameRunThreadStart));
            Logger.LogDebug("Started new thread " + gameThread.ManagedThreadId);
            BlockUI();
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
                playButton.Enabled = true;
                purgeLogsButton.Enabled = true;
                purgeDynamicHeuristicDataButton.Enabled = true;
                deleteStatisticsButton.Enabled = true;
                clearConsoleButton.Enabled = true;
            }
        }

        private void GameRunThreadStart()
        {
            try
            {
                Player player = GetPlayer();
                switch (GetModeName())
                {
                    case "playYourself":
                        {
                            Game game = GetGame();
                            PlayTheGame(game, player);
                        }
                        break;
                    case "setHeuristics":
                    case "dynamicHeuristic":
                        {
                            if (numberOfRunsMaskedTextBox.Text.Equals(""))
                            {
                                Logger.LogInfo("Number of runs not set. Setting default 1.");
                                numberOfRunsMaskedTextBox.Text = "1";
                            }
                            uint runs = Convert.ToUInt32(numberOfRunsMaskedTextBox.Text);
                            for (uint i = 0; i < runs; ++i)
                            {
                                Game game = GetGame();
                                PlayTheGame(game, player);
                                if (saveStatisticsCheckBox.Checked)
                                {
                                    SaveStatistics(game, player);
                                }
                                if (GetModeName().Equals("dynamicHeuristic"))
                                {
                                    AnalyzeGame(game, player);
                                }
                            }
                        }
                        break;
                }
                Logger.LogDebug("Thread " + gameThread.ManagedThreadId + " ended.");
                UnblockUI();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void AnalyzeGame(Game game, Player player)
        {
            throw new NotImplementedException("Dynamic heuristic is not implemented.");
        }

        private void PlayTheGame(Game game, Player player, uint runs = 1)
        {
            for (uint i = 0; i < runs; ++i)
            {
                HashSet<Player> players = new HashSet<Player>() { player };
                game.PlayGame(players);
            }
        }

        private void SaveStatistics(Game game, Player player)
        {
            throw new NotImplementedException("Statistics are not implemented.");
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
                    return GetDynamicHeuristicOptions();
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

        private Dictionary<string, object> GetDynamicHeuristicOptions()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            Logger.LogInfo("Setting recursion depth.");
            if (recursionDepthMaskedTextBox.Text.Equals("") || recursionDepthMaskedTextBox.Text.Equals("0"))
            {
                Logger.LogInfo("Recursion depth isn't set properly. Setting to default 4.");
                recursionDepthMaskedTextBox.Text = "4";
            }
            uint recursionDepth = Convert.ToUInt32(recursionDepthMaskedTextBox.Text);
            parameters.Add("recursionDepth", recursionDepth);
            Logger.LogInfo("Recursion depth set to " + recursionDepth + ".");

            return parameters;
        }

        private Dictionary<string, object> GetSetHeuristicsAndOptions(string gameName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            #region RecursionDepth
            Logger.LogInfo("Setting recursion depth.");
            if(recursionDepthMaskedTextBox.Text.Equals("") || recursionDepthMaskedTextBox.Text.Equals("0"))
            {
                Logger.LogInfo("Recursion depth isn't set properly. Setting to default 4.");
                recursionDepthMaskedTextBox.Text = "4";
            }
            uint recursionDepth = Convert.ToUInt32(recursionDepthMaskedTextBox.Text);
            parameters.Add("recursionDepth", recursionDepth);
            Logger.LogInfo("Recursion depth set to " + recursionDepth + ".");
            #endregion

            #region SetHeuristics
            Logger.LogInfo("Setting heuristics.");
            string[] names = new string[0];
            uint[] weights = new uint[0];
            switch (gameName)
            {
                case "ConnectFour":
                    names = new string[] { "connectFourHeuristic" };
                    weights = new uint[] { 1 };
                    break;
                case "TicTacToe":
                    names = new string[] { "ticTacToeHeuristic" };
                    weights = new uint[] { 1 };
                    break;
                case "2048":
                    {
                        CheckBox[] selectedHeuristics = GetSelectedCheckBoxesInGroup(setHeuristicsGroupBox);
                        names = selectedHeuristics.OrderBy(checkBox => checkBox.Name)
                                    .Select(checkBox => checkBox.Name.Substring(0, checkBox.Name.IndexOf("CheckBox")))
                                    .ToArray();
                        MaskedTextBox[] selectedWeights = GetSelectedMaskedTextBoxesInGroup(setHeuristicsGroupBox);
                        foreach(MaskedTextBox maskedTextBox in selectedWeights)
                        {
                            if(maskedTextBox.Text.Equals(""))
                            {
                                maskedTextBox.Text = "1";
                                Logger.LogInfo(maskedTextBox.Name.Substring(0, maskedTextBox.Name.IndexOf("MaskedTextBox"))
                                    + " wasn't set. Setting it to default 1.");
                            }
                        }
                        weights = selectedWeights.OrderBy(maskedTextBox => maskedTextBox.Name)
                                    .Select(maskedTextBox => Convert.ToUInt32(maskedTextBox.Text))
                                    .ToArray();
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

        #region Settings

        private void numberOfRunsMaskedTextBox_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.NumberOfRuns = ((MaskedTextBox)sender).Text;
        }

        private void recursionDepthMaskedTextBox_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.MaximalRecursionDepth = ((MaskedTextBox)sender).Text;
        }

        #endregion

        private void saveStatisticsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveStatistics = ((CheckBox)sender).Checked;
        }

        private void openSquareBonusHeuristicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            openSquareBonusHeuristicWeightMaskedTextBox.Visible = ((CheckBox)sender).Checked;
            Properties.Settings.Default.OpenSquaresBonusHeuristic = ((CheckBox)sender).Checked;
        }

        private void largeValuesOnEdgeHeuristicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            largeValuesOnEdgeHeuristicWeightMaskedTextBox.Visible = ((CheckBox)sender).Checked;
            Properties.Settings.Default.LargeValuesOnEdgeHeuristic = ((CheckBox)sender).Checked;
        }

        private void nonMonotonicLinesPenaltyHeuristicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox.Visible = ((CheckBox)sender).Checked;
            Properties.Settings.Default.NonMonotonicLinesPenaltyHeuristic = ((CheckBox)sender).Checked;
        }

        private void numberOfMergesHeuristicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            numberOfMergesHeuristicWeightMaskedTextBox.Visible = ((CheckBox)sender).Checked;
            Properties.Settings.Default.NumberOfMergesHeuristic = ((CheckBox)sender).Checked;
        }

        private void openSquareBonusHeuristicWeightMaskedTextBox_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.OpenSquaresBonusHeuristicWeight = ((MaskedTextBox)sender).Text;
        }

        private void largeValuesOnEdgeHeuristicWeightMaskedTextBox_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.LargeValuesOnEdgeHeuristicWeight = ((MaskedTextBox)sender).Text;
        }

        private void nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.NonMonotonicLinesPenaltyHeuristicWeight = ((MaskedTextBox)sender).Text;
        }

        private void numberOfMergesHeuristicWeightMaskedTextBox_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.NumberOfMergesHeuristicWeight = ((MaskedTextBox)sender).Text;
        }
    }
}
