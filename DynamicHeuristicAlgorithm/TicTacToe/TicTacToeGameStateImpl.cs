using DynamicHeuristicAlgorithmCore.GameInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeCore;

namespace DynamicHeuristicAlgorithm.TicTacToe
{
    public class TicTacToeGameStateImpl : GameState
    {
        private TicTacToeBoardState state;

        public TicTacToeGameStateImpl()
        {
            state = new TicTacToeBoardState();
        }

        public TicTacToeGameStateImpl(TicTacToeGameStateImpl gameState)
        {
            state = new TicTacToeBoardState(gameState.state);
        }

        public TicTacToeGameStateImpl(TicTacToeBoardState boardState)
        {
            state = new TicTacToeBoardState(boardState);
        }

        public byte GetSquare(byte i, byte j)
        {
            if(i >= 0 && i < 3 &&
                j >= 0 && j < 3)
            {
                return state.Board[i, j];
            }
            return 4;
        }

        public void SetSquare(byte i, byte j, byte state)
        {
            if (i >= 0 && i < 3 &&
                j >= 0 && j < 3)
            {
                this.state.Board[i, j] = state;
            }
        }

        public byte[] GetByteState()
        {
            return BitConverter.GetBytes(GetStateHashCode());
        }

        public ulong GetStateHashCode()
        {
            ulong state = 0;
            for (byte i = 0; i < 3; ++i)
            {
                for (byte j = 0; j < 3; ++j)
                {
                    state *= 3;
                    state += this.state.Board[i, j];
                }
            }
            return state;
        }
    }
}
