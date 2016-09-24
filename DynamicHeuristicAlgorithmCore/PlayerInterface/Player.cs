using DynamicHeuristicAlgorithmCore.GameInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicHeuristicAlgorithmCore.PlayerInterface
{
    public interface Player
    {
        void PerformMove(GameState gameState);
    }
}
