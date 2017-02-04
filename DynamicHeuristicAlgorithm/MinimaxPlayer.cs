using DynamicHeuristicAlgorithmCore.PlayerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicHeuristicAlgorithmCore.GameInterface;
using DynamicHeuristicAlgorithmCore.HeuristicInterface;
using MinimaxAlgorithmCore;
using DynamicHeuristicAlgorithmCore.Utils;

namespace DynamicHeuristicAlgorithm
{
    public class MinimaxPlayer : AIPlayer
    {
        uint depth;

        public MinimaxPlayer(Heuristic[] heuristics, uint depth): base(heuristics)
        {
            this.depth = depth;
        }

        public override void PerformMove(Game game, GameState gameState)
        {
            MinimaxAlgorithm minimax = new MinimaxAlgorithm(game, heuristics);
            GameState bestMove = minimax.Minimax(gameState, depth);
            Logger.LogDebug("MinimaxPlayer move from " + gameState.GetStateHashCode()
                + " to " + bestMove.GetStateHashCode() + ".");
            game.PerformMove(bestMove);
        }
    }
}
