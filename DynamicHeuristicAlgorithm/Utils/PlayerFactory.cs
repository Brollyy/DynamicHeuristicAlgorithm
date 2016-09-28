using DynamicHeuristicAlgorithm.TicTacToe;
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
            // Temporary
            return new RealPlayer();
        }

        private static Player GetAIPlayerWithHeuristics(Dictionary<string, object> parameters)
        {
            throw new NotImplementedException("AI player support is not implemented.");
        }

        private static Player GetAIPlayerWithDynamicHeuristic(Dictionary<string, object> parameters)
        {
            throw new NotImplementedException("AI player support is not implemented.");
        }
    }
}
