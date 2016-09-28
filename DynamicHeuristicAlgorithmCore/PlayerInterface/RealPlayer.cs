using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicHeuristicAlgorithmCore.GameInterface;
using System.Threading;

namespace DynamicHeuristicAlgorithmCore.PlayerInterface
{
    public class RealPlayer : Player
    {
        private AutoResetEvent moveBlock = null;
        private GameView gameView = null;

        public AutoResetEvent MoveBlock
        {
            set
            {
                moveBlock = value;
            }
        }

        public GameView GameView
        {
            set
            {
                gameView = value;
            }
        }

        public void PerformMove(Game game, GameState gameState)
        {
            if (moveBlock == null || gameView == null)
            {
                throw new NotImplementedException("Real player interface is not set up correctly.");
            }
            gameView.AwaitPlayerInput();
            moveBlock.WaitOne(); // Wait for view to handle the input and do the move for you.
        }
    }
}
