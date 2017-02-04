using DynamicHeuristicAlgorithmCore.HeuristicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicHeuristicAlgorithmCore.GameInterface;

namespace DynamicHeuristicAlgorithm._2048
{
    public class _2048OpenSquareBonusHeuristic : Heuristic
    {
        public _2048OpenSquareBonusHeuristic(double weight) : base(weight)
        {
        }

        public override int Evaluate(GameState state, int playerIndex)
        {
            _2048GameStateImpl gameState = (_2048GameStateImpl)state;
            int open = 0;
            for(byte i = 0; i < 4; ++i)
            {
                for(byte j = 0; j < 4; ++j)
                {
                    if(gameState.GetBoard(i, j) == 0)
                    {
                        open++;
                    }
                }
            }

            return (int)(weight * open);
        }
    }
}
