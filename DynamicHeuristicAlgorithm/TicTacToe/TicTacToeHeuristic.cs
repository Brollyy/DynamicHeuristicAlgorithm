using DynamicHeuristicAlgorithmCore.HeuristicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicHeuristicAlgorithmCore.GameInterface;

namespace DynamicHeuristicAlgorithm.TicTacToe
{
    public class TicTacToeHeuristic : Heuristic
    {
        public TicTacToeHeuristic(uint weight): base(weight)
        {
        }

        #region Const
        private static byte[][][] threeInARow = new byte[][][]
        {
            new byte[][] 
            {
                new byte[] { 0, 0 }, 
                new byte[] { 0, 1 }, 
                new byte[] { 0, 2 }
            },
            new byte[][]
            {
                new byte[] { 1, 0 },
                new byte[] { 1, 1 },
                new byte[] { 1, 2 }
            },
            new byte[][]
            {
                new byte[] { 2, 0 },
                new byte[] { 2, 1 },
                new byte[] { 2, 2 }
            },
            new byte[][]
            {
                new byte[] { 0, 0 },
                new byte[] { 1, 0 },
                new byte[] { 2, 0 }
            },
            new byte[][]
            {
                new byte[] { 0, 1 },
                new byte[] { 1, 1 },
                new byte[] { 2, 1 }
            },
            new byte[][]
            {
                new byte[] { 0, 2 },
                new byte[] { 1, 2 },
                new byte[] { 2, 2 }
            },
            new byte[][]
            {
                new byte[] { 0, 0 },
                new byte[] { 1, 1 },
                new byte[] { 2, 2 }
            },
            new byte[][]
            {
                new byte[] { 0, 2 },
                new byte[] { 1, 1 },
                new byte[] { 2, 0 }
            }
        };

        private static int[][] heuristicArray = new int[][]
        {
            new int[] { 0,  -10, -100, -1000 },
            new int[] { 10, 0, 0, 0 },
            new int[] { 100, 0, 0, 0 },
            new int[] { 1000, 0, 0, 0 }
        };
        #endregion

        public override int Evaluate(GameState state, int playerIndex)
        {
            int value = 0;
            int players, others;

            for (int i = 0; i < 8; i++)
            {
                players = others = 0;
                for (int j = 0; j < 3; j++)
                {
                    int piece = state.GetBoard(threeInARow[i][j][0], threeInARow[i][j][1]);
                    if (piece == playerIndex)
                    {
                        players++;
                    }
                    else if (piece != 0)
                    {
                        others++;
                    }
                }
                value += heuristicArray[players][others];
            }

            return (int)weight * value;
        }
    }
}
