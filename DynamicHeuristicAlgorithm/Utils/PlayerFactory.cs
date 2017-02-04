using DynamicHeuristicAlgorithm.TicTacToe;
using DynamicHeuristicAlgorithmCore.HeuristicInterface;
using DynamicHeuristicAlgorithmCore.PlayerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicHeuristicAlgorithm.Utils
{
    public static class PlayerFactory
    {
        public static Player GetPlayerByNameAndParameters(string name, Dictionary<string, object> parameters)
        {
            switch(name)
            {
                case "playYourself":
                    return GetRealPlayer(parameters);
                case "setHeuristics":
                    return GetAIPlayerWithHeuristics(parameters);
                case "dynamicHeuristic":
                    return GetAIPlayerWithDynamicHeuristic(parameters);
                default:
                    throw new NotImplementedException("Player type '" + name + "' is not implemented.");
            }
        }

        private static Player GetRealPlayer(Dictionary<string, object> parameters)
        {
            return new RealPlayer();
        }

        private static Player GetAIPlayerWithHeuristics(Dictionary<string, object> parameters)
        {
            Heuristic[] heuristics = (Heuristic[])parameters["setHeuristics"];
            uint recursionDepth = (uint)parameters["recursionDepth"];
            return new MinimaxPlayer(heuristics, recursionDepth);
        }

        private static Player GetAIPlayerWithDynamicHeuristic(Dictionary<string, object> parameters)
        {
            Heuristic heuristic = (Heuristic)parameters["dynamicHeuristic"];
            uint recursionDepth = (uint)parameters["recursionDepth"];
            return new MinimaxPlayer(new Heuristic[] { heuristic }, recursionDepth);
        }
    }
}
