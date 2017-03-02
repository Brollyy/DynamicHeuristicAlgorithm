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
using System.Diagnostics;
using DynamicHeuristicAlgorithmCore.HeuristicInterface;
using DynamicHeuristicAlgorithm.Utils;

namespace DynamicHeuristicAlgorithm.TicTacToe
{
    public class TicTacToeGameImpl : Game
    {
        private TicTacToeGame game;
        private byte currentPlayerIndex;
        private byte startingPlayerIndex;
        private const byte MAX_PLAYERS = 2;
        private GameView gameView;
        private Player opponent;

        private List<TicTacToeGameStateImpl> playerGameStates;
        private TicTacToeGameStateImpl currentGameState;

        private TicTacToeGameStatistics statistics;

        public TicTacToeGameImpl()
        {
            game = new TicTacToeGame();
            currentGameState = GameStateFactory<TicTacToeGameStateImpl>.GetNewGameState();
            currentPlayerIndex = 1;
            opponent = new RandomPlayer();
            //opponent = new MinimaxPlayer(new Heuristic[] { HeuristicFactory.GetHeuristicByName("ticTacToeHeuristic", 1, null) }, 6);
            playerGameStates = new List<TicTacToeGameStateImpl>();
            statistics = new TicTacToeGameStatistics();
        }

        ~TicTacToeGameImpl()
        {
            GameStateFactory<TicTacToeGameStateImpl>.ReturnGameState(currentGameState);
        }

        private void RestartGame()
        {
            game.RestartGame();
            statistics.Clear();
            ReturnStatesToPool();
        }

        public GameStatistics GetGameStatistics()
        {
            return statistics;
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
                        TicTacToeGameStateImpl newState = GameStateFactory<TicTacToeGameStateImpl>.GetNewGameState(ticTacToeState);
                        newState.SetSquare(i, j, (byte)(GetCurrentPlayerIndex() + 1));
                        possibleMoves.Add(newState);
                        playerGameStates.Add(newState);
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
                        TicTacToeGameStateImpl newState = GameStateFactory<TicTacToeGameStateImpl>.GetNewGameState(ticTacToeState);
                        newState.SetSquare(i, j, (byte)(GetNextPlayerIndex((byte)GetCurrentPlayerIndex()) + 1));
                        possibleOpponentMoves.Add(new OpponentMove(newState, 1));
                        playerGameStates.Add(newState);
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
                            if (gameView != null)
                            {
                                gameView.ShowMoveInView(Tuple.Create<byte, byte, int>(i, j, GetCurrentPlayerIndex()));
                            }
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
            if(valid && gameView != null)
            {
                gameView.ShowMoveInView(Tuple.Create<byte, byte, int>(i, j, GetCurrentPlayerIndex()));
            }
            return valid;
        }

        public HashSet<Player> PlayGame(HashSet<Player> players)
        {
            RestartGame();
            if(players.Count != 1)
            {
                throw new NotImplementedException("Tic tac toe is only for 2 players.");
            }
            Logger.LogInfo("Starting Tic Tac Toe game.");

            players.Add(opponent);

            Random rng = new Random();
            currentPlayerIndex = (byte)rng.Next(2);
            startingPlayerIndex = currentPlayerIndex;
            statistics.StartedPlaying = startingPlayerIndex == 0;
            Logger.LogInfo("Starting player is " + GetCurrentPlayer(players).GetType().Name + ".");

            Stopwatch gameTimer = Stopwatch.StartNew();
            do
            {
                Player currentPlayer = GetCurrentPlayer(players);
                Logger.LogDebug(currentPlayer.GetType().Name + "'s move.");
                TicTacToeGameStateImpl currentGameState = (TicTacToeGameStateImpl)GetCurrentGameState();
                Stopwatch moveTimer = Stopwatch.StartNew();
                currentPlayer.PerformMove(this, currentGameState);
                moveTimer.Stop();
                if (currentPlayerIndex == 0)
                {
                    TicTacToeGameStateImpl startMove = GameStateFactory<TicTacToeGameStateImpl>.GetNewGameState(currentGameState);
                    TicTacToeGameStateImpl endMove = GameStateFactory<TicTacToeGameStateImpl>.GetNewGameState((TicTacToeGameStateImpl)GetCurrentGameState());
                    statistics.Moves.Add(new Tuple<GameState, GameState>(startMove, endMove));
                    statistics.MovesDurations.Add(moveTimer.Elapsed.TotalMilliseconds);
                }
                ReturnStatesToPool();
                ChangeToNextPlayer();
            }
            while (!game.IsGameFinished());
            gameTimer.Stop();
            statistics.GameDuration = gameTimer.Elapsed.TotalMilliseconds;

            byte winner = game.GetWinner();
            if (winner == 0)
            {
                statistics.Score = 0;
                Logger.LogInfo("Tic Tac Toe game ended in a tie.");
                return new HashSet<Player>();
            }

            if ((winner == 1 && startingPlayerIndex == 0) ||
                (winner == 2 && startingPlayerIndex == 1))
            {
                statistics.Score = 1000;
                Logger.LogInfo("Tic Tac Toe game ended in a win");
                return new HashSet<Player>() { players.ElementAt(0) };
            }

            if ((winner == 1 && startingPlayerIndex == 1) ||
                (winner == 2 && startingPlayerIndex == 0))
            {
                statistics.Score = -1000;
                Logger.LogInfo("Tic Tac Toe game ended in a lose");
                return new HashSet<Player>() { players.ElementAt(1) };
            }

            return new HashSet<Player>();
        }

