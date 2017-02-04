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
            StringBuilder s = new StringBuilder();
            if (heuristics.Length == 1 && heuristics[0] is DynamicHeuristicImpl)
            {
                s.Append(((DynamicHeuristicImpl)heuristics[0]).GetHeuristicName());
            }
            else
            {
                foreach (Heuristic h in heuristics)
                {
                    s.Append(h.GetType().Name.Substring(5, 2));
                    s.Append("_");
                    s.Append(h.WeightToString());
                    s.Append("_");
                }
                s.Length--;
            }
            return s.ToString();
        }

        public void SaveDynamicHeuristicData(string filename)
        {
            if(heuristics.Length == 1 && heuristics[0] is DynamicHeuristicImpl)
            {
                ((DynamicHeuristicImpl)heuristics[0]).SaveDynamicHeuristicData(filename);
            }
        }

        public void TeachDynamicHeuristic(GameStatistics statistics)
        {
            if (heuristics.Length == 1 && heuristics[0] is DynamicHeuristicImpl)
            {
                ((DynamicHeuristicImpl)heuristics[0]).TeachDynamicHeuristic(statistics);
            }
        }
    }
}
