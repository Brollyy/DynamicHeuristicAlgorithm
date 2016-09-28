using DynamicHeuristicAlgorithm.TicTacToe;
using DynamicHeuristicAlgorithmCore.GameInterface;
using DynamicHeuristicAlgorithmCore.PlayerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicHeuristicAlgorithm.Utils
{
    public static class GameViewFactory
    {
        public static Form GetGameViewAsForm(Game game, Player player)
        {
            switch(game.GetType().Name)
            {
                case "TicTacToeGameImpl":
                    return new TicTacToeRunner((TicTacToeGameImpl)game, player);
                default:
                    throw new NotImplementedException("Interface for game " + game.GetType().Name + " is not implemented.");
            }
        }
    }
}
