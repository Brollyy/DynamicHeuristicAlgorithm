using DynamicHeuristicAlgorithm._2048;
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
        public static Heuristic[] GetHeuristicsByNames(string[] names, double[] weights)
        {
            if(names.Length != weights.Length)
            {
                throw new IndexOutOfRangeException("Heuristics names and weights arrays lengths don't match.");
            }

            Heuristic[] heuristics = new Heuristic[names.Length];
            for(int i = 0; i < names.Length; ++i)
            {
                heuristics[i] = GetHeuristicByName(names[i], weights[i], null);
            }
            return heuristics;
        }

        public static Heuristic GetHeuristicByName(string name, double weight, Dictionary<string, object> additionalParams)
        {
            switch(name)
            {
                case "mapDynamicHeuristic":
                case "neuralNetworkDynamicHeuristic":
                    return new DynamicHeuristicImpl(DynamicHeuristicFactory.GetDynamicHeuristicByName(name, additionalParams), weight);
                case "2048Heuristic":
                    return new _2048ScoreHeuristic(weight);
                case "openSquareBonusHeuristic":
                    return new _2048OpenSquareBonusHeuristic(weight);
                case "largeValuesOnEdgeHeuristic":
                    return new _2048LargeValuesOnEdgeHeuristic(weight);
                case "nonMonotonicLinesPenaltyHeuristic":
                    return new _2048NonMonotonicLinesPenaltyHeuristic(weight);
                case "numberOfMergesHeuristic":
                    return new _2048NumberOfMergesHeuristic(weight);
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
