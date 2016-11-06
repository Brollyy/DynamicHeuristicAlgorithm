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
                    CheckIfGameFinished(i, j);
                    ChangePlayer();
                    return true;
                }
            }
            return false;
        }

        private void CheckIfGameFinished(byte i, byte j)
        {
            bool done;

            #region HorizontalCheck
            done = true;
            for(int k = 0; k < 3; ++k)
            {
                if(boardState.Board[i, k] != currentPlayer)
                {
                    done = false;
                    break;
                }
            }

            if (done)
            {
                playing = false;
                return;
            }
            #endregion

            #region VerticalCheck
            done = true;
            for (int k = 0; k < 3; ++k)
            {
                if (boardState.Board[k, j] != currentPlayer)
                {
                    done = false;
                    break;
                }
            }

            if (done)
            {
                playing = false;
                return;
            }
            #endregion

            #region LeftDiagonalCheck
            if (i == j)
            {
                done = true;
                for (int k = 0; k < 3; ++k)
                {
                    if (boardState.Board[k, k] != currentPlayer)
                    {
                        done = false;
                        break;
                    }
                }

                if (done)
                {
                    playing = false;
                    return;
                }
            }
            #endregion

            #region RightDiagonalCheck
            if (i == 2-j)
            {
                done = true;
                for (int k = 0; k < 3; ++k)
                {
                    if (boardState.Board[k, 2-k] != currentPlayer)
                    {
                        done = false;
                        break;
                    }
                }

                if (done)
                {
                    playing = false;
                    return;
                }
            }
            #endregion

            #region BoardFilledCheck
            if(filledSquaresCount == 9)
            {
                playing = false;
                currentPlayer = 0;
                return;
            }
            #endregion
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
            return currentPlayer;
        }
    }
}
