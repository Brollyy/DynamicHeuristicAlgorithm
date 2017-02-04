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

        public GameState Minimax(GameState node, uint depth)
        {
            if(depth == 0)
            {
                return node;
            }

            long bestValue = long.MinValue;
            GameState bestMove = node;

            HashSet<GameState> playerMoves = game.GetPossibleMovesForGameState(node);
            foreach(GameState move in playerMoves)
            {
                long value = AlphaBeta(move, depth - 1, false, bestValue, long.MaxValue);
                if(value > bestValue)
                {
                    bestValue = value;
                    bestMove = move;
                }
            }

            return bestMove;
        }

        private long AlphaBeta(GameState node, uint depth, bool maximizingPlayer, long alpha, long beta)
        {
            int playerIndex = game.GetCurrentPlayerIndex() + 1;
            if (depth == 0 || node.IsTerminal())
            {
                return HeuristicValue(node, playerIndex);
            }

            if (maximizingPlayer)
            {
                HashSet<GameState> playerMoves = game.GetPossibleMovesForGameState(node);
                foreach (GameState move in playerMoves)
                {
                    long value = AlphaBeta(move, depth - 1, false, alpha, beta);
                    if (value > alpha)
                    {
                        alpha = value;
                    }

                    if(alpha >= beta)
                    {
                        break;
                    }
                }
                return alpha;
            }
            else
            {
                HashSet<OpponentMove> opponentMoves = game.GetPossibleOpponentMovesForGameState(node);
                foreach (OpponentMove move in opponentMoves)
                {
                    long value = AlphaBeta(move.Move, depth - 1, true, alpha, beta);
                    if (value < beta)
                    {
                        beta = value;
                    }

                    if(alpha >= beta)
                    {
                        break;
                    }
                }
                return beta;
            }
        }

        private long HeuristicValue(GameState node, int playerIndex)
        {
            long value = 0;
            for(int i = 0; i < heuristics.Length; ++i)
            {
                value += heuristics[i].Evaluate(node, playerIndex);
            }

            return value;
        }
    }
}
