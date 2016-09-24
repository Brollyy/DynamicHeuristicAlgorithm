using DynamicHeuristicAlgorithmCore.GameInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicHeuristicAlgorithm.Utils
{
    public static class GameFactory
    {
        public static Game GetGameByName(string name)
        {
            switch(name)
            {
                case "CoinFlipGuess":
                    throw new NotImplementedException("Game CoinFlipGuess is not implemented.");
                case "TicTacToe":
                    throw new NotImplementedException("Game TicTacToe is not implemented.");
                case "2048":
                    throw new NotImplementedException("Game 2048 is not implemented.");
                default:
                    throw new NotImplementedException("Game " + name + " is not implemented.");
            }
        }
    }
}
