﻿using DynamicHeuristicAlgorithmCore.PlayerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicHeuristicAlgorithmCore.GameInterface
{
    public interface Game
    {
        #region PlayerInteraction
        // Game info
        GameStatistics GetGameStatistics();
        int GetCurrentPlayerIndex();

        // Possibilites info
        HashSet<GameState> GetPossibleMovesForGameState(GameState state);
        HashSet<OpponentMove> GetPossibleOpponentMovesForGameState(GameState state);

        // Actions with the game
        bool PerformMove(GameState move);

        #endregion

        #region Control

        HashSet<Player> PlayGame(HashSet<Player> players); // Return winners (whenever applicable)
        HashSet<Player> PlayGameInView(HashSet<Player> players, GameView view, AutoResetEvent manualMoveAcceptBlock);

        #endregion
    }
}
