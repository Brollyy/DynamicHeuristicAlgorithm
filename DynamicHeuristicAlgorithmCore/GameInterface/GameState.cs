using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicHeuristicAlgorithmCore.GameInterface
{
    public interface GameState
    {
        byte[] GetByteState();
        ulong GetStateHashCode();
    }

    public struct OpponentMove
    {
        public GameState Move;
        public ulong Probability; // Should be equal for all moves when not playing against random opponent.

        public OpponentMove(GameState move, ulong probability)
        {
            Move = move;
            Probability = probability;
        }
    }
}
