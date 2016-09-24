namespace DynamicHeuristicAlgorithm
{
    partial class DynamicHeuristicAlgorithmRunner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playButton = new System.Windows.Forms.Button();
            this.consoleOutputTextBox = new System.Windows.Forms.TextBox();
            this.modeGroupBox = new System.Windows.Forms.GroupBox();
            this.dynamicHeuristicRadioButton = new System.Windows.Forms.RadioButton();
            this.setHeuristicsRadioButton = new System.Windows.Forms.RadioButton();
            this.playYourselfRadioButton = new System.Windows.Forms.RadioButton();
            this.setHeuristicsGroupBox = new System.Windows.Forms.GroupBox();
            this.openSquareBonusHeuristicCheckBox = new System.Windows.Forms.CheckBox();
            this.largeValuesOnEdgeHeuristicCheckBox = new System.Windows.Forms.CheckBox();
            this.nonMonotonicLinesPenaltyHeuristicCheckBox = new System.Windows.Forms.CheckBox();
            this.numberOfMergesHeuristicCheckBox = new System.Windows.Forms.CheckBox();
            this.chooseGameGroupBox = new System.Windows.Forms.GroupBox();
            this.gameTicTacToeRadioButton = new System.Windows.Forms.RadioButton();
            this.openSquareBonusHeuristicWeightMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.largeValuesOnEdgeHeuristicWeightMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.numberOfMergesHeuristicWeightMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.game2048RadioButton = new System.Windows.Forms.RadioButton();
            this.gameCoinFlipGuessRadioButton = new System.Windows.Forms.RadioButton();
            this.AIOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.clearConsoleButton = new System.Windows.Forms.Button();
            this.purgeLogsButton = new System.Windows.Forms.Button();
            this.numberOfRunsLabel = new System.Windows.Forms.Label();
            this.numberOfRunsMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.saveStatisticsCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteStatisticsButton = new System.Windows.Forms.Button();
            this.purgeDynamicHeuristicDataButton = new System.Windows.Forms.Button();
            this.recursionDepthMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.recursionDepthLabel = new System.Windows.Forms.Label();
            this.modeGroupBox.SuspendLayout();
            this.setHeuristicsGroupBox.SuspendLayout();
            this.chooseGameGroupBox.SuspendLayout();
            this.AIOptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(391, 383);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(218, 28);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // consoleOutputTextBox
            // 
            this.consoleOutputTextBox.Location = new System.Drawing.Point(12, 12);
            this.consoleOutputTextBox.Multiline = true;
            this.consoleOutputTextBox.Name = "consoleOutputTextBox";
            this.consoleOutputTextBox.ReadOnly = true;
            this.consoleOutputTextBox.Size = new System.Drawing.Size(597, 193);
            this.consoleOutputTextBox.TabIndex = 2;
            this.consoleOutputTextBox.TabStop = false;
            this.consoleOutputTextBox.TextChanged += new System.EventHandler(this.consoleOutputTextBox_TextChanged);
            // 
            // modeGroupBox
            // 
            this.modeGroupBox.Controls.Add(this.dynamicHeuristicRadioButton);
            this.modeGroupBox.Controls.Add(this.setHeuristicsRadioButton);
            this.modeGroupBox.Controls.Add(this.playYourselfRadioButton);
            this.modeGroupBox.Location = new System.Drawing.Point(12, 212);
            this.modeGroupBox.Name = "modeGroupBox";
            this.modeGroupBox.Size = new System.Drawing.Size(145, 100);
            this.modeGroupBox.TabIndex = 3;
            this.modeGroupBox.TabStop = false;
            this.modeGroupBox.Text = "Mode";
            // 
            // dynamicHeuristicRadioButton
            // 
            this.dynamicHeuristicRadioButton.AutoSize = true;
            this.dynamicHeuristicRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dynamicHeuristicRadioButton.Location = new System.Drawing.Point(7, 68);
            this.dynamicHeuristicRadioButton.Name = "dynamicHeuristicRadioButton";
            this.dynamicHeuristicRadioButton.Size = new System.Drawing.Size(125, 17);
            this.dynamicHeuristicRadioButton.TabIndex = 2;
            this.dynamicHeuristicRadioButton.Text = "Dynamic heuristic";
            this.dynamicHeuristicRadioButton.UseVisualStyleBackColor = true;
            this.dynamicHeuristicRadioButton.CheckedChanged += new System.EventHandler(this.dynamicHeuristicRadioButton_CheckedChanged);
            // 
            // setHeuristicsRadioButton
            // 
            this.setHeuristicsRadioButton.AutoSize = true;
            this.setHeuristicsRadioButton.Location = new System.Drawing.Point(7, 44);
            this.setHeuristicsRadioButton.Name = "setHeuristicsRadioButton";
            this.setHeuristicsRadioButton.Size = new System.Drawing.Size(108, 17);
            this.setHeuristicsRadioButton.TabIndex = 1;
            this.setHeuristicsRadioButton.Text = "Existing heuristics";
            this.setHeuristicsRadioButton.UseVisualStyleBackColor = true;
            this.setHeuristicsRadioButton.CheckedChanged += new System.EventHandler(this.setHeuristicsRadioButton_CheckedChanged);
            // 
            // playYourselfRadioButton
            // 
            this.playYourselfRadioButton.AutoSize = true;
            this.playYourselfRadioButton.Checked = true;
            this.playYourselfRadioButton.Location = new System.Drawing.Point(7, 20);
            this.playYourselfRadioButton.Name = "playYourselfRadioButton";
            this.playYourselfRadioButton.Size = new System.Drawing.Size(84, 17);
            this.playYourselfRadioButton.TabIndex = 0;
            this.playYourselfRadioButton.TabStop = true;
            this.playYourselfRadioButton.Text = "Play yourself";
            this.playYourselfRadioButton.UseVisualStyleBackColor = true;
            // 
            // setHeuristicsGroupBox
            // 
            this.setHeuristicsGroupBox.Controls.Add(this.numberOfMergesHeuristicWeightMaskedTextBox);
            this.setHeuristicsGroupBox.Controls.Add(this.nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox);
            this.setHeuristicsGroupBox.Controls.Add(this.largeValuesOnEdgeHeuristicWeightMaskedTextBox);
            this.setHeuristicsGroupBox.Controls.Add(this.openSquareBonusHeuristicWeightMaskedTextBox);
            this.setHeuristicsGroupBox.Controls.Add(this.numberOfMergesHeuristicCheckBox);
            this.setHeuristicsGroupBox.Controls.Add(this.nonMonotonicLinesPenaltyHeuristicCheckBox);
            this.setHeuristicsGroupBox.Controls.Add(this.largeValuesOnEdgeHeuristicCheckBox);
            this.setHeuristicsGroupBox.Controls.Add(this.openSquareBonusHeuristicCheckBox);
            this.setHeuristicsGroupBox.Location = new System.Drawing.Point(384, 212);
            this.setHeuristicsGroupBox.Name = "setHeuristicsGroupBox";
            this.setHeuristicsGroupBox.Size = new System.Drawing.Size(225, 118);
            this.setHeuristicsGroupBox.TabIndex = 4;
            this.setHeuristicsGroupBox.TabStop = false;
            this.setHeuristicsGroupBox.Text = "Heuristics";
            this.setHeuristicsGroupBox.Visible = false;
            // 
            // openSquareBonusHeuristicCheckBox
            // 
            this.openSquareBonusHeuristicCheckBox.AutoSize = true;
            this.openSquareBonusHeuristicCheckBox.Location = new System.Drawing.Point(7, 20);
            this.openSquareBonusHeuristicCheckBox.Name = "openSquareBonusHeuristicCheckBox";
            this.openSquareBonusHeuristicCheckBox.Size = new System.Drawing.Size(119, 17);
            this.openSquareBonusHeuristicCheckBox.TabIndex = 0;
            this.openSquareBonusHeuristicCheckBox.Text = "Open square bonus";
            this.openSquareBonusHeuristicCheckBox.UseVisualStyleBackColor = true;
            this.openSquareBonusHeuristicCheckBox.CheckedChanged += new System.EventHandler(this.openSquareBonusHeuristicCheckBox_CheckedChanged);
            // 
            // largeValuesOnEdgeHeuristicCheckBox
            // 
            this.largeValuesOnEdgeHeuristicCheckBox.AutoSize = true;
            this.largeValuesOnEdgeHeuristicCheckBox.Location = new System.Drawing.Point(7, 44);
            this.largeValuesOnEdgeHeuristicCheckBox.Name = "largeValuesOnEdgeHeuristicCheckBox";
            this.largeValuesOnEdgeHeuristicCheckBox.Size = new System.Drawing.Size(129, 17);
            this.largeValuesOnEdgeHeuristicCheckBox.TabIndex = 1;
            this.largeValuesOnEdgeHeuristicCheckBox.Text = "Large values on edge";
            this.largeValuesOnEdgeHeuristicCheckBox.UseVisualStyleBackColor = true;
            this.largeValuesOnEdgeHeuristicCheckBox.CheckedChanged += new System.EventHandler(this.largeValuesOnEdgeHeuristicCheckBox_CheckedChanged);
            // 
            // nonMonotonicLinesPenaltyHeuristicCheckBox
            // 
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.AutoSize = true;
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.Location = new System.Drawing.Point(7, 68);
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.Name = "nonMonotonicLinesPenaltyHeuristicCheckBox";
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.Size = new System.Drawing.Size(159, 17);
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.TabIndex = 2;
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.Text = "Non-monotonic lines penalty";
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.UseVisualStyleBackColor = true;
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.CheckedChanged += new System.EventHandler(this.nonMonotonicLinesPenaltyHeuristicCheckBox_CheckedChanged);
            // 
            // numberOfMergesHeuristicCheckBox
            // 
            this.numberOfMergesHeuristicCheckBox.AutoSize = true;
            this.numberOfMergesHeuristicCheckBox.Location = new System.Drawing.Point(7, 92);
            this.numberOfMergesHeuristicCheckBox.Name = "numberOfMergesHeuristicCheckBox";
            this.numberOfMergesHeuristicCheckBox.Size = new System.Drawing.Size(112, 17);
            this.numberOfMergesHeuristicCheckBox.TabIndex = 3;
            this.numberOfMergesHeuristicCheckBox.Text = "Number of merges";
            this.numberOfMergesHeuristicCheckBox.UseVisualStyleBackColor = true;
            this.numberOfMergesHeuristicCheckBox.CheckedChanged += new System.EventHandler(this.numberOfMergesHeuristicCheckBox_CheckedChanged);
            // 
            // chooseGameGroupBox
            // 
            this.chooseGameGroupBox.Controls.Add(this.gameCoinFlipGuessRadioButton);
            this.chooseGameGroupBox.Controls.Add(this.game2048RadioButton);
            this.chooseGameGroupBox.Controls.Add(this.gameTicTacToeRadioButton);
            this.chooseGameGroupBox.Location = new System.Drawing.Point(164, 212);
            this.chooseGameGroupBox.Name = "chooseGameGroupBox";
            this.chooseGameGroupBox.Size = new System.Drawing.Size(214, 100);
            this.chooseGameGroupBox.TabIndex = 5;
            this.chooseGameGroupBox.TabStop = false;
            this.chooseGameGroupBox.Text = "Game";
            // 
            // gameTicTacToeRadioButton
            // 
            this.gameTicTacToeRadioButton.AutoSize = true;
            this.gameTicTacToeRadioButton.Location = new System.Drawing.Point(6, 44);
            this.gameTicTacToeRadioButton.Name = "gameTicTacToeRadioButton";
            this.gameTicTacToeRadioButton.Size = new System.Drawing.Size(84, 17);
            this.gameTicTacToeRadioButton.TabIndex = 0;
            this.gameTicTacToeRadioButton.Text = "Tic Tac Toe";
            this.gameTicTacToeRadioButton.UseVisualStyleBackColor = true;
            // 
            // openSquareBonusHeuristicWeightMaskedTextBox
            // 
            this.openSquareBonusHeuristicWeightMaskedTextBox.Location = new System.Drawing.Point(176, 19);
            this.openSquareBonusHeuristicWeightMaskedTextBox.Mask = "0000";
            this.openSquareBonusHeuristicWeightMaskedTextBox.Name = "openSquareBonusHeuristicWeightMaskedTextBox";
            this.openSquareBonusHeuristicWeightMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.openSquareBonusHeuristicWeightMaskedTextBox.Size = new System.Drawing.Size(43, 20);
            this.openSquareBonusHeuristicWeightMaskedTextBox.TabIndex = 6;
            this.openSquareBonusHeuristicWeightMaskedTextBox.Visible = false;
            this.openSquareBonusHeuristicWeightMaskedTextBox.Leave += new System.EventHandler(this.openSquareBonusHeuristicWeightMaskedTextBox_Leave);
            // 
            // largeValuesOnEdgeHeuristicWeightMaskedTextBox
            // 
            this.largeValuesOnEdgeHeuristicWeightMaskedTextBox.Location = new System.Drawing.Point(176, 43);
            this.largeValuesOnEdgeHeuristicWeightMaskedTextBox.Mask = "0000";
            this.largeValuesOnEdgeHeuristicWeightMaskedTextBox.Name = "largeValuesOnEdgeHeuristicWeightMaskedTextBox";
            this.largeValuesOnEdgeHeuristicWeightMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.largeValuesOnEdgeHeuristicWeightMaskedTextBox.Size = new System.Drawing.Size(43, 20);
            this.largeValuesOnEdgeHeuristicWeightMaskedTextBox.TabIndex = 7;
            this.largeValuesOnEdgeHeuristicWeightMaskedTextBox.Visible = false;
            this.largeValuesOnEdgeHeuristicWeightMaskedTextBox.Leave += new System.EventHandler(this.largeValuesOnEdgeHeuristicWeightMaskedTextBox_Leave);
            // 
            // nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox
            // 
            this.nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox.Location = new System.Drawing.Point(176, 67);
            this.nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox.Mask = "0000";
            this.nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox.Name = "nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox";
            this.nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox.Size = new System.Drawing.Size(43, 20);
            this.nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox.TabIndex = 8;
            this.nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox.Visible = false;
            this.nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox.Leave += new System.EventHandler(this.nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox_Leave);
            // 
            // numberOfMergesHeuristicWeightMaskedTextBox
            // 
            this.numberOfMergesHeuristicWeightMaskedTextBox.Location = new System.Drawing.Point(176, 90);
            this.numberOfMergesHeuristicWeightMaskedTextBox.Mask = "0000";
            this.numberOfMergesHeuristicWeightMaskedTextBox.Name = "numberOfMergesHeuristicWeightMaskedTextBox";
            this.numberOfMergesHeuristicWeightMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numberOfMergesHeuristicWeightMaskedTextBox.Size = new System.Drawing.Size(43, 20);
            this.numberOfMergesHeuristicWeightMaskedTextBox.TabIndex = 9;
            this.numberOfMergesHeuristicWeightMaskedTextBox.Visible = false;
            this.numberOfMergesHeuristicWeightMaskedTextBox.Leave += new System.EventHandler(this.numberOfMergesHeuristicWeightMaskedTextBox_Leave);
            // 
            // game2048RadioButton
            // 
            this.game2048RadioButton.AutoSize = true;
            this.game2048RadioButton.Location = new System.Drawing.Point(6, 68);
            this.game2048RadioButton.Name = "game2048RadioButton";
            this.game2048RadioButton.Size = new System.Drawing.Size(49, 17);
            this.game2048RadioButton.TabIndex = 1;
            this.game2048RadioButton.Text = "2048";
            this.game2048RadioButton.UseVisualStyleBackColor = true;
            this.game2048RadioButton.CheckedChanged += new System.EventHandler(this.game2048RadioButton_CheckedChanged);
            // 
            // gameCoinFlipGuessRadioButton
            // 
            this.gameCoinFlipGuessRadioButton.AutoSize = true;
            this.gameCoinFlipGuessRadioButton.Checked = true;
            this.gameCoinFlipGuessRadioButton.Location = new System.Drawing.Point(6, 20);
            this.gameCoinFlipGuessRadioButton.Name = "gameCoinFlipGuessRadioButton";
            this.gameCoinFlipGuessRadioButton.Size = new System.Drawing.Size(93, 17);
            this.gameCoinFlipGuessRadioButton.TabIndex = 2;
            this.gameCoinFlipGuessRadioButton.TabStop = true;
            this.gameCoinFlipGuessRadioButton.Text = "Coin flip guess";
            this.gameCoinFlipGuessRadioButton.UseVisualStyleBackColor = true;
            // 
            // AIOptionsGroupBox
            // 
            this.AIOptionsGroupBox.Controls.Add(this.recursionDepthLabel);
            this.AIOptionsGroupBox.Controls.Add(this.recursionDepthMaskedTextBox);
            this.AIOptionsGroupBox.Controls.Add(this.purgeDynamicHeuristicDataButton);
            this.AIOptionsGroupBox.Controls.Add(this.deleteStatisticsButton);
            this.AIOptionsGroupBox.Controls.Add(this.saveStatisticsCheckBox);
            this.AIOptionsGroupBox.Controls.Add(this.numberOfRunsMaskedTextBox);
            this.AIOptionsGroupBox.Controls.Add(this.numberOfRunsLabel);
            this.AIOptionsGroupBox.Location = new System.Drawing.Point(12, 319);
            this.AIOptionsGroupBox.Name = "AIOptionsGroupBox";
            this.AIOptionsGroupBox.Size = new System.Drawing.Size(366, 92);
            this.AIOptionsGroupBox.TabIndex = 6;
            this.AIOptionsGroupBox.TabStop = false;
            this.AIOptionsGroupBox.Text = "AI options";
            this.AIOptionsGroupBox.Visible = false;
            // 
            // clearConsoleButton
            // 
            this.clearConsoleButton.Location = new System.Drawing.Point(391, 349);
            this.clearConsoleButton.Name = "clearConsoleButton";
            this.clearConsoleButton.Size = new System.Drawing.Size(103, 28);
            this.clearConsoleButton.TabIndex = 7;
            this.clearConsoleButton.Text = "Clear console";
            this.clearConsoleButton.UseVisualStyleBackColor = true;
            this.clearConsoleButton.Click += new System.EventHandler(this.clearConsoleButton_Click);
            // 
            // purgeLogsButton
            // 
            this.purgeLogsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purgeLogsButton.ForeColor = System.Drawing.Color.Red;
            this.purgeLogsButton.Location = new System.Drawing.Point(506, 349);
            this.purgeLogsButton.Name = "purgeLogsButton";
            this.purgeLogsButton.Size = new System.Drawing.Size(103, 28);
            this.purgeLogsButton.TabIndex = 8;
            this.purgeLogsButton.Text = "Purge logs";
            this.purgeLogsButton.UseVisualStyleBackColor = true;
            this.purgeLogsButton.Click += new System.EventHandler(this.purgeLogsButton_Click);
            // 
            // numberOfRunsLabel
            // 
            this.numberOfRunsLabel.AutoSize = true;
            this.numberOfRunsLabel.Location = new System.Drawing.Point(67, 22);
            this.numberOfRunsLabel.Name = "numberOfRunsLabel";
            this.numberOfRunsLabel.Size = new System.Drawing.Size(84, 13);
            this.numberOfRunsLabel.TabIndex = 0;
            this.numberOfRunsLabel.Text = "Numbers of runs";
            // 
            // numberOfRunsMaskedTextBox
            // 
            this.numberOfRunsMaskedTextBox.Location = new System.Drawing.Point(7, 19);
            this.numberOfRunsMaskedTextBox.Mask = "00000";
            this.numberOfRunsMaskedTextBox.Name = "numberOfRunsMaskedTextBox";
            this.numberOfRunsMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numberOfRunsMaskedTextBox.Size = new System.Drawing.Size(54, 20);
            this.numberOfRunsMaskedTextBox.TabIndex = 7;
            this.numberOfRunsMaskedTextBox.Leave += new System.EventHandler(this.numberOfRunsMaskedTextBox_Leave);
            // 
            // saveStatisticsCheckBox
            // 
            this.saveStatisticsCheckBox.AutoSize = true;
            this.saveStatisticsCheckBox.Checked = true;
            this.saveStatisticsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveStatisticsCheckBox.Location = new System.Drawing.Point(7, 69);
            this.saveStatisticsCheckBox.Name = "saveStatisticsCheckBox";
            this.saveStatisticsCheckBox.Size = new System.Drawing.Size(154, 17);
            this.saveStatisticsCheckBox.TabIndex = 8;
            this.saveStatisticsCheckBox.Text = "Save statistics after the run";
            this.saveStatisticsCheckBox.UseVisualStyleBackColor = true;
            this.saveStatisticsCheckBox.CheckedChanged += new System.EventHandler(this.saveStatisticsCheckBox_CheckedChanged);
            // 
            // deleteStatisticsButton
            // 
            this.deleteStatisticsButton.ForeColor = System.Drawing.Color.Red;
            this.deleteStatisticsButton.Location = new System.Drawing.Point(167, 19);
            this.deleteStatisticsButton.Name = "deleteStatisticsButton";
            this.deleteStatisticsButton.Size = new System.Drawing.Size(193, 26);
            this.deleteStatisticsButton.TabIndex = 9;
            this.deleteStatisticsButton.Text = "Delete statistics";
            this.deleteStatisticsButton.UseVisualStyleBackColor = true;
            this.deleteStatisticsButton.Click += new System.EventHandler(this.deleteStatisticsButton_Click);
            // 
            // purgeDynamicHeuristicDataButton
            // 
            this.purgeDynamicHeuristicDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purgeDynamicHeuristicDataButton.ForeColor = System.Drawing.Color.Red;
            this.purgeDynamicHeuristicDataButton.Location = new System.Drawing.Point(167, 55);
            this.purgeDynamicHeuristicDataButton.Name = "purgeDynamicHeuristicDataButton";
            this.purgeDynamicHeuristicDataButton.Size = new System.Drawing.Size(193, 26);
            this.purgeDynamicHeuristicDataButton.TabIndex = 10;
            this.purgeDynamicHeuristicDataButton.Text = "Purge dynamic heuristic data";
            this.purgeDynamicHeuristicDataButton.UseVisualStyleBackColor = true;
            this.purgeDynamicHeuristicDataButton.Visible = false;
            this.purgeDynamicHeuristicDataButton.Click += new System.EventHandler(this.purgeDynamicHeuristicDataButton_Click);
            // 
            // recursionDepthMaskedTextBox
            // 
            this.recursionDepthMaskedTextBox.Location = new System.Drawing.Point(7, 43);
            this.recursionDepthMaskedTextBox.Mask = "0";
            this.recursionDepthMaskedTextBox.Name = "recursionDepthMaskedTextBox";
            this.recursionDepthMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.recursionDepthMaskedTextBox.Size = new System.Drawing.Size(20, 20);
            this.recursionDepthMaskedTextBox.TabIndex = 11;
            this.recursionDepthMaskedTextBox.Leave += new System.EventHandler(this.recursionDepthMaskedTextBox_Leave);
            // 
            // recursionDepthLabel
            // 
            this.recursionDepthLabel.AutoSize = true;
            this.recursionDepthLabel.Location = new System.Drawing.Point(33, 46);
            this.recursionDepthLabel.Name = "recursionDepthLabel";
            this.recursionDepthLabel.Size = new System.Drawing.Size(124, 13);
            this.recursionDepthLabel.TabIndex = 12;
            this.recursionDepthLabel.Text = "Maximal recursion depth ";
            // 
            // DynamicHeuristicAlgorithmRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 423);
            this.Controls.Add(this.purgeLogsButton);
            this.Controls.Add(this.clearConsoleButton);
            this.Controls.Add(this.AIOptionsGroupBox);
            this.Controls.Add(this.chooseGameGroupBox);
            this.Controls.Add(this.setHeuristicsGroupBox);
            this.Controls.Add(this.modeGroupBox);
            this.Controls.Add(this.consoleOutputTextBox);
            this.Controls.Add(this.playButton);
            this.Name = "DynamicHeuristicAlgorithmRunner";
            this.Text = "Dynamic heuristic algorithm runner";
            this.modeGroupBox.ResumeLayout(false);
            this.modeGroupBox.PerformLayout();
            this.setHeuristicsGroupBox.ResumeLayout(false);
            this.setHeuristicsGroupBox.PerformLayout();
            this.chooseGameGroupBox.ResumeLayout(false);
            this.chooseGameGroupBox.PerformLayout();
            this.AIOptionsGroupBox.ResumeLayout(false);
            this.AIOptionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.TextBox consoleOutputTextBox;
        private System.Windows.Forms.GroupBox modeGroupBox;
        private System.Windows.Forms.RadioButton playYourselfRadioButton;
        private System.Windows.Forms.RadioButton dynamicHeuristicRadioButton;
        private System.Windows.Forms.RadioButton setHeuristicsRadioButton;
        private System.Windows.Forms.GroupBox setHeuristicsGroupBox;
        private System.Windows.Forms.CheckBox numberOfMergesHeuristicCheckBox;
        private System.Windows.Forms.CheckBox nonMonotonicLinesPenaltyHeuristicCheckBox;
        private System.Windows.Forms.CheckBox largeValuesOnEdgeHeuristicCheckBox;
        private System.Windows.Forms.CheckBox openSquareBonusHeuristicCheckBox;
        private System.Windows.Forms.GroupBox chooseGameGroupBox;
        private System.Windows.Forms.RadioButton gameTicTacToeRadioButton;
        private System.Windows.Forms.MaskedTextBox openSquareBonusHeuristicWeightMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox numberOfMergesHeuristicWeightMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox nonMonotonicLinesPenaltyHeuristicWeightMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox largeValuesOnEdgeHeuristicWeightMaskedTextBox;
        private System.Windows.Forms.RadioButton game2048RadioButton;
        private System.Windows.Forms.RadioButton gameCoinFlipGuessRadioButton;
        private System.Windows.Forms.GroupBox AIOptionsGroupBox;
        private System.Windows.Forms.Button clearConsoleButton;
        private System.Windows.Forms.Button purgeLogsButton;
        private System.Windows.Forms.Button purgeDynamicHeuristicDataButton;
        private System.Windows.Forms.Button deleteStatisticsButton;
        private System.Windows.Forms.CheckBox saveStatisticsCheckBox;
        private System.Windows.Forms.MaskedTextBox numberOfRunsMaskedTextBox;
        private System.Windows.Forms.Label numberOfRunsLabel;
        private System.Windows.Forms.Label recursionDepthLabel;
        private System.Windows.Forms.MaskedTextBox recursionDepthMaskedTextBox;
    }
}

