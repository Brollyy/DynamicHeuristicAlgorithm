using DynamicHeuristicAlgorithmCore.GameInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicHeuristicAlgorithmCore.PlayerInterface;
using TicTacToeCore;
using DynamicHeuristicAlgorithmCore.Utils;
using System.Threading;

namespace DynamicHeuristicAlgorithm.TicTacToe
{
    public class TicTacToeGameImpl : Game
    {
        private TicTacToeGame game;
        private byte currentPlayerIndex;
        private byte startingPlayerIndex;
        private const byte MAX_PLAYERS = 2;
        private GameView gameView;

        public TicTacToeGameImpl()
        {
            game = new TicTacToeGame();
            currentPlayerIndex = 1;
        }

        public GameStatistics GetGameStatistics()
        {
            TicTacToeGameStatistics stats = new TicTacToeGameStatistics();
            // 0 for lost game, 1 for draw, 2 for won game
            if (game.IsGameFinished())
            {
                byte winner = game.GetWinner();
                if(winner == 0)
                {
                    stats.Score = 1;
                }
                else if(winner == 1)
                {
                    stats.Score = 2;
                }
            }
            return stats;
        }

        public HashSet<GameState> GetPossibleMovesForGameState(GameState state)
        {
            HashSet<GameState> possibleMoves = new HashSet<GameState>();
            TicTacToeGameStateImpl ticTacToeState = (TicTacToeGameStateImpl)state;
            for (byte i = 0; i < 3; ++i)
            {
                for(byte j = 0; j < 3; ++j)
                {
                    if(ticTacToeState.GetSquare(i, j) == 0)
                    {
                        TicTacToeGameStateImpl newState = new TicTacToeGameStateImpl(ticTacToeState);
                        newState.SetSquare(i, j, 1);
                        possibleMoves.Add(newState);
                    }
                }
            }
            return possibleMoves;
        }

        public HashSet<OpponentMove> GetPossibleOpponentMovesForGameState(GameState state)
        {
            HashSet<OpponentMove> possibleOpponentMoves = new HashSet<OpponentMove>();
            TicTacToeGameStateImpl ticTacToeState = (TicTacToeGameStateImpl)state;
            for(byte i = 0; i < 3; ++i)
            {
                for(byte j = 0; j < 3; ++j)
                {
                    if (ticTacToeState.GetSquare(i, j) == 0)
                    {
                        TicTacToeGameStateImpl newState = new TicTacToeGameStateImpl(ticTacToeState);
                        newState.SetSquare(i, j, 2);
                        possibleOpponentMoves.Add(new OpponentMove(newState, 1));
                    }
                }
            }
            return possibleOpponentMoves;
        }

        public bool PerformMove(GameState move)
        {
            TicTacToeGameStateImpl ticTacToeMove = (TicTacToeGameStateImpl)move;
            for(byte i = 0; i < 3; ++i)
            {
                for(byte j = 0; j < 3; ++j)
                {
                    if(ticTacToeMove.GetSquare(i, j) != 0)
                    {
                        if(game.MakeMove(i, j))
                        {
                            gameView.ShowMoveInView(Tuple.Create<byte, byte, int>(i, j, currentPlayerIndex));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool PerformMove(byte i, byte j)
        {
            bool valid = game.MakeMove(i, j);
            if(valid)
            {
                gameView.ShowMoveInView(Tuple.Create<byte, byte, int>(i, j, currentPlayerIndex));
            }
            return valid;
        }

        public HashSet<Player> PlayGame(HashSet<Player> players)
        {
            if(players.Count != 1)
            {
                throw new NotImplementedException("Tic tac toe is only for 2 players.");
            }
            Logger.LogInfo("Starting Tic Tac Toe game.");

            players.Add(new PerfectTicTacToePlayer());

            Random rng = new Random();
            currentPlayerIndex = (byte)rng.Next(2);
            startingPlayerIndex = currentPlayerIndex;
            Logger.LogInfo("Starting player is " + GetCurrentPlayer(players).GetType().Name + ".");

            do
            {
                Player currentPlayer = GetCurrentPlayer(players);
                Logger.LogDebug(currentPlayer.GetType().Name + "'s move.");
                currentPlayer.PerformMove(this, GetCurrentGameState());
                ChangeToNextPlayer();
            }
            while (!game.IsGameFinished());

            byte winner = game.GetWinner();
            if (winner == 0)
            {
                Logger.LogInfo("Tic Tac Toe game ended in a tie.");
                return new HashSet<Player>();
            }

            if ((winner == 1 && startingPlayerIndex == 0) ||
                (winner == 2 && startingPlayerIndex == 1))
            {
                Logger.LogInfo("Tic Tac Toe game ended in a win");
                return new HashSet<Player>() { players.ElementAt(0) };
            }

            if ((winner == 1 && startingPlayerIndex == 1) ||
                (winner == 2 && startingPlayerIndex == 0))
            {
                Logger.LogInfo("Tic Tac Toe game ended in a lose");
                return new HashSet<Player>() { players.ElementAt(1) };
            }

            return new HashSet<Player>();
        }

        public HashSet<Player> PlayGameInView(HashSet<Player> players, GameView view, AutoResetEvent manualMoveAcceptBlock)
        {
            gameView = view;
            if (players.Count != 1)
            {
                throw new NotImplementedException("Tic tac toe is only for 2 players.");
            }
            Logger.LogInfo("Starting Tic Tac Toe game.");

            players.Add(new PerfectTicTacToePlayer());

            Random rng = new Random();
            currentPlayerIndex = (byte)rng.Next(2);
            startingPlayerIndex = currentPlayerIndex;
            Logger.LogInfo("Starting player is " + GetCurrentPlayer(players).GetType().Name + ".");

            do
            {
                if (manualMoveAcceptBlock != null)
                {
                    manualMoveAcceptBlock.WaitOne();
                }
                Player currentPlayer = GetCurrentPlayer(players);
                Logger.LogDebug(currentPlayer.GetType().Name + "'s move.");
                currentPlayer.PerformMove(this, GetCurrentGameState());
                ChangeToNextPlayer();
            }
            while (!game.IsGameFinished());

            byte winner = game.GetWinner();
            if (winner == 0)
            {
                Logger.LogInfo("Tic Tac Toe game ended in a tie.");
                return new HashSet<Player>();
            }

            if ((winner == 1 && startingPlayerIndex == 0) ||
                (winner == 2 && startingPlayerIndex == 1))
            {
                Logger.LogInfo("Tic Tac Toe game ended in a win");
                return new HashSet<Player>() { players.ElementAt(0) };
            }

            if ((winner == 1 && startingPlayerIndex == 1) ||
                (winner == 2 && startingPlayerIndex == 0))
            {
                Logger.LogInfo("Tic Tac Toe game ended in a lose");
                return new HashSet<Player>() { players.ElementAt(1) };
            }

            return new HashSet<Player>();
        }

        private void ChangeToNextPlayer()
        {
            currentPlayerIndex = GetNextPlayerIndex(currentPlayerIndex);
        }

        private byte GetNextPlayerIndex(byte playerIndex)
        {
            return (byte)((playerIndex + 1) % 2);
        }

        private GameState GetCurrentGameState()
        {
            return new TicTacToeGameStateImpl(game.GetBoardState());
        }

        private Player GetCurrentPlayer(HashSet<Player> players)
        {
            if(players.Count > currentPlayerIndex)
            {
                return players.ElementAt(currentPlayerIndex);
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid player index " + currentPlayerIndex + ".");
            }
        }
    }
}
