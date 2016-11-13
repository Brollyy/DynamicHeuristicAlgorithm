using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicHeuristicAlgorithmCore.GameInterface;
using DynamicHeuristicAlgorithmCore.HeuristicInterface;

namespace DynamicHeuristicAlgorithmCore.PlayerInterface
{
    public abstract class AIPlayer : Player
    {
        protected Heuristic[] heuristics;

        public AIPlayer(Heuristic[] heuristics)
        {
            this.heuristics = heuristics;
        }

        public abstract void PerformMove(Game game, GameState gameState);

        public string HeuristicsToString()
        {
            string s = "";
            foreach(Heuristic h in heuristics)
            {
                s += h.GetType().Name + "_" + h.WeightToString() + "_";
            }
            return s.TrimEnd('_');
        }
    }
}
