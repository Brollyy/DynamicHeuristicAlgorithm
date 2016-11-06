using DynamicHeuristicAlgorithm.TicTacToe;
using DynamicHeuristicAlgorithmCore.HeuristicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicHeuristicAlgorithm.Utils
{
    public static class HeuristicFactory
    {
        public static Heuristic[] GetHeuristicsByNames(string[] names, uint[] weights)
        {
            if(names.Length != weights.Length)
            {
                throw new IndexOutOfRangeException("Heuristics names and weights arrays lengths don't match.");
            }

            Heuristic[] heuristics = new Heuristic[names.Length];
            for(int i = 0; i < names.Length; ++i)
            {
                heuristics[i] = GetHeuristicByName(names[i], weights[i]);
            }
            return heuristics;
        }

        public static Heuristic GetHeuristicByName(string name, uint weight)
        {
            switch(name)
            {
                case "dynamicHeuristic":
                    throw new NotImplementedException("Dynamic heuristic is not implemented.");
                case "openSquareBonusHeuristic":
                    throw new NotImplementedException("Open square bonus heuristic is not implemented.");
                case "largeValuesOnEdgeHeuristic":
                    throw new NotImplementedException("Large values on edge heuristic is not implemented.");
                case "nonMonotonicLinesPenaltyHeuristic":
                    throw new NotImplementedException("Non-monotonic lines penalty heuristic is not implemented.");
                case "numberOfMergesHeuristic":
                    throw new NotImplementedException("Number of merges heuristic is not implemented.");
                case "ticTacToeHeuristic":
                    return new TicTacToeHeuristic(weight);
                case "connectFourHeuristic":
                    throw new NotImplementedException("Connect four heuristic is not implemented.");
                default:
                    throw new NotImplementedException("Heuristic '" + name + "' is not implemented.");
            }
        }
    }
}
