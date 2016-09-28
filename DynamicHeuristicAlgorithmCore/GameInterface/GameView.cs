using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicHeuristicAlgorithmCore.GameInterface
{
    public interface GameView
    {
        void ShowMoveInView(object move);
        void AwaitPlayerInput();
    }
}
