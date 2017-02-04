using DynamicHeuristicAlgorithmCore.GameInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DynamicHeuristicAlgorithm.Utils;

namespace DynamicHeuristicAlgorithm.TicTacToe
{
    public class TicTacToeGameStatistics : GameStatistics
    {
        protected override Type GetGameStateType()
        {
            return typeof(TicTacToeGameStateImpl);
        }
    }
}
