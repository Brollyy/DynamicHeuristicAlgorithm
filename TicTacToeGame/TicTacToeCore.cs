using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeCore
{
    public class TicTacToeBoardState
    {
        public byte[,] Board = new byte[3, 3];

        public TicTacToeBoardState()
        {
            Clear();
        }
        
        public void Clear()
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    Board[i, j] = 0;
                }
            }
        }

        public TicTacToeBoardState(TicTacToeBoardState state)
        {
            SetBoard(state.Board);
        }

        public void SetBoard(byte[,] state)
        {
            if (state.GetLength(0) == 3 && state.GetLength(1) == 3)
            {
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        Board[i, j] = state[i, j];
                    }
                }
            }
        }

        public TicTacToeBoardState(byte[,] state) : base()
        {
            SetBoard(state);
        }

        public bool IsTerminal()
        {
            bool done;
            int player;

            #region HorizontalCheck
            for (int i = 0; i < 3; ++i)
            {
                done = true;
                player = Board[i, 0];
                if (player > 0)
                {
                    for (int k = 1; k < 3; ++k)
                    {
                        if (Board[i, k] != player)
                        {
                            done = false;
                            break;
                        }
                    }

                    if(done)
                    {
                        return true;
                    }
                }
            }
            #endregion

            #region VerticalCheck
            for (int j = 0; j < 3; ++j)
            {
                done = true;
                player = Board[0, j];
                if (player > 0)
                {
                    for (int k = 1; k < 3; ++k)
                    {
                        if (Board[k, j] != player)
                        {
                            done = false;
                            break;
                        }
                    }

                    if (done)
                    {
                        return true;
                    }
                }
            }
            #endregion

            #region LeftDiagonalCheck
            done = true;
            player = Board[0, 0];
            if (player > 0)
            {
                for (int k = 1; k < 3; ++k)
                {
                    if (Board[k, k] != player)
                    {
                        done = false;
                        break;
                    }
                }

                if (done)
                {
                    return true;
                }
            }
            #endregion

            #region RightDiagonalCheck
            done = true;
            player = Board[0, 2];
            if (player > 0)
            {
                for (int k = 1; k < 3; ++k)
                {
                    if (Board[k, 2 - k] != player)
                    {
                        done = false;
                        break;
                    }
                }

                if (done)
                {
                    return true;
                }
            }
            #endregion

            #region BoardFilledCheck
            done = true;
            for(int i = 0; i < 3; ++i)
            {
                for(int j = 0; j < 3; ++j)
                {
                    if(Board[i, j] == 0)
                    {
                        done = false;
                        break;
                    }
                }
            }

            if(done)
            {
                return true;
            }
            #endregion

            return false;
        }

        public byte GetWinner()
        {
            bool done;
            byte player;

            #region HorizontalCheck
            for (int i = 0; i < 3; ++i)
            {
                done = true;
                player = Board[i, 0];
                if (player > 0)
                {
                    for (int k = 1; k < 3; ++k)
                    {
                        if (Board[i, k] != player)
                        {
                            done = false;
                            break;
                        }
                    }

                    if (done)
                    {
                        return player;
                    }
                }
            }
            #endregion

            #region VerticalCheck
            for (int j = 0; j < 3; ++j)
            {
                done = true;
                player = Board[0, j];
                if (player > 0)
                {
                    for (int k = 1; k < 3; ++k)
                    {
                        if (Board[k, j] != player)
                        {
                            done = false;
                            break;
                        }
                    }

                    if (done)
                    {
                        return player;
                    }
                }
            }
            #endregion

            #region LeftDiagonalCheck
            done = true;
            player = Board[0, 0];
            if (player > 0)
            {
                for (int k = 1; k < 3; ++k)
                {
                    if (Board[k, k] != player)
                    {
                        done = false;
                        break;
                    }
                }

                if (done)
                {
                    return player;
                }
            }
            #endregion

            #region RightDiagonalCheck
            done = true;
            player = Board[0, 2];
            if (player > 0)
            {
                for (int k = 1; k < 3; ++k)
                {
                    if (Board[k, 2 - k] != player)
                    {
                        done = false;
                        break;
                    }
                }

                if (done)
                {
                    return player;
                }
            }
            #endregion

            return 0;
        }
    }

    public class TicTacToeGame
    {
        private TicTacToeBoardState boardState;
        private bool playing;
        private byte currentPlayer;
        private byte filledSquaresCount;

        public TicTacToeGame()
        {
            boardState = new TicTacToeBoardState();
            playing = true;
            currentPlayer = 1;
            filledSquaresCount = 0;
        }

        public void RestartGame()
        {
            boardState.Clear();
            playing = true;
            currentPlayer = 1;
            filledSquaresCount = 0;
        }

        public TicTacToeBoardState GetBoardState()
        {
            return boardState;
        }

        public bool MakeMove(byte i, byte j)
        {
            if(playing &&
                i >= 0 && i < 3 &&
                j >= 0 && j < 3)
            {
                if(boardState.Board[i, j] == 0)
                {
                    boardState.Board[i, j] = currentPlayer;
                    filledSquaresCount++;
                    if(boardState.IsTerminal())
                    {
                        playing = false;
                    }
                    ChangePlayer();
                    return true;
                }
            }
            return false;
        }

        private void ChangePlayer()
        {
            if (playing)
            {
                currentPlayer = currentPlayer == 1 ? (byte)2 : (byte)1;
            }
        }

        public bool IsGameFinished()
        {
            return !playing;
        }

        public byte GetWinner()
        {
            return boardState.GetWinner();
        }
    }
}
