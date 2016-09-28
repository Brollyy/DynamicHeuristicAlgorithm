namespace DynamicHeuristicAlgorithm.TicTacToe
{
    partial class TicTacToeRunner
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicTacToeRunner));
            this.startButton = new System.Windows.Forms.Button();
            this.automaticMovesCheckBox = new System.Windows.Forms.CheckBox();
            this.nextMoveButton = new System.Windows.Forms.Button();
            this.ticTacToeImageList = new System.Windows.Forms.ImageList(this.components);
            this.square11Button = new System.Windows.Forms.Button();
            this.square12Button = new System.Windows.Forms.Button();
            this.square13Button = new System.Windows.Forms.Button();
            this.square21Button = new System.Windows.Forms.Button();
            this.square22Button = new System.Windows.Forms.Button();
            this.square23Button = new System.Windows.Forms.Button();
            this.square31Button = new System.Windows.Forms.Button();
            this.square32Button = new System.Windows.Forms.Button();
            this.square33Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(125, 327);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(190, 46);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // automaticMovesCheckBox
            // 
            this.automaticMovesCheckBox.AutoSize = true;
            this.automaticMovesCheckBox.Checked = global::DynamicHeuristicAlgorithm.Properties.Settings.Default.TicTacToeAutomaticMoves;
            this.automaticMovesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::DynamicHeuristicAlgorithm.Properties.Settings.Default, "TicTacToeAutomaticMoves", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.automaticMovesCheckBox.Location = new System.Drawing.Point(12, 327);
            this.automaticMovesCheckBox.Name = "automaticMovesCheckBox";
            this.automaticMovesCheckBox.Size = new System.Drawing.Size(107, 17);
            this.automaticMovesCheckBox.TabIndex = 1;
            this.automaticMovesCheckBox.Text = "Automatic moves";
            this.automaticMovesCheckBox.UseVisualStyleBackColor = true;
            // 
            // nextMoveButton
            // 
            this.nextMoveButton.Enabled = false;
            this.nextMoveButton.Location = new System.Drawing.Point(12, 350);
            this.nextMoveButton.Name = "nextMoveButton";
            this.nextMoveButton.Size = new System.Drawing.Size(75, 23);
            this.nextMoveButton.TabIndex = 2;
            this.nextMoveButton.Text = "Next move";
            this.nextMoveButton.UseVisualStyleBackColor = true;
            this.nextMoveButton.Click += new System.EventHandler(this.nextMoveButton_Click);
            // 
            // ticTacToeImageList
            // 
            this.ticTacToeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ticTacToeImageList.ImageStream")));
            this.ticTacToeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ticTacToeImageList.Images.SetKeyName(0, "ticTacToeO.png");
            this.ticTacToeImageList.Images.SetKeyName(1, "ticTacToeX.png");
            this.ticTacToeImageList.Images.SetKeyName(2, "ticTacToeNone.png");
            // 
            // square11Button
            // 
            this.square11Button.Enabled = false;
            this.square11Button.ImageKey = "ticTacToeNone.png";
            this.square11Button.ImageList = this.ticTacToeImageList;
            this.square11Button.Location = new System.Drawing.Point(12, 12);
            this.square11Button.Name = "square11Button";
            this.square11Button.Size = new System.Drawing.Size(97, 97);
            this.square11Button.TabIndex = 3;
            this.square11Button.UseVisualStyleBackColor = true;
            this.square11Button.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // square12Button
            // 
            this.square12Button.Enabled = false;
            this.square12Button.ImageKey = "ticTacToeNone.png";
            this.square12Button.ImageList = this.ticTacToeImageList;
            this.square12Button.Location = new System.Drawing.Point(115, 12);
            this.square12Button.Name = "square12Button";
            this.square12Button.Size = new System.Drawing.Size(97, 97);
            this.square12Button.TabIndex = 4;
            this.square12Button.UseVisualStyleBackColor = true;
            this.square12Button.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // square13Button
            // 
            this.square13Button.Enabled = false;
            this.square13Button.ImageKey = "ticTacToeNone.png";
            this.square13Button.ImageList = this.ticTacToeImageList;
            this.square13Button.Location = new System.Drawing.Point(218, 12);
            this.square13Button.Name = "square13Button";
            this.square13Button.Size = new System.Drawing.Size(97, 97);
            this.square13Button.TabIndex = 5;
            this.square13Button.UseVisualStyleBackColor = true;
            this.square13Button.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // square21Button
            // 
            this.square21Button.Enabled = false;
            this.square21Button.ImageKey = "ticTacToeNone.png";
            this.square21Button.ImageList = this.ticTacToeImageList;
            this.square21Button.Location = new System.Drawing.Point(12, 115);
            this.square21Button.Name = "square21Button";
            this.square21Button.Size = new System.Drawing.Size(97, 97);
            this.square21Button.TabIndex = 6;
            this.square21Button.UseVisualStyleBackColor = true;
            this.square21Button.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // square22Button
            // 
            this.square22Button.Enabled = false;
            this.square22Button.ImageKey = "ticTacToeNone.png";
            this.square22Button.ImageList = this.ticTacToeImageList;
            this.square22Button.Location = new System.Drawing.Point(115, 115);
            this.square22Button.Name = "square22Button";
            this.square22Button.Size = new System.Drawing.Size(97, 97);
            this.square22Button.TabIndex = 7;
            this.square22Button.UseVisualStyleBackColor = true;
            this.square22Button.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // square23Button
            // 
            this.square23Button.Enabled = false;
            this.square23Button.ImageKey = "ticTacToeNone.png";
            this.square23Button.ImageList = this.ticTacToeImageList;
            this.square23Button.Location = new System.Drawing.Point(218, 115);
            this.square23Button.Name = "square23Button";
            this.square23Button.Size = new System.Drawing.Size(97, 97);
            this.square23Button.TabIndex = 8;
            this.square23Button.UseVisualStyleBackColor = true;
            this.square23Button.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // square31Button
            // 
            this.square31Button.Enabled = false;
            this.square31Button.ImageKey = "ticTacToeNone.png";
            this.square31Button.ImageList = this.ticTacToeImageList;
            this.square31Button.Location = new System.Drawing.Point(12, 218);
            this.square31Button.Name = "square31Button";
            this.square31Button.Size = new System.Drawing.Size(97, 97);
            this.square31Button.TabIndex = 9;
            this.square31Button.UseVisualStyleBackColor = true;
            this.square31Button.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // square32Button
            // 
            this.square32Button.Enabled = false;
            this.square32Button.ImageKey = "ticTacToeNone.png";
            this.square32Button.ImageList = this.ticTacToeImageList;
            this.square32Button.Location = new System.Drawing.Point(115, 218);
            this.square32Button.Name = "square32Button";
            this.square32Button.Size = new System.Drawing.Size(97, 97);
            this.square32Button.TabIndex = 10;
            this.square32Button.UseVisualStyleBackColor = true;
            this.square32Button.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // square33Button
            // 
            this.square33Button.Enabled = false;
            this.square33Button.ImageKey = "ticTacToeNone.png";
            this.square33Button.ImageList = this.ticTacToeImageList;
            this.square33Button.Location = new System.Drawing.Point(218, 218);
            this.square33Button.Name = "square33Button";
            this.square33Button.Size = new System.Drawing.Size(97, 97);
            this.square33Button.TabIndex = 11;
            this.square33Button.UseVisualStyleBackColor = true;
            this.square33Button.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // TicTacToeRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 382);
            this.Controls.Add(this.square33Button);
            this.Controls.Add(this.square32Button);
            this.Controls.Add(this.square31Button);
            this.Controls.Add(this.square23Button);
            this.Controls.Add(this.square22Button);
            this.Controls.Add(this.square21Button);
            this.Controls.Add(this.square13Button);
            this.Controls.Add(this.square12Button);
            this.Controls.Add(this.square11Button);
            this.Controls.Add(this.nextMoveButton);
            this.Controls.Add(this.automaticMovesCheckBox);
            this.Controls.Add(this.startButton);
            this.Name = "TicTacToeRunner";
            this.Text = "TicTacToeRunner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox automaticMovesCheckBox;
        private System.Windows.Forms.Button nextMoveButton;
        private System.Windows.Forms.ImageList ticTacToeImageList;
        private System.Windows.Forms.Button square11Button;
        private System.Windows.Forms.Button square12Button;
        private System.Windows.Forms.Button square13Button;
        private System.Windows.Forms.Button square21Button;
        private System.Windows.Forms.Button square22Button;
        private System.Windows.Forms.Button square23Button;
        private System.Windows.Forms.Button square31Button;
        private System.Windows.Forms.Button square32Button;
        private System.Windows.Forms.Button square33Button;
    }
}