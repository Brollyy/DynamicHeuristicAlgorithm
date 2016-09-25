using DynamicHeuristicAlgorithm.TicTacToe;
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
                case "ConnectFour":
                    throw new NotImplementedException("Game ConnectFour is not implemented.");
                case "TicTacToe":
                    return new TicTacToeGameImpl();
                case "2048":
                    throw new NotImplementedException("Game 2048 is not implemented.");
                default:
                    throw new NotImplementedException("Game " + name + " is not implemented.");
            }
        }
    }
}
