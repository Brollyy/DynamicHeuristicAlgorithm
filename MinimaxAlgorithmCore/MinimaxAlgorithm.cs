using DynamicHeuristicAlgorithmCore.GameInterface;
using DynamicHeuristicAlgorithmCore.HeuristicInterface;
using DynamicHeuristicAlgorithmCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimaxAlgorithmCore
{
    public class MinimaxAlgorithm
    {
        private Game game;
        private Heuristic[] heuristics;

        public MinimaxAlgorithm(Game game, Heuristic[] heuristics)
        {
            this.game = game;
            this.heuristics = heuristics;
        }

        public GameState Minimax(GameState node, uint depth, bool maximizingPlayer)
        {
            if (depth == 0)
            {
                return node;
            }

            int playerIndex = game.GetCurrentPlayerIndex() + 1;

            if (maximizingPlayer)
            {
                int bestValue = int.MinValue;
                GameState bestNode = node;
                HashSet<GameState> playerMoves = game.GetPossibleMovesForGameState(node);
                foreach (GameState move in playerMoves)
                {
                    GameState v = Minimax(move, depth - 1, false);
                    int value = HeuristicValue(v, playerIndex);
                    if (value > bestValue)
                    {
                        bestValue = value;
                        bestNode = move;
                    }
                }
                return bestNode;
            }
            else
            {
                int bestValue = int.MaxValue;
                GameState bestNode = node;
                HashSet<OpponentMove> opponentMoves = game.GetPossibleOpponentMovesForGameState(node);
                foreach (OpponentMove move in opponentMoves)
                {
                    GameState v = Minimax(move.Move, depth - 1, true);
                    int value = HeuristicValue(v, playerIndex);
                    if (value < bestValue)
                    {
                        bestValue = value;
                        bestNode = move.Move;
                    }
                }
                return bestNode;
            }
        }

        private int HeuristicValue(GameState node, int playerIndex)
        {
            int value = 0;
            for(int i = 0; i < heuristics.Length; ++i)
            {
                value += heuristics[i].Evaluate(node, playerIndex);
            }

            return value;
        }
    }
}