        public HashSet<Player> PlayGameInView(HashSet<Player> players, GameView view, AutoResetEvent manualMoveAcceptBlock)
        {
            RestartGame();
            gameView = view;
            if (players.Count != 1)
            {
                throw new NotImplementedException("Tic tac toe is only for 2 players.");
            }
            Logger.LogInfo("Starting Tic Tac Toe game.");

            players.Add(opponent);

            Random rng = new Random();
            currentPlayerIndex = (byte)rng.Next(2);
            startingPlayerIndex = currentPlayerIndex;
            statistics.StartedPlaying = startingPlayerIndex == 0;
            Logger.LogInfo("Starting player is " + GetCurrentPlayer(players).GetType().Name + ".");

            Stopwatch gameTimer = Stopwatch.StartNew();
            do
            {
                if (manualMoveAcceptBlock != null)
                {
                    manualMoveAcceptBlock.WaitOne();
                }
                Player currentPlayer = GetCurrentPlayer(players);
                Logger.LogDebug(currentPlayer.GetType().Name + "'s move.");
                TicTacToeGameStateImpl currentGameState = (TicTacToeGameStateImpl)GetCurrentGameState();
                Stopwatch moveTimer = Stopwatch.StartNew();
                currentPlayer.PerformMove(this, currentGameState);
                moveTimer.Stop();
                if (currentPlayerIndex == 0)
                {
                    TicTacToeGameStateImpl startMove = GameStateFactory<TicTacToeGameStateImpl>.GetNewGameState(currentGameState);
                    TicTacToeGameStateImpl endMove = GameStateFactory<TicTacToeGameStateImpl>.GetNewGameState((TicTacToeGameStateImpl)GetCurrentGameState());
                    statistics.Moves.Add(new Tuple<GameState, GameState>(startMove, endMove));
                    statistics.MovesDurations.Add(moveTimer.Elapsed.TotalMilliseconds);
                }
                ReturnStatesToPool();
                ChangeToNextPlayer();
            }
            while (!game.IsGameFinished());
            gameTimer.Stop();
            statistics.GameDuration = gameTimer.Elapsed.TotalMilliseconds;

            byte winner = game.GetWinner();
            if (winner == 0)
            {
                statistics.Score = 0;
                Logger.LogInfo("Tic Tac Toe game ended in a tie.");
                return new HashSet<Player>();
            }

            if ((winner == 1 && startingPlayerIndex == 0) ||
                (winner == 2 && startingPlayerIndex == 1))
            {
                statistics.Score = 1000;
                Logger.LogInfo("Tic Tac Toe game ended in a win");
                return new HashSet<Player>() { players.ElementAt(0) };
            }

            if ((winner == 1 && startingPlayerIndex == 1) ||
                (winner == 2 && startingPlayerIndex == 0))
            {
                statistics.Score = -1000;
                Logger.LogInfo("Tic Tac Toe game ended in a lose");
                return new HashSet<Player>() { players.ElementAt(1) };
            }

            return new HashSet<Player>();
        }

        private void ReturnStatesToPool()
        {
            if (playerGameStates.Any())
            {
                GameStateFactory<TicTacToeGameStateImpl>.ReturnGameStates(playerGameStates);
                playerGameStates.Clear();
            }
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
            currentGameState.SetState(game.GetBoardState().Board);
            return currentGameState;
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

        public int GetCurrentPlayerIndex()
        {
            return (startingPlayerIndex + currentPlayerIndex) % 2;
        }
    }
}
