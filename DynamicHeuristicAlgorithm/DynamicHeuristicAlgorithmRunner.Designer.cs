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
            this.numberOfMergesHeuristicWeightCounter = new System.Windows.Forms.NumericUpDown();
            this.nonMonotonicLinesPenaltyHeuristicWeightCounter = new System.Windows.Forms.NumericUpDown();
            this.largeValuesOnEdgeHeuristicWeightCounter = new System.Windows.Forms.NumericUpDown();
            this.openSquaresBonusHeuristicWeightCounter = new System.Windows.Forms.NumericUpDown();
            this.numberOfMergesHeuristicCheckBox = new System.Windows.Forms.CheckBox();
            this.nonMonotonicLinesPenaltyHeuristicCheckBox = new System.Windows.Forms.CheckBox();
            this.largeValuesOnEdgeHeuristicCheckBox = new System.Windows.Forms.CheckBox();
            this.openSquareBonusHeuristicCheckBox = new System.Windows.Forms.CheckBox();
            this.dynamicHeuristicsGroupBox = new System.Windows.Forms.GroupBox();
            this.neuralNetworkDynamicHeuristicRadioButton = new System.Windows.Forms.RadioButton();
            this.mapDynamicHeuristicRadioButton = new System.Windows.Forms.RadioButton();
            this.purgeDynamicHeuristicDataButton = new System.Windows.Forms.Button();
            this.chooseGameGroupBox = new System.Windows.Forms.GroupBox();
            this.game2048RadioButton = new System.Windows.Forms.RadioButton();
            this.gameTicTacToeRadioButton = new System.Windows.Forms.RadioButton();
            this.AIOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.openStatisticsButton = new System.Windows.Forms.Button();
            this.recursionDepthCounter = new System.Windows.Forms.NumericUpDown();
            this.numberOfRunsCounter = new System.Windows.Forms.NumericUpDown();
            this.recursionDepthLabel = new System.Windows.Forms.Label();
            this.deleteStatisticsButton = new System.Windows.Forms.Button();
            this.saveStatisticsCheckBox = new System.Windows.Forms.CheckBox();
            this.numberOfRunsLabel = new System.Windows.Forms.Label();
            this.clearConsoleButton = new System.Windows.Forms.Button();
            this.purgeLogsButton = new System.Windows.Forms.Button();
            this.playInViewButton = new System.Windows.Forms.Button();
            this.openLogsButton = new System.Windows.Forms.Button();
            this.modeGroupBox.SuspendLayout();
            this.setHeuristicsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfMergesHeuristicWeightCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonMonotonicLinesPenaltyHeuristicWeightCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeValuesOnEdgeHeuristicWeightCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openSquaresBonusHeuristicWeightCounter)).BeginInit();
            this.dynamicHeuristicsGroupBox.SuspendLayout();
            this.chooseGameGroupBox.SuspendLayout();
            this.AIOptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recursionDepthCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRunsCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.Enabled = false;
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(384, 349);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(166, 51);
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
            this.consoleOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleOutputTextBox.Size = new System.Drawing.Size(693, 193);
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
            this.playYourselfRadioButton.CheckedChanged += new System.EventHandler(this.playYourselfRadioButton_CheckedChanged);
            // 
            // setHeuristicsGroupBox
            // 
            this.setHeuristicsGroupBox.Controls.Add(this.numberOfMergesHeuristicWeightCounter);
            this.setHeuristicsGroupBox.Controls.Add(this.nonMonotonicLinesPenaltyHeuristicWeightCounter);
            this.setHeuristicsGroupBox.Controls.Add(this.largeValuesOnEdgeHeuristicWeightCounter);
            this.setHeuristicsGroupBox.Controls.Add(this.openSquaresBonusHeuristicWeightCounter);
            this.setHeuristicsGroupBox.Controls.Add(this.numberOfMergesHeuristicCheckBox);
            this.setHeuristicsGroupBox.Controls.Add(this.nonMonotonicLinesPenaltyHeuristicCheckBox);
            this.setHeuristicsGroupBox.Controls.Add(this.largeValuesOnEdgeHeuristicCheckBox);
            this.setHeuristicsGroupBox.Controls.Add(this.openSquareBonusHeuristicCheckBox);
            this.setHeuristicsGroupBox.Location = new System.Drawing.Point(384, 212);
            this.setHeuristicsGroupBox.Name = "setHeuristicsGroupBox";
            this.setHeuristicsGroupBox.Size = new System.Drawing.Size(242, 118);
            this.setHeuristicsGroupBox.TabIndex = 4;
            this.setHeuristicsGroupBox.TabStop = false;
            this.setHeuristicsGroupBox.Text = "2048 Heuristics";
            this.setHeuristicsGroupBox.Visible = false;
            // 
            // numberOfMergesHeuristicWeightCounter
            // 
            this.numberOfMergesHeuristicWeightCounter.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DynamicHeuristicAlgorithm.Properties.Settings.Default, "NumberOfMergesHeuristicWeight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numberOfMergesHeuristicWeightCounter.DecimalPlaces = 1;
            this.numberOfMergesHeuristicWeightCounter.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numberOfMergesHeuristicWeightCounter.Location = new System.Drawing.Point(172, 91);
            this.numberOfMergesHeuristicWeightCounter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numberOfMergesHeuristicWeightCounter.Name = "numberOfMergesHeuristicWeightCounter";
            this.numberOfMergesHeuristicWeightCounter.Size = new System.Drawing.Size(64, 20);
            this.numberOfMergesHeuristicWeightCounter.TabIndex = 13;
            this.numberOfMergesHeuristicWeightCounter.Value = global::DynamicHeuristicAlgorithm.Properties.Settings.Default.NumberOfMergesHeuristicWeight;
            this.numberOfMergesHeuristicWeightCounter.Visible = false;
            // 
            // nonMonotonicLinesPenaltyHeuristicWeightCounter
            // 
            this.nonMonotonicLinesPenaltyHeuristicWeightCounter.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DynamicHeuristicAlgorithm.Properties.Settings.Default, "NonMonotonicLinesPenaltyHeuristicWeight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nonMonotonicLinesPenaltyHeuristicWeightCounter.DecimalPlaces = 1;
            this.nonMonotonicLinesPenaltyHeuristicWeightCounter.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nonMonotonicLinesPenaltyHeuristicWeightCounter.Location = new System.Drawing.Point(172, 67);
            this.nonMonotonicLinesPenaltyHeuristicWeightCounter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nonMonotonicLinesPenaltyHeuristicWeightCounter.Name = "nonMonotonicLinesPenaltyHeuristicWeightCounter";
            this.nonMonotonicLinesPenaltyHeuristicWeightCounter.Size = new System.Drawing.Size(64, 20);
            this.nonMonotonicLinesPenaltyHeuristicWeightCounter.TabIndex = 12;
            this.nonMonotonicLinesPenaltyHeuristicWeightCounter.Value = global::DynamicHeuristicAlgorithm.Properties.Settings.Default.NonMonotonicLinesPenaltyHeuristicWeight;
            this.nonMonotonicLinesPenaltyHeuristicWeightCounter.Visible = false;
            // 
            // largeValuesOnEdgeHeuristicWeightCounter
            // 
            this.largeValuesOnEdgeHeuristicWeightCounter.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DynamicHeuristicAlgorithm.Properties.Settings.Default, "LargeValuesOnEdgeHeuristicWeight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.largeValuesOnEdgeHeuristicWeightCounter.DecimalPlaces = 1;
            this.largeValuesOnEdgeHeuristicWeightCounter.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.largeValuesOnEdgeHeuristicWeightCounter.Location = new System.Drawing.Point(172, 44);
            this.largeValuesOnEdgeHeuristicWeightCounter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.largeValuesOnEdgeHeuristicWeightCounter.Name = "largeValuesOnEdgeHeuristicWeightCounter";
            this.largeValuesOnEdgeHeuristicWeightCounter.Size = new System.Drawing.Size(64, 20);
            this.largeValuesOnEdgeHeuristicWeightCounter.TabIndex = 11;
            this.largeValuesOnEdgeHeuristicWeightCounter.Value = global::DynamicHeuristicAlgorithm.Properties.Settings.Default.LargeValuesOnEdgeHeuristicWeight;
            this.largeValuesOnEdgeHeuristicWeightCounter.Visible = false;
            // 
            // openSquaresBonusHeuristicWeightCounter
            // 
            this.openSquaresBonusHeuristicWeightCounter.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DynamicHeuristicAlgorithm.Properties.Settings.Default, "OpenSquaresBonusHeuristicWeight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.openSquaresBonusHeuristicWeightCounter.DecimalPlaces = 1;
            this.openSquaresBonusHeuristicWeightCounter.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.openSquaresBonusHeuristicWeightCounter.Location = new System.Drawing.Point(172, 20);
            this.openSquaresBonusHeuristicWeightCounter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.openSquaresBonusHeuristicWeightCounter.Name = "openSquaresBonusHeuristicWeightCounter";
            this.openSquaresBonusHeuristicWeightCounter.Size = new System.Drawing.Size(64, 20);
            this.openSquaresBonusHeuristicWeightCounter.TabIndex = 10;
            this.openSquaresBonusHeuristicWeightCounter.Value = global::DynamicHeuristicAlgorithm.Properties.Settings.Default.OpenSquaresBonusHeuristicWeight;
            this.openSquaresBonusHeuristicWeightCounter.Visible = false;
            // 
            // numberOfMergesHeuristicCheckBox
            // 
            this.numberOfMergesHeuristicCheckBox.AutoSize = true;
            this.numberOfMergesHeuristicCheckBox.Checked = global::DynamicHeuristicAlgorithm.Properties.Settings.Default.NumberOfMergesHeuristic;
            this.numberOfMergesHeuristicCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::DynamicHeuristicAlgorithm.Properties.Settings.Default, "NumberOfMergesHeuristic", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numberOfMergesHeuristicCheckBox.Location = new System.Drawing.Point(7, 92);
            this.numberOfMergesHeuristicCheckBox.Name = "numberOfMergesHeuristicCheckBox";
            this.numberOfMergesHeuristicCheckBox.Size = new System.Drawing.Size(112, 17);
            this.numberOfMergesHeuristicCheckBox.TabIndex = 3;
            this.numberOfMergesHeuristicCheckBox.Text = "Number of merges";
            this.numberOfMergesHeuristicCheckBox.UseVisualStyleBackColor = true;
            this.numberOfMergesHeuristicCheckBox.CheckedChanged += new System.EventHandler(this.numberOfMergesHeuristicCheckBox_CheckedChanged);
            // 
            // nonMonotonicLinesPenaltyHeuristicCheckBox
            // 
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.AutoSize = true;
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.Checked = global::DynamicHeuristicAlgorithm.Properties.Settings.Default.NonMonotonicLinesPenaltyHeuristic;
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::DynamicHeuristicAlgorithm.Properties.Settings.Default, "NonMonotonicLinesPenaltyHeuristic", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.Location = new System.Drawing.Point(7, 68);
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.Name = "nonMonotonicLinesPenaltyHeuristicCheckBox";
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.Size = new System.Drawing.Size(159, 17);
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.TabIndex = 2;
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.Text = "Non-monotonic lines penalty";
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.UseVisualStyleBackColor = true;
            this.nonMonotonicLinesPenaltyHeuristicCheckBox.CheckedChanged += new System.EventHandler(this.nonMonotonicLinesPenaltyHeuristicCheckBox_CheckedChanged);
            // 
            // largeValuesOnEdgeHeuristicCheckBox
            // 
            this.largeValuesOnEdgeHeuristicCheckBox.AutoSize = true;
            this.largeValuesOnEdgeHeuristicCheckBox.Checked = global::DynamicHeuristicAlgorithm.Properties.Settings.Default.LargeValuesOnEdgeHeuristic;
            this.largeValuesOnEdgeHeuristicCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::DynamicHeuristicAlgorithm.Properties.Settings.Default, "LargeValuesOnEdgeHeuristic", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.largeValuesOnEdgeHeuristicCheckBox.Location = new System.Drawing.Point(7, 44);
            this.largeValuesOnEdgeHeuristicCheckBox.Name = "largeValuesOnEdgeHeuristicCheckBox";
            this.largeValuesOnEdgeHeuristicCheckBox.Size = new System.Drawing.Size(129, 17);
            this.largeValuesOnEdgeHeuristicCheckBox.TabIndex = 1;
            this.largeValuesOnEdgeHeuristicCheckBox.Text = "Large values on edge";
            this.largeValuesOnEdgeHeuristicCheckBox.UseVisualStyleBackColor = true;
            this.largeValuesOnEdgeHeuristicCheckBox.CheckedChanged += new System.EventHandler(this.largeValuesOnEdgeHeuristicCheckBox_CheckedChanged);
            // 
            // openSquareBonusHeuristicCheckBox
            // 
            this.openSquareBonusHeuristicCheckBox.AutoSize = true;
            this.openSquareBonusHeuristicCheckBox.Checked = global::DynamicHeuristicAlgorithm.Properties.Settings.Default.OpenSquaresBonusHeuristic;
            this.openSquareBonusHeuristicCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::DynamicHeuristicAlgorithm.Properties.Settings.Default, "OpenSquaresBonusHeuristic", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.openSquareBonusHeuristicCheckBox.Location = new System.Drawing.Point(7, 20);
            this.openSquareBonusHeuristicCheckBox.Name = "openSquareBonusHeuristicCheckBox";
            this.openSquareBonusHeuristicCheckBox.Size = new System.Drawing.Size(119, 17);
            this.openSquareBonusHeuristicCheckBox.TabIndex = 0;
            this.openSquareBonusHeuristicCheckBox.Text = "Open square bonus";
            this.openSquareBonusHeuristicCheckBox.UseVisualStyleBackColor = true;
            this.openSquareBonusHeuristicCheckBox.CheckedChanged += new System.EventHandler(this.openSquareBonusHeuristicCheckBox_CheckedChanged);
            // 
            // dynamicHeuristicsGroupBox
            // 
            this.dynamicHeuristicsGroupBox.Controls.Add(this.neuralNetworkDynamicHeuristicRadioButton);
            this.dynamicHeuristicsGroupBox.Controls.Add(this.mapDynamicHeuristicRadioButton);
            this.dynamicHeuristicsGroupBox.Controls.Add(this.purgeDynamicHeuristicDataButton);
            this.dynamicHeuristicsGroupBox.Location = new System.Drawing.Point(384, 212);
            this.dynamicHeuristicsGroupBox.Name = "dynamicHeuristicsGroupBox";
            this.dynamicHeuristicsGroupBox.Size = new System.Drawing.Size(242, 118);
            this.dynamicHeuristicsGroupBox.TabIndex = 14;
            this.dynamicHeuristicsGroupBox.TabStop = false;
            this.dynamicHeuristicsGroupBox.Text = "Dynamic heuristics";
            this.dynamicHeuristicsGroupBox.Visible = false;
            // 
            // neuralNetworkDynamicHeuristicRadioButton
            // 
            this.neuralNetworkDynamicHeuristicRadioButton.AutoSize = true;
            this.neuralNetworkDynamicHeuristicRadioButton.Location = new System.Drawing.Point(7, 44);
            this.neuralNetworkDynamicHeuristicRadioButton.Name = "neuralNetworkDynamicHeuristicRadioButton";
            this.neuralNetworkDynamicHeuristicRadioButton.Size = new System.Drawing.Size(120, 17);
            this.neuralNetworkDynamicHeuristicRadioButton.TabIndex = 1;
            this.neuralNetworkDynamicHeuristicRadioButton.Text = "MLP neural network";
            this.neuralNetworkDynamicHeuristicRadioButton.UseVisualStyleBackColor = true;
            // 
            // mapDynamicHeuristicRadioButton
            // 
            this.mapDynamicHeuristicRadioButton.AutoSize = true;
            this.mapDynamicHeuristicRadioButton.Checked = true;
            this.mapDynamicHeuristicRadioButton.Location = new System.Drawing.Point(7, 20);
            this.mapDynamicHeuristicRadioButton.Name = "mapDynamicHeuristicRadioButton";
            this.mapDynamicHeuristicRadioButton.Size = new System.Drawing.Size(185, 17);
            this.mapDynamicHeuristicRadioButton.TabIndex = 0;
            this.mapDynamicHeuristicRadioButton.TabStop = true;
            this.mapDynamicHeuristicRadioButton.Text = "Mapping game states to a number";
            this.mapDynamicHeuristicRadioButton.UseVisualStyleBackColor = true;
            // 
            // purgeDynamicHeuristicDataButton
            // 
            this.purgeDynamicHeuristicDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purgeDynamicHeuristicDataButton.ForeColor = System.Drawing.Color.Red;
            this.purgeDynamicHeuristicDataButton.Location = new System.Drawing.Point(7, 86);
            this.purgeDynamicHeuristicDataButton.Name = "purgeDynamicHeuristicDataButton";
            this.purgeDynamicHeuristicDataButton.Size = new System.Drawing.Size(193, 26);
            this.purgeDynamicHeuristicDataButton.TabIndex = 10;
            this.purgeDynamicHeuristicDataButton.Text = "Purge dynamic heuristic data";
            this.purgeDynamicHeuristicDataButton.UseVisualStyleBackColor = true;
            this.purgeDynamicHeuristicDataButton.Click += new System.EventHandler(this.purgeDynamicHeuristicDataButton_Click);
            // 
            // chooseGameGroupBox
            // 
            this.chooseGameGroupBox.Controls.Add(this.game2048RadioButton);
            this.chooseGameGroupBox.Controls.Add(this.gameTicTacToeRadioButton);
            this.chooseGameGroupBox.Location = new System.Drawing.Point(164, 212);
            this.chooseGameGroupBox.Name = "chooseGameGroupBox";
            this.chooseGameGroupBox.Size = new System.Drawing.Size(214, 100);
            this.chooseGameGroupBox.TabIndex = 5;
            this.chooseGameGroupBox.TabStop = false;
            this.chooseGameGroupBox.Text = "Game";
            // 
            // game2048RadioButton
            // 
            this.game2048RadioButton.AutoSize = true;
            this.game2048RadioButton.Location = new System.Drawing.Point(6, 43);
            this.game2048RadioButton.Name = "game2048RadioButton";
            this.game2048RadioButton.Size = new System.Drawing.Size(49, 17);
            this.game2048RadioButton.TabIndex = 1;
            this.game2048RadioButton.Text = "2048";
            this.game2048RadioButton.UseVisualStyleBackColor = true;
            this.game2048RadioButton.CheckedChanged += new System.EventHandler(this.game2048RadioButton_CheckedChanged);
            // 
            // gameTicTacToeRadioButton
            // 
            this.gameTicTacToeRadioButton.AutoSize = true;
            this.gameTicTacToeRadioButton.Checked = true;
            this.gameTicTacToeRadioButton.Location = new System.Drawing.Point(6, 20);
            this.gameTicTacToeRadioButton.Name = "gameTicTacToeRadioButton";
            this.gameTicTacToeRadioButton.Size = new System.Drawing.Size(84, 17);
            this.gameTicTacToeRadioButton.TabIndex = 0;
            this.gameTicTacToeRadioButton.TabStop = true;
            this.gameTicTacToeRadioButton.Text = "Tic Tac Toe";
            this.gameTicTacToeRadioButton.UseVisualStyleBackColor = true;
            // 
            // AIOptionsGroupBox
            // 
            this.AIOptionsGroupBox.Controls.Add(this.openStatisticsButton);
            this.AIOptionsGroupBox.Controls.Add(this.recursionDepthCounter);
            this.AIOptionsGroupBox.Controls.Add(this.numberOfRunsCounter);
            this.AIOptionsGroupBox.Controls.Add(this.recursionDepthLabel);
            this.AIOptionsGroupBox.Controls.Add(this.deleteStatisticsButton);
            this.AIOptionsGroupBox.Controls.Add(this.saveStatisticsCheckBox);
            this.AIOptionsGroupBox.Controls.Add(this.numberOfRunsLabel);
            this.AIOptionsGroupBox.Location = new System.Drawing.Point(12, 314);
            this.AIOptionsGroupBox.Name = "AIOptionsGroupBox";
            this.AIOptionsGroupBox.Size = new System.Drawing.Size(366, 97);
            this.AIOptionsGroupBox.TabIndex = 6;
            this.AIOptionsGroupBox.TabStop = false;
            this.AIOptionsGroupBox.Text = "AI options";
            this.AIOptionsGroupBox.Visible = false;
            // 
            // openStatisticsButton
            // 
            this.openStatisticsButton.Location = new System.Drawing.Point(213, 21);
            this.openStatisticsButton.Name = "openStatisticsButton";
            this.openStatisticsButton.Size = new System.Drawing.Size(147, 23);
            this.openStatisticsButton.TabIndex = 15;
            this.openStatisticsButton.Text = "Open statistics";
            this.openStatisticsButton.UseVisualStyleBackColor = true;
            this.openStatisticsButton.Click += new System.EventHandler(this.openStatisticsButton_Click);
            // 
            // recursionDepthCounter
            // 
            this.recursionDepthCounter.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DynamicHeuristicAlgorithm.Properties.Settings.Default, "MaximalRecursionDepth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.recursionDepthCounter.Location = new System.Drawing.Point(7, 24);
            this.recursionDepthCounter.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.recursionDepthCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recursionDepthCounter.Name = "recursionDepthCounter";
            this.recursionDepthCounter.Size = new System.Drawing.Size(54, 20);
            this.recursionDepthCounter.TabIndex = 14;
            this.recursionDepthCounter.Value = global::DynamicHeuristicAlgorithm.Properties.Settings.Default.MaximalRecursionDepth;
            // 
            // numberOfRunsCounter
            // 
            this.numberOfRunsCounter.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DynamicHeuristicAlgorithm.Properties.Settings.Default, "NumberOfRuns", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numberOfRunsCounter.Location = new System.Drawing.Point(7, 47);
            this.numberOfRunsCounter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numberOfRunsCounter.Name = "numberOfRunsCounter";
            this.numberOfRunsCounter.Size = new System.Drawing.Size(54, 20);
            this.numberOfRunsCounter.TabIndex = 13;
            this.numberOfRunsCounter.Value = global::DynamicHeuristicAlgorithm.Properties.Settings.Default.NumberOfRuns;
            // 
            // recursionDepthLabel
            // 
            this.recursionDepthLabel.AutoSize = true;
            this.recursionDepthLabel.Location = new System.Drawing.Point(67, 26);
            this.recursionDepthLabel.Name = "recursionDepthLabel";
            this.recursionDepthLabel.Size = new System.Drawing.Size(124, 13);
            this.recursionDepthLabel.TabIndex = 12;
            this.recursionDepthLabel.Text = "Maximal recursion depth ";
            // 
            // deleteStatisticsButton
            // 
            this.deleteStatisticsButton.ForeColor = System.Drawing.Color.Red;
            this.deleteStatisticsButton.Location = new System.Drawing.Point(213, 50);
            this.deleteStatisticsButton.Name = "deleteStatisticsButton";
            this.deleteStatisticsButton.Size = new System.Drawing.Size(147, 26);
            this.deleteStatisticsButton.TabIndex = 9;
            this.deleteStatisticsButton.Text = "Delete statistics";
            this.deleteStatisticsButton.UseVisualStyleBackColor = true;
            this.deleteStatisticsButton.Click += new System.EventHandler(this.deleteStatisticsButton_Click);
            // 
            // saveStatisticsCheckBox
            // 
            this.saveStatisticsCheckBox.AutoSize = true;
            this.saveStatisticsCheckBox.Checked = global::DynamicHeuristicAlgorithm.Properties.Settings.Default.SaveStatistics;
            this.saveStatisticsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::DynamicHeuristicAlgorithm.Properties.Settings.Default, "SaveStatistics", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.saveStatisticsCheckBox.Location = new System.Drawing.Point(7, 69);
            this.saveStatisticsCheckBox.Name = "saveStatisticsCheckBox";
            this.saveStatisticsCheckBox.Size = new System.Drawing.Size(154, 17);
            this.saveStatisticsCheckBox.TabIndex = 8;
            this.saveStatisticsCheckBox.Text = "Save statistics after the run";
            this.saveStatisticsCheckBox.UseVisualStyleBackColor = true;
            // 
            // numberOfRunsLabel
            // 
            this.numberOfRunsLabel.AutoSize = true;
            this.numberOfRunsLabel.Location = new System.Drawing.Point(67, 49);
            this.numberOfRunsLabel.Name = "numberOfRunsLabel";
            this.numberOfRunsLabel.Size = new System.Drawing.Size(84, 13);
            this.numberOfRunsLabel.TabIndex = 0;
            this.numberOfRunsLabel.Text = "Numbers of runs";
            // 
            // clearConsoleButton
            // 
            this.clearConsoleButton.Location = new System.Drawing.Point(632, 259);
            this.clearConsoleButton.Name = "clearConsoleButton";
            this.clearConsoleButton.Size = new System.Drawing.Size(86, 28);
            this.clearConsoleButton.TabIndex = 7;
            this.clearConsoleButton.Text = "Clear console";
            this.clearConsoleButton.UseVisualStyleBackColor = true;
            this.clearConsoleButton.Click += new System.EventHandler(this.clearConsoleButton_Click);
            // 
            // purgeLogsButton
            // 
            this.purgeLogsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purgeLogsButton.ForeColor = System.Drawing.Color.Red;
            this.purgeLogsButton.Location = new System.Drawing.Point(632, 293);
            this.purgeLogsButton.Name = "purgeLogsButton";
            this.purgeLogsButton.Size = new System.Drawing.Size(86, 28);
            this.purgeLogsButton.TabIndex = 8;
            this.purgeLogsButton.Text = "Purge logs";
            this.purgeLogsButton.UseVisualStyleBackColor = true;
            this.purgeLogsButton.Click += new System.EventHandler(this.purgeLogsButton_Click);
            // 
            // playInViewButton
            // 
            this.playInViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playInViewButton.Location = new System.Drawing.Point(556, 349);
            this.playInViewButton.Name = "playInViewButton";
            this.playInViewButton.Size = new System.Drawing.Size(162, 51);
            this.playInViewButton.TabIndex = 9;
            this.playInViewButton.Text = "Play in view";
            this.playInViewButton.UseVisualStyleBackColor = true;
            this.playInViewButton.Click += new System.EventHandler(this.playInViewButton_Click);
            // 
            // openLogsButton
            // 
            this.openLogsButton.Location = new System.Drawing.Point(632, 228);
            this.openLogsButton.Name = "openLogsButton";
            this.openLogsButton.Size = new System.Drawing.Size(86, 25);
            this.openLogsButton.TabIndex = 10;
            this.openLogsButton.Text = "Open logs";
            this.openLogsButton.UseVisualStyleBackColor = true;
            this.openLogsButton.Click += new System.EventHandler(this.openLogsButton_Click);
            // 
            // DynamicHeuristicAlgorithmRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 423);
            this.Controls.Add(this.openLogsButton);
            this.Controls.Add(this.playInViewButton);
            this.Controls.Add(this.purgeLogsButton);
            this.Controls.Add(this.clearConsoleButton);
            this.Controls.Add(this.AIOptionsGroupBox);
            this.Controls.Add(this.chooseGameGroupBox);
            this.Controls.Add(this.modeGroupBox);
            this.Controls.Add(this.consoleOutputTextBox);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.setHeuristicsGroupBox);
            this.Controls.Add(this.dynamicHeuristicsGroupBox);
            this.Name = "DynamicHeuristicAlgorithmRunner";
            this.Text = "Dynamic heuristic algorithm runner";
            this.modeGroupBox.ResumeLayout(false);
            this.modeGroupBox.PerformLayout();
            this.setHeuristicsGroupBox.ResumeLayout(false);
            this.setHeuristicsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfMergesHeuristicWeightCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonMonotonicLinesPenaltyHeuristicWeightCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeValuesOnEdgeHeuristicWeightCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openSquaresBonusHeuristicWeightCounter)).EndInit();
            this.dynamicHeuristicsGroupBox.ResumeLayout(false);
            this.dynamicHeuristicsGroupBox.PerformLayout();
            this.chooseGameGroupBox.ResumeLayout(false);
            this.chooseGameGroupBox.PerformLayout();
            this.AIOptionsGroupBox.ResumeLayout(false);
            this.AIOptionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recursionDepthCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRunsCounter)).EndInit();
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
        private System.Windows.Forms.RadioButton game2048RadioButton;
        private System.Windows.Forms.GroupBox AIOptionsGroupBox;
        private System.Windows.Forms.Button clearConsoleButton;
        private System.Windows.Forms.Button purgeLogsButton;
        private System.Windows.Forms.Button purgeDynamicHeuristicDataButton;
        private System.Windows.Forms.Button deleteStatisticsButton;
        private System.Windows.Forms.CheckBox saveStatisticsCheckBox;
        private System.Windows.Forms.Label numberOfRunsLabel;
        private System.Windows.Forms.Label recursionDepthLabel;
        private System.Windows.Forms.Button playInViewButton;
        private System.Windows.Forms.Button openLogsButton;
        private System.Windows.Forms.NumericUpDown recursionDepthCounter;
        private System.Windows.Forms.NumericUpDown numberOfRunsCounter;
        private System.Windows.Forms.NumericUpDown openSquaresBonusHeuristicWeightCounter;
        private System.Windows.Forms.NumericUpDown largeValuesOnEdgeHeuristicWeightCounter;
        private System.Windows.Forms.NumericUpDown nonMonotonicLinesPenaltyHeuristicWeightCounter;
        private System.Windows.Forms.NumericUpDown numberOfMergesHeuristicWeightCounter;
        private System.Windows.Forms.Button openStatisticsButton;
        private System.Windows.Forms.GroupBox dynamicHeuristicsGroupBox;
        private System.Windows.Forms.RadioButton neuralNetworkDynamicHeuristicRadioButton;
        private System.Windows.Forms.RadioButton mapDynamicHeuristicRadioButton;
    }
}

