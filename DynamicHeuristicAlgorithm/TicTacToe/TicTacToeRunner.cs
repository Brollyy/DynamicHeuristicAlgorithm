using DynamicHeuristicAlgorithmCore.GameInterface;
using DynamicHeuristicAlgorithmCore.PlayerInterface;
using DynamicHeuristicAlgorithmCore.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicHeuristicAlgorithm.TicTacToe
{
    public partial class TicTacToeRunner : Form, GameView
    {
        public TicTacToeRunner(TicTacToeGameImpl game, Player player)
        {
            InitializeComponent();
            this.game = game;
            this.player = player;
            squares = new Button[,]
            {
                { square11Button, square12Button, square13Button },
                { square21Button, square22Button, square23Button },
                { square31Button, square32Button, square33Button }
            };
            usedButtons = new bool[,]
            {
                { false, false, false },
                { false, false, false },
                { false, false, false }
            };
            Properties.Settings.Default.SettingChanging += ChangeStartButtonTextEventHandler;
            Properties.Settings.Default.SettingsSaving += ChangeStartButtonTextBackEventHandler;
        }

        private void ChangeStartButtonTextBackEventHandler(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired)
            {
                Logger.LogInfo("Settings saved.");
                startButton.Text = "Start";
            }
        }

        private void ChangeStartButtonTextEventHandler(object sender, SettingChangingEventArgs e)
        {
            if (!InvokeRequired)
            {
                startButton.Text = "Save settings and start";
            }
        }

        AutoResetEvent moveDoneEvent;
        AutoResetEvent manualMoveAcceptEvent;

        TicTacToeGameImpl game;
        Player player;
        Button[,] squares;
        bool[,] usedButtons;
        bool gamePlayed = false;

        private void squareButton_Click(object sender, EventArgs e)
        {
            MakeMoveOnButton((Button)sender);
            BlockUI();
            moveDoneEvent.Set();
        }

        private void MakeMoveOnButton(Button button)
        {
            if (button.InvokeRequired)
            {
                button.Invoke(new Action<Button>(MakeMoveOnButton));
            }
            else
            {
                for (byte i = 0; i < 3; ++i)
                {
                    for (byte j = 0; j < 3; ++j)
                    {
                        if (squares[i, j] == button)
                        {
                            game.PerformMove(i, j);
                            break;
                        }
                    }
                }
            }
        }

        private void BlockUI()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(BlockUI));
            }
            else
            {
                for (byte i = 0; i < 3; ++i)
                {
                    for (byte j = 0; j < 3; ++j)
                    {
                        squares[i, j].Enabled = false;
                    }
                }
                startButton.Enabled = false;
                automaticMovesCheckBox.Enabled = false;
                nextMoveButton.Enabled = true;
            }
        }

        private void ResetButtons()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ResetButtons));
            }
            else
            {
                for (byte i = 0; i < 3; ++i)
                {
                    for (byte j = 0; j < 3; ++j)
                    {
                        squares[i, j].Enabled = false;
                        usedButtons[i, j] = false;
                    }
                }
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
                for (byte i = 0; i < 3; ++i)
                {
                    for (byte j = 0; j < 3; ++j)
                    {
                        if (!usedButtons[i, j])
                        {
                            squares[i, j].Enabled = true;
                        }
                    }
                }
                nextMoveButton.Enabled = false;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (gamePlayed)
            {
                Logger.LogInfo("Game already played.");
            }
            else
            {
                Logger.LogDebug("Starting new thread to handle the game run.");
                Thread gameRunThread = new Thread(new ThreadStart(GameRunThreadStart));
                gameRunThread.IsBackground = true;
                Logger.LogDebug("Started new thread " + gameRunThread.ManagedThreadId);
                BlockUI();
                gameRunThread.Start();
            }
        }

        private void nextMoveButton_Click(object sender, EventArgs e)
        {
            manualMoveAcceptEvent.Set();
        }

        private void GameRunThreadStart()
        {
            try
            {
                if(player is RealPlayer)
                {
                    moveDoneEvent = new AutoResetEvent(false);
                    ((RealPlayer)player).MoveBlock = moveDoneEvent;
                    ((RealPlayer)player).GameView = this;
                }

                if(automaticMovesCheckBox.Checked)
                {
                    manualMoveAcceptEvent = null;
                }
                else
                {
                    manualMoveAcceptEvent = new AutoResetEvent(false);
                }
                game.PlayGameInView(new HashSet<Player>() { player }, this, manualMoveAcceptEvent);

                if(!(player is RealPlayer))
                {
                    Invoke(new Action(Close));
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
                ResetButtons();
            }
        }

        public void ShowMoveInView(object move)
        {
            Tuple<byte, byte, int> index = (Tuple<byte, byte, int>)move;
            byte i = index.Item1; byte j = index.Item2;
            int currentPlayerIndex = index.Item3;
            Button button = squares[i, j];
            button.ImageKey = (currentPlayerIndex == 0 ?
                                    "ticTacToeX.png" : "ticTacToeO.png");
            button.Enabled = false;
            usedButtons[i, j] = true;
        }

        public void AwaitPlayerInput()
        {
            UnblockUI();
        }
    }
}
