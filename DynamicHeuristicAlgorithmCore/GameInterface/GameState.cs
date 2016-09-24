using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicHeuristicAlgorithmCore.GameInterface
{
    public interface GameState
    {
        ulong GetHashCode();
    }

    public struct OpponentMove
    {
        public GameState Move;
        public ulong Probability; // Should be equal for all moves when not playing against random opponent.
    }
}
