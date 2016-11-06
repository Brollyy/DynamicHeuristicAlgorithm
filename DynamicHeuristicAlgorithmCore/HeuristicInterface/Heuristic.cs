﻿using DynamicHeuristicAlgorithmCore.GameInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicHeuristicAlgorithmCore.HeuristicInterface
{
    public abstract class Heuristic
    {
        protected uint weight;

        public Heuristic(uint weight)
        {
            this.weight = weight;
        }

        public abstract int Evaluate(GameState state, int playerIndex);
    }
}
