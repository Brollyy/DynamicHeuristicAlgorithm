using DynamicHeuristicAlgorithmCore.PlayerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicHeuristicAlgorithmCore.GameInterface;
using DynamicHeuristicAlgorithmCore.Utils;
using TicTacToeCore;

namespace DynamicHeuristicAlgorithm.TicTacToe
{
    public class PerfectTicTacToePlayer : Player
    {
        private Dictionary<ulong, TicTacToeGameStateImpl> perfectMoves;

        public PerfectTicTacToePlayer()
        {
            Logger.LogDebug("Setting up PerfectTicTacToePlayer moveset.");
            perfectMoves = new Dictionary<ulong, TicTacToeGameStateImpl>();

            #region  Moves when you start

            #region 1st turn
            #region [{0,0,0},{0,0,0},{0,0,0}] -> [{0,0,0},{0,0,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,] 
                {
                    {0, 0, 0},
                    {0, 0, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 0));
            }
            #endregion
            #endregion

            #region 2nd turn
            #region [{2,0,0},{0,0,0},{1,0,0}] -> [{2,0,1},{0,0,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {0, 0, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 2));
            }
            #endregion
            #region [{0,2,0},{0,0,0},{1,0,0}] -> [{1,2,0},{0,0,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 2, 0},
                    {0, 0, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{0,0,2},{0,0,0},{1,0,0}] -> [{1,0,2},{0,0,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 2},
                    {0, 0, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{0,0,0},{2,0,0},{1,0,0}] -> [{0,0,0},{2,0,0},{1,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {2, 0, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{0,0,0},{0,2,0},{1,0,0}] -> [{0,0,1},{0,2,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 2));
            }
            #endregion
            #region [{0,0,0},{0,0,2},{1,0,0}] -> [{1,0,0},{0,0,2},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 0, 2},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{0,0,0},{0,0,0},{1,2,0}] -> [{1,0,0},{0,0,0},{1,2,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 0, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{0,0,0},{0,0,0},{1,0,2}] -> [{0,0,1},{0,0,0},{1,0,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 0, 0},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 2));
            }
            #endregion
            #endregion

            #region 2rd turn
            #region [{2,2,1},{0,0,0},{1,0,0}] -> [{2,2,1},{0,1,0},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 1},
                    {0, 0, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{2,0,1},{2,0,0},{1,0,0}] -> [{2,0,1},{2,1,0},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {2, 1, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{2,0,1},{0,2,0},{1,0,0}] -> [{2,0,1},{0,2,0},{1,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {0, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{2,0,1},{0,0,2},{1,0,0}] -> [{2,0,1},{0,1,2},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {0, 0, 2},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{2,0,1},{0,0,0},{1,2,0}] -> [{2,0,1},{0,1,0},{1,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {0, 0, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{2,0,1},{0,0,0},{1,0,2}] -> [{2,0,1},{0,1,0},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {0, 0, 0},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{1,2,2},{0,0,0},{1,0,0}] -> [{1,2,2},{1,0,0},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 2},
                    {0, 0, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,2,0},{2,0,0},{1,0,0}] -> [{1,2,0},{2,1,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {2, 0, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{1,2,0},{0,2,0},{1,0,0}] -> [{1,2,0},{1,2,0},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {0, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,2,0},{0,0,2},{1,0,0}] -> [{1,2,0},{1,0,2},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {0, 0, 2},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,2,0},{0,0,0},{1,2,0}] -> [{1,2,0},{1,0,0},{1,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {0, 0, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,2,0},{0,0,0},{1,0,2}] -> [{1,2,0},{1,0,0},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {0, 0, 0},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,0,2},{2,0,0},{1,0,0}] -> [{1,0,2},{2,0,0},{1,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {2, 0, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{1,0,2},{0,2,0},{1,0,0}] -> [{1,0,2},{1,2,0},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {0, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,0,2},{0,0,2},{1,0,0}] -> [{1,0,2},{1,0,2},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {0, 0, 2},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,0,2},{0,0,0},{1,2,0}] -> [{1,0,2},{1,0,0},{1,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {0, 0, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,0,2},{0,0,0},{1,0,2}] -> [{1,0,2},{1,0,0},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {0, 0, 0},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{2,0,0},{2,0,0},{1,0,1}] -> [{2,0,0},{2,0,0},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {2, 0, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{0,2,0},{2,0,0},{1,0,1}] -> [{0,2,0},{2,0,0},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 2, 0},
                    {2, 0, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{0,0,2},{2,0,0},{1,0,1}] -> [{0,0,2},{2,0,0},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 2},
                    {2, 0, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{0,0,0},{2,2,0},{1,0,1}] -> [{0,0,0},{2,2,0},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {2, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{0,0,0},{2,0,2},{1,0,1}] -> [{0,0,0},{2,0,2},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {2, 0, 2},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{0,0,0},{2,0,0},{1,2,1}] -> [{0,0,0},{2,1,0},{1,2,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {2, 0, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{0,2,1},{0,2,0},{1,0,0}] -> [{0,2,1},{0,2,0},{1,1,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 2, 1},
                    {0, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{0,0,1},{2,2,0},{1,0,0}] -> [{0,0,1},{2,2,1},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {2, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 2));
            }
            #endregion
            #region [{0,0,1},{0,2,2},{1,0,0}] -> [{0,0,1},{1,2,2},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 2},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{0,0,1},{0,2,0},{1,2,0}] -> [{0,1,1},{0,2,0},{1,2,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 1));
            }
            #endregion
            #region [{0,0,1},{0,2,0},{1,0,2}] -> [{1,0,1},{0,2,0},{1,0,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 0},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{1,0,0},{2,0,2},{1,0,0}] -> [{1,0,0},{2,1,2},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {2, 0, 2},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{1,0,0},{0,2,2},{1,0,0}] -> [{1,0,0},{1,2,2},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 2, 2},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,0,0},{0,0,2},{1,2,0}] -> [{1,0,0},{1,0,2},{1,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 0, 2},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,0,0},{0,0,2},{1,0,2}] -> [{1,0,0},{1,0,2},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 0, 2},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,0,0},{2,0,0},{1,2,0}] -> [{1,0,0},{2,1,0},{1,2,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {2, 0, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{1,0,0},{0,2,0},{1,2,0}] -> [{1,0,0},{1,2,0},{1,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 2, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{1,0,0},{0,0,0},{1,2,2}] -> [{1,0,0},{1,0,0},{1,2,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 0, 0},
                    {1, 2, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{0,2,1},{0,0,0},{1,0,2}] -> [{0,2,1},{0,0,0},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 2, 1},
                    {0, 0, 0},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{0,0,1},{2,0,0},{1,0,2}] -> [{0,0,1},{2,0,0},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {2, 0, 0},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{0,0,1},{0,0,2},{1,0,2}] -> [{0,0,1},{0,0,2},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 0, 2},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{0,0,1},{0,0,0},{1,2,2}] -> [{0,0,1},{0,0,0},{1,2,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 0, 0},
                    {1, 2, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #endregion

            #region 4th turn
            #region [{2,2,1},{0,2,0},{1,0,1}] -> [{2,2,1},{0,2,0},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 1},
                    {0, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{2,0,1},{2,2,0},{1,0,1}] -> [{2,0,1},{2,2,0},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {2, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{2,0,1},{0,2,2},{1,0,1}] -> [{2,0,1},{0,2,2},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {0, 2, 2},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{2,0,1},{0,2,0},{1,2,1}] -> [{2,0,1},{0,2,1},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {0, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 2));
            }
            #endregion
            #region [{1,2,2},{2,1,0},{1,0,0}] -> [{1,2,2},{2,1,0},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 2},
                    {2, 1, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{1,2,0},{2,1,2},{1,0,0}] -> [{1,2,0},{2,1,2},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {2, 1, 2},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{1,2,0},{2,1,0},{1,2,0}] -> [{1,2,0},{2,1,0},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {2, 1, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{1,2,0},{2,1,0},{1,0,2}] -> [{1,2,1},{2,1,0},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {2, 1, 0},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 2));
            }
            #endregion
            #region [{1,2,2},{2,0,0},{1,0,1}] -> [{1,2,2},{2,0,0},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 2},
                    {2, 0, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{1,2,0},{2,2,0},{1,0,1}] -> [{1,2,0},{2,2,0},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {2, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{1,2,0},{2,0,2},{1,0,1}] -> [{1,2,0},{2,0,2},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {2, 0, 2},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{1,2,0},{2,0,0},{1,2,1}] -> [{1,2,0},{2,1,0},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {2, 0, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 1));
            }
            #endregion
            #region [{2,0,0},{2,1,0},{1,2,1}] -> [{2,0,1},{2,1,0},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {2, 1, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 2));
            }
            #endregion
            #region [{0,2,0},{2,1,0},{1,2,1}] -> [{0,2,1},{2,1,0},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 2, 0},
                    {2, 1, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 2));
            }
            #endregion
            #region [{0,0,2},{2,1,0},{1,2,1}] -> [{1,0,2},{2,1,0},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 2},
                    {2, 1, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{0,0,0},{2,1,2},{1,2,1}] -> [{0,0,1},{2,1,2},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {2, 1, 2},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 2));
            }
            #endregion
            #region [{2,2,1},{0,2,0},{1,1,0}] -> [{2,2,1},{0,2,0},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 1},
                    {0, 2, 0},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{0,2,1},{2,2,0},{1,1,0}] -> [{0,2,1},{2,2,0},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 2, 1},
                    {2, 2, 0},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{0,2,1},{0,2,2},{1,1,0}] -> [{0,2,1},{0,2,2},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 2, 1},
                    {0, 2, 2},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{0,2,1},{0,2,0},{1,1,2}] -> [{1,2,1},{0,2,0},{1,1,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 2, 1},
                    {0, 2, 0},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{2,0,1},{2,2,1},{1,0,0}] -> [{2,0,1},{2,2,1},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {2, 2, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{0,2,1},{2,2,1},{1,0,0}] -> [{0,2,1},{2,2,1},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 2, 1},
                    {2, 2, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{0,0,1},{2,2,1},{1,2,0}] -> [{0,0,1},{2,2,1},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {2, 2, 1},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{0,0,1},{2,2,1},{1,0,2}] -> [{1,0,1},{2,2,1},{1,0,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {2, 2, 1},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{2,0,1},{1,2,2},{1,0,0}] -> [{2,0,1},{1,2,2},{1,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 2, 2},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{0,2,1},{1,2,2},{1,0,0}] -> [{1,2,1},{1,2,2},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 2, 1},
                    {1, 2, 2},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{0,0,1},{1,2,2},{1,2,0}] -> [{1,0,1},{1,2,2},{1,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {1, 2, 2},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{0,0,1},{1,2,2},{1,0,2}] -> [{1,0,1},{1,2,2},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {1, 2, 2},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{2,1,1},{0,2,0},{1,2,0}] -> [{2,1,1},{0,2,0},{1,2,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 2, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{0,1,1},{2,2,0},{1,2,0}] -> [{1,1,1},{2,2,0},{1,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 1},
                    {2, 2, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{0,1,1},{0,2,2},{1,2,0}] -> [{1,1,1},{0,2,2},{1,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 1},
                    {0, 2, 2},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{0,1,1},{0,2,0},{1,2,2}] -> [{1,1,1},{0,2,0},{1,2,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 1},
                    {0, 2, 0},
                    {1, 2, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 0));
            }
            #endregion
            #region [{1,2,1},{0,2,0},{1,0,2}] -> [{1,2,1},{0,2,0},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {0, 2, 0},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,0,1},{2,2,0},{1,0,2}] -> [{1,1,1},{2,2,0},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {2, 2, 0},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 1));
            }
            #endregion
            #region [{1,0,1},{0,2,2},{1,0,2}] -> [{1,1,1},{0,2,2},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {0, 2, 2},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 1));
            }
            #endregion
            #region [{1,0,1},{0,2,0},{1,2,2}] -> [{1,1,1},{0,2,0},{1,2,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {0, 2, 0},
                    {1, 2, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 1));
            }
            #endregion
            #region [{1,0,0},{2,1,2},{1,2,0}] -> [{1,0,0},{2,1,2},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {2, 1, 2},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{1,0,0},{2,1,2},{1,0,2}] -> [{1,0,1},{2,1,2},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {2, 1, 2},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 2));
            }
            #endregion
            #region [{1,0,2},{2,1,0},{1,2,0}] -> [{1,0,2},{2,1,0},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {2, 1, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 2));
            }
            #endregion
            #region [{1,0,0},{2,1,0},{1,2,2}] -> [{1,0,1},{2,1,0},{1,2,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {2, 1, 0},
                    {1, 2, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 2));
            }
            #endregion
            #region [{1,0,2},{2,2,0},{1,0,1}] -> [{1,0,2},{2,2,0},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {2, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #endregion

            #region 5th turn
            #region [{1,2,1},{2,2,0},{1,1,2}] -> [{1,2,1},{2,2,1},{1,1,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {2, 2, 0},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 2));
            }
            #endregion
            #region [{1,2,1},{0,2,2},{1,1,2}] -> [{1,2,1},{1,2,2},{1,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {0, 2, 2},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #region [{1,2,1},{2,2,1},{1,0,2}] -> [{1,2,1},{2,2,1},{1,1,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {2, 2, 1},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{1,0,1},{2,2,1},{1,2,2}] -> [{1,1,1},{2,2,1},{1,2,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {2, 2, 1},
                    {1, 2, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 1));
            }
            #endregion
            #region [{2,2,1},{1,2,2},{1,0,1}] -> [{2,2,1},{1,2,2},{1,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 1},
                    {1, 2, 2},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 2, 1));
            }
            #endregion
            #region [{2,0,1},{1,2,2},{1,2,1}] -> [{2,1,1},{1,2,2},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 2, 2},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 0, 2));
            }
            #endregion
            #region [{2,1,1},{2,2,0},{1,2,1}] -> [{2,1,1},{2,2,1},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {2, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 2));
            }
            #endregion
            #region [{2,1,1},{0,2,2},{1,2,1}] -> [{2,1,1},{1,2,2},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 2, 2},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenFirst(state, 1, 0));
            }
            #endregion
            #endregion

            #endregion

            #region Moves when opponent start

            #region 1st move
            #region [{1,0,0},{0,0,0},{0,0,0}] -> [{1,0,0},{0,2,0},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 0, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 1));
            }
            #endregion
            #region [{0,1,0},{0,0,0},{0,0,0}] -> [{0,1,0},{0,2,0},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {0, 0, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 1));
            }
            #endregion
            #region [{0,0,1},{0,0,0},{0,0,0}] -> [{0,0,1},{0,2,0},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 0, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 1));
            }
            #endregion
            #region [{0,0,0},{1,0,0},{0,0,0}] -> [{0,0,0},{1,2,0},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {1, 0, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 1));
            }
            #endregion
            #region [{0,0,0},{0,1,0},{0,0,0}] -> [{2,0,0},{0,1,0},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 1, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,0},{0,0,1},{0,0,0}] -> [{0,0,0},{0,2,1},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 0, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 1));
            }
            #endregion
            #region [{0,0,0},{0,0,0},{1,0,0}] -> [{0,0,0},{0,2,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 0, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 1));
            }
            #endregion
            #region [{0,0,0},{0,0,0},{0,0,0}] -> [{0,0,0},{0,2,0},{0,1,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 0, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 1));
            }
            #endregion
            #region [{0,0,0},{0,0,0},{0,0,1}] -> [{0,0,0},{0,2,0},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 0, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 1));
            }
            #endregion
            #endregion

            #region 2nd move
            #region [{1,1,0},{0,2,0},{0,0,0}] -> [{1,1,2},{0,2,0},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 0},
                    {0, 2, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,0,1},{0,2,0},{0,0,0}] -> [{1,2,1},{0,2,0},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {0, 2, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{1,0,0},{1,2,0},{0,0,0}] -> [{1,0,0},{1,2,0},{2,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {1, 2, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,0,0},{0,2,1},{0,0,0}] -> [{1,0,2},{0,2,1},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 2, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,0,0},{0,2,0},{1,0,0}] -> [{1,0,0},{2,2,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{1,0,0},{0,2,0},{0,1,0}] -> [{1,0,0},{0,2,0},{2,1,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 2, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,0,0},{0,2,0},{0,0,1}] -> [{1,0,0},{2,2,0},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 2, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{0,1,1},{0,2,0},{0,0,0}] -> [{2,1,1},{0,2,0},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 1},
                    {0, 2, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,1,0},{1,2,0},{0,0,0}] -> [{2,1,0},{1,2,0},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {1, 2, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,1,0},{0,2,1},{0,0,0}] -> [{0,1,2},{0,2,1},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {0, 2, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{0,1,0},{0,2,0},{1,0,0}] -> [{2,1,0},{0,2,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {0, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,1,0},{0,2,0},{0,1,0}] -> [{2,1,0},{0,2,0},{0,1,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {0, 2, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,1,0},{0,2,0},{0,0,1}] -> [{0,1,2},{0,2,0},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {0, 2, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{0,0,1},{1,2,0},{0,0,0}] -> [{2,0,1},{1,2,0},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {1, 2, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,1},{0,2,1},{0,0,0}] -> [{0,0,1},{0,2,1},{0,0,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{0,0,1},{0,2,0},{1,0,0}] -> [{0,0,1},{2,2,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{0,0,1},{0,2,0},{0,1,0}] -> [{0,0,1},{0,2,0},{0,1,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{0,0,1},{0,2,0},{0,0,1}] -> [{0,0,1},{0,2,2},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{0,0,0},{1,2,1},{0,0,0}] -> [{2,0,0},{1,2,1},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {1, 2, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,0},{1,2,0},{1,0,0}] -> [{2,0,0},{1,2,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {1, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,0},{1,2,0},{0,1,0}] -> [{0,0,0},{1,2,0},{2,1,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {1, 2, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{0,0,0},{1,2,0},{0,0,1}] -> [{0,0,0},{1,2,0},{2,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {1, 2, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,1,0},{0,1,0},{0,0,0}] -> [{2,1,0},{0,1,0},{0,2,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {0, 1, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{2,0,1},{0,1,0},{0,0,0}] -> [{2,0,1},{0,1,0},{2,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {0, 1, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,0,0},{1,1,0},{0,0,0}] -> [{2,0,0},{1,1,2},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {1, 1, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{2,0,0},{0,1,1},{0,0,0}] -> [{2,0,0},{2,1,1},{0,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {0, 1, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,0,0},{0,1,0},{1,0,0}] -> [{2,0,2},{0,1,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {0, 1, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,0,0},{0,1,0},{0,1,0}] -> [{2,2,0},{0,1,0},{0,1,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {0, 1, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,0,0},{0,1,0},{0,0,1}] -> [{2,0,2},{0,1,0},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {0, 1, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{0,0,0},{0,2,1},{1,0,0}] -> [{0,0,0},{0,2,1},{1,0,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 2, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{0,0,0},{0,2,1},{0,1,0}] -> [{0,0,0},{0,2,1},{0,1,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 2, 1},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{0,0,0},{0,2,1},{0,0,1}] -> [{0,0,2},{0,2,1},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 2, 1},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{0,0,0},{0,2,0},{1,1,0}] -> [{0,0,0},{0,2,0},{1,1,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 2, 0},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{0,0,0},{0,2,0},{1,0,1}] -> [{0,0,0},{0,2,0},{1,2,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{0,0,0},{0,2,0},{0,1,1}] -> [{0,0,0},{0,2,0},{2,1,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 2, 0},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #endregion

            #region 3rd move
            #region [{1,1,2},{1,2,0},{0,0,0}] -> [{1,1,2},{1,2,0},{2,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 2},
                    {1, 2, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,1,2},{0,2,1},{0,0,0}] -> [{1,1,2},{0,2,1},{2,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 2},
                    {0, 2, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,1,2},{0,2,0},{1,0,0}] -> [{1,1,2},{2,2,0},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 2},
                    {0, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{1,1,2},{0,2,0},{0,1,0}] -> [{1,1,2},{0,2,0},{2,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 2},
                    {0, 2, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,1,2},{0,2,0},{0,0,1}] -> [{1,1,2},{0,2,0},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 2},
                    {0, 2, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,2,1},{1,2,0},{0,0,0}] -> [{1,2,1},{1,2,0},{0,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {1, 2, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{1,2,1},{0,2,1},{0,0,0}] -> [{1,2,1},{0,2,1},{0,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {0, 2, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{1,2,1},{0,2,0},{1,0,0}] -> [{1,2,1},{0,2,0},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {0, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{1,2,1},{0,2,0},{0,1,0}] -> [{1,2,1},{2,2,0},{0,1,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {0, 2, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{1,2,1},{0,2,0},{0,0,1}] -> [{1,2,1},{0,2,0},{0,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {0, 2, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{1,1,0},{1,2,0},{2,0,0}] -> [{1,1,2},{1,2,0},{2,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 0},
                    {1, 2, 0},
                    {2, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,0,1},{1,2,0},{2,0,0}] -> [{1,2,1},{1,2,0},{2,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {1, 2, 0},
                    {2, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{1,0,0},{1,2,1},{2,0,0}] -> [{1,0,2},{1,2,1},{2,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {1, 2, 1},
                    {2, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,0,0},{1,2,0},{2,1,0}] -> [{1,0,2},{1,2,0},{2,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {1, 2, 0},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,0,0},{1,2,0},{2,0,1}] -> [{1,0,2},{1,2,0},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {1, 2, 0},
                    {2, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,0,2},{1,2,1},{0,0,0}] -> [{1,0,2},{1,2,1},{2,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {1, 2, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,0,2},{0,2,1},{1,0,0}] -> [{1,0,2},{2,2,1},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {0, 2, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{1,0,2},{0,2,1},{0,1,0}] -> [{1,0,2},{0,2,1},{2,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {0, 2, 1},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,0,2},{0,2,1},{0,0,1}] -> [{1,0,2},{0,2,1},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {0, 2, 1},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,1,0},{2,2,0},{1,0,0}] -> [{1,1,0},{2,2,2},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 0},
                    {2, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,0,1},{2,2,0},{1,0,0}] -> [{1,0,1},{2,2,2},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {2, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,0,0},{2,2,1},{1,0,0}] -> [{1,2,0},{2,2,1},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {2, 2, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{1,0,0},{2,2,0},{1,1,0}] -> [{1,0,0},{2,2,2},{1,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {2, 2, 0},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,0,0},{2,2,0},{1,0,1}] -> [{1,0,0},{2,2,2},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {2, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,1,0},{0,2,0},{2,1,0}] -> [{1,1,2},{0,2,0},{2,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 0},
                    {0, 2, 0},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,0,1},{0,2,0},{2,1,0}] -> [{1,2,1},{0,2,0},{2,1,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {0, 2, 0},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{1,0,0},{0,2,1},{2,1,0}] -> [{1,0,2},{0,2,1},{2,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 2, 1},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,0,0},{0,2,0},{2,1,1}] -> [{1,0,2},{0,2,0},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 2, 0},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,1,0},{2,2,0},{0,0,1}] -> [{1,1,0},{2,2,2},{0,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 0},
                    {2, 2, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,0,1},{2,2,0},{0,0,1}] -> [{1,0,1},{2,2,2},{0,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {2, 2, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,0,0},{2,2,1},{0,0,1}] -> [{1,0,2},{2,2,1},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {2, 2, 1},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,0,0},{2,2,0},{0,1,1}] -> [{1,0,0},{2,2,2},{0,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {2, 2, 0},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{2,1,1},{1,2,0},{0,0,0}] -> [{2,1,1},{1,2,0},{0,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {1, 2, 0},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,1,1},{0,2,1},{0,0,0}] -> [{2,1,1},{0,2,1},{0,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 2, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,1,1},{0,2,0},{1,0,0}] -> [{2,1,1},{0,2,0},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,1,1},{0,2,0},{0,1,0}] -> [{2,1,1},{0,2,0},{0,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 2, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,1,1},{0,2,0},{0,0,1}] -> [{2,1,1},{0,2,2},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 2, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{2,1,0},{1,2,1},{0,0,0}] -> [{2,1,0},{1,2,1},{0,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {1, 2, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,1,0},{1,2,0},{1,0,0}] -> [{2,1,0},{1,2,0},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {1, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,1,0},{1,2,0},{0,1,0}] -> [{2,1,0},{1,2,0},{0,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {1, 2, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,1,0},{1,2,0},{0,0,1}] -> [{2,1,2},{1,2,0},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {1, 2, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{0,1,2},{1,2,1},{0,0,0}] -> [{0,1,2},{1,2,1},{2,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 2},
                    {1, 2, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{0,1,2},{0,2,1},{1,0,0}] -> [{2,1,2},{0,2,1},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 2},
                    {0, 2, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,1,2},{0,2,1},{0,1,0}] -> [{0,1,2},{0,2,1},{2,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 2},
                    {0, 2, 1},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{0,1,2},{0,2,1},{0,0,1}] -> [{0,1,2},{0,2,1},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 2},
                    {0, 2, 1},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,1,0},{0,2,1},{1,0,0}] -> [{2,1,0},{0,2,1},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {0, 2, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,1,0},{0,2,0},{1,1,0}] -> [{2,1,0},{0,2,0},{1,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {0, 2, 0},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,1,0},{0,2,0},{1,0,1}] -> [{2,1,0},{0,2,0},{1,2,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {0, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{2,1,0},{0,2,1},{0,1,0}] -> [{2,1,0},{0,2,1},{0,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {0, 2, 1},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,1,0},{0,2,0},{0,1,1}] -> [{2,1,0},{0,2,0},{2,1,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {0, 2, 0},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{0,1,2},{1,2,0},{0,0,1}] -> [{0,1,2},{1,2,0},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 2},
                    {1, 2, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{0,1,2},{0,2,0},{1,0,1}] -> [{0,1,2},{0,2,0},{1,2,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 2},
                    {0, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{0,1,2},{0,2,0},{0,1,1}] -> [{0,1,2},{0,2,0},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 2},
                    {0, 2, 0},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,0,1},{1,2,1},{0,0,0}] -> [{2,0,1},{1,2,1},{0,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 2, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,0,1},{1,2,0},{1,0,0}] -> [{2,0,1},{1,2,0},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,0,1},{1,2,0},{0,1,0}] -> [{2,0,1},{1,2,0},{0,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 2, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,0,1},{1,2,0},{0,0,1}] -> [{2,0,1},{1,2,2},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 2, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,0,1},{0,2,1},{0,0,2}] -> [{1,2,1},{0,2,1},{0,0,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {0, 2, 1},
                    {0, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{0,1,1},{0,2,1},{0,0,2}] -> [{2,1,1},{0,2,1},{0,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 1},
                    {0, 2, 1},
                    {0, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,1},{1,2,1},{0,0,2}] -> [{2,0,1},{1,2,1},{0,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {1, 2, 1},
                    {0, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,1},{0,2,1},{1,0,2}] -> [{2,0,1},{0,2,1},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 1},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,1},{0,2,1},{0,1,2}] -> [{2,0,1},{0,2,1},{0,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 1},
                    {0, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,1,1},{2,2,0},{1,0,0}] -> [{0,1,1},{2,2,2},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 1},
                    {2, 2, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{0,0,1},{2,2,1},{1,0,0}] -> [{0,0,1},{2,2,1},{1,0,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {2, 2, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{0,0,1},{2,2,0},{1,1,0}] -> [{0,0,1},{2,2,2},{1,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {2, 2, 0},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{0,0,1},{2,2,0},{1,0,1}] -> [{0,0,1},{2,2,2},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {2, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,0,1},{0,2,0},{0,1,2}] -> [{1,2,1},{0,2,0},{0,1,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {0, 2, 0},
                    {0, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{0,1,1},{0,2,0},{0,1,2}] -> [{2,1,1},{0,2,0},{0,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 1},
                    {0, 2, 0},
                    {0, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,1},{1,2,0},{0,1,2}] -> [{2,0,1},{1,2,0},{0,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {1, 2, 0},
                    {0, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,1},{0,2,0},{1,1,2}] -> [{2,0,1},{0,2,0},{1,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 0},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{1,0,1},{0,2,2},{0,0,1}] -> [{1,0,1},{2,2,2},{0,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {0, 2, 2},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{0,1,1},{0,2,2},{0,0,1}] -> [{0,1,1},{2,2,2},{0,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 1},
                    {0, 2, 2},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{0,0,1},{1,2,2},{0,0,1}] -> [{0,2,1},{1,2,2},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {1, 2, 2},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{0,0,1},{0,2,2},{1,0,1}] -> [{0,0,1},{2,2,2},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 2},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{0,0,1},{0,2,2},{0,1,1}] -> [{0,0,1},{2,2,2},{0,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 2},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,0,0},{1,2,1},{1,0,0}] -> [{2,0,0},{1,2,1},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {1, 2, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,0,0},{1,2,1},{0,1,0}] -> [{2,0,0},{1,2,1},{0,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {1, 2, 1},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,0,0},{1,2,1},{0,0,1}] -> [{2,0,2},{1,2,1},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {1, 2, 1},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,0,0},{1,2,0},{1,1,0}] -> [{2,0,0},{1,2,0},{1,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {1, 2, 0},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,0,0},{1,2,0},{1,0,1}] -> [{2,0,0},{1,2,0},{1,2,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {1, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{0,1,0},{1,2,0},{2,1,0}] -> [{0,1,2},{1,2,0},{2,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {1, 2, 0},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{0,0,1},{1,2,0},{2,1,0}] -> [{2,0,1},{1,2,0},{2,1,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {1, 2, 0},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,0},{1,2,1},{2,1,0}] -> [{0,0,2},{1,2,1},{2,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {1, 2, 1},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{0,0,0},{1,2,0},{2,1,1}] -> [{0,0,2},{1,2,0},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {1, 2, 0},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{0,1,0},{1,2,0},{2,0,1}] -> [{0,1,2},{1,2,0},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {1, 2, 0},
                    {2, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{0,0,1},{1,2,0},{2,0,1}] -> [{0,0,1},{1,2,2},{2,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {1, 2, 0},
                    {2, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{0,0,0},{1,2,1},{2,0,1}] -> [{0,0,2},{1,2,1},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {1, 2, 1},
                    {2, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,1,1},{0,1,0},{0,2,0}] -> [{2,1,1},{0,1,0},{2,2,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 1, 0},
                    {0, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,1,0},{1,1,0},{0,2,0}] -> [{2,1,0},{1,1,2},{0,2,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {1, 1, 0},
                    {0, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{2,1,0},{0,1,1},{0,2,0}] -> [{2,1,0},{2,1,1},{0,2,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {0, 1, 1},
                    {0, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,1,0},{0,1,0},{1,2,0}] -> [{2,1,2},{0,1,0},{1,2,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {0, 1, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,1,0},{0,1,0},{0,2,1}] -> [{2,1,0},{2,1,0},{0,2,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {0, 1, 0},
                    {0, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,1,1},{0,1,0},{2,0,0}] -> [{2,1,1},{2,1,0},{2,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 1, 0},
                    {2, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,0,1},{1,1,0},{2,0,0}] -> [{2,0,1},{1,1,2},{2,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 1, 0},
                    {2, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{2,0,1},{0,1,1},{2,0,0}] -> [{2,0,1},{2,1,1},{2,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {0, 1, 1},
                    {2, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,0,1},{0,1,0},{2,1,0}] -> [{2,0,1},{2,1,0},{2,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {0, 1, 0},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,0,1},{0,1,0},{2,0,1}] -> [{2,0,1},{2,1,0},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {0, 1, 0},
                    {2, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,1,0},{1,1,2},{0,0,0}] -> [{2,1,0},{1,1,2},{0,2,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {1, 1, 2},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{2,0,1},{1,1,2},{0,0,0}] -> [{2,0,1},{1,1,2},{2,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 1, 2},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,0,0},{1,1,2},{1,0,0}] -> [{2,0,2},{1,1,2},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {1, 1, 2},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,0,0},{1,1,2},{0,1,0}] -> [{2,2,0},{1,1,2},{0,1,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {1, 1, 2},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,0,0},{1,1,2},{0,0,1}] -> [{2,2,0},{1,1,2},{0,0,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {1, 1, 2},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,1,0},{2,1,1},{0,0,0}] -> [{2,1,0},{2,1,1},{2,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {2, 1, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,0,1},{2,1,1},{0,0,0}] -> [{2,0,1},{2,1,1},{2,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {2, 1, 1},
                    {0, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,0,0},{2,1,1},{1,0,0}] -> [{2,0,2},{2,1,1},{1,0,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {2, 1, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,0,0},{2,1,1},{0,1,0}] -> [{2,0,0},{2,1,1},{2,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {2, 1, 1},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,0,0},{2,1,1},{0,0,1}] -> [{2,0,0},{2,1,1},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {2, 1, 1},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,1,2},{0,1,0},{1,0,0}] -> [{2,1,2},{0,1,0},{1,2,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {0, 1, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{2,0,2},{1,1,0},{1,0,0}] -> [{2,2,2},{1,1,0},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {1, 1, 0},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,0,2},{0,1,1},{1,0,0}] -> [{2,2,2},{0,1,1},{1,0,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {0, 1, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,0,2},{0,1,0},{1,1,0}] -> [{2,2,2},{0,1,0},{1,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {0, 1, 0},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,0,2},{0,1,0},{1,0,1}] -> [{2,2,2},{0,1,0},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {0, 1, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,2,1},{0,1,0},{0,1,0}] -> [{2,2,1},{0,1,0},{2,1,0}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 1},
                    {0, 1, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,2,0},{1,1,0},{0,1,0}] -> [{2,2,2},{1,1,0},{0,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 0},
                    {1, 1, 0},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,2,0},{0,1,1},{0,1,0}] -> [{2,2,2},{0,1,1},{0,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 0},
                    {0, 1, 1},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,2,0},{0,1,0},{1,1,0}] -> [{2,2,2},{0,1,0},{1,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 0},
                    {0, 1, 0},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,2,0},{0,1,0},{0,1,1}] -> [{2,2,2},{0,1,0},{0,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 0},
                    {0, 1, 0},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,1,2},{0,1,0},{0,0,1}] -> [{2,1,2},{0,1,0},{0,2,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {0, 1, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{2,0,2},{1,1,0},{0,0,1}] -> [{2,2,2},{1,1,0},{0,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {1, 1, 0},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,0,2},{0,1,1},{0,0,1}] -> [{2,2,2},{0,1,1},{0,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {0, 1, 1},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,0,2},{0,1,0},{0,1,1}] -> [{2,2,2},{0,1,0},{0,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {0, 1, 0},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{1,0,0},{0,2,1},{1,0,2}] -> [{1,0,0},{2,2,1},{1,0,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 2, 1},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{0,1,0},{0,2,1},{1,0,2}] -> [{2,1,0},{0,2,1},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {0, 2, 1},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,0},{1,2,1},{1,0,2}] -> [{2,0,0},{1,2,1},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {1, 2, 1},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,0},{0,2,1},{1,1,2}] -> [{2,0,0},{0,2,1},{1,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 2, 1},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{1,0,0},{0,2,1},{0,1,2}] -> [{1,0,2},{0,2,1},{0,1,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 2, 1},
                    {0, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{0,1,0},{0,2,1},{0,1,2}] -> [{2,1,0},{0,2,1},{0,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {0, 2, 1},
                    {0, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,0},{1,2,1},{0,1,2}] -> [{2,0,0},{1,2,1},{0,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 2, 1},
                    {0, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,2},{1,2,1},{0,0,1}] -> [{0,0,2},{1,2,1},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 2},
                    {1, 2, 1},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{0,0,2},{0,2,1},{1,0,1}] -> [{0,0,2},{0,2,1},{1,2,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 2},
                    {0, 2, 1},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{0,0,2},{0,2,1},{0,1,1}] -> [{0,0,2},{0,2,1},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 2},
                    {0, 2, 1},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,0,0},{0,2,0},{1,1,2}] -> [{1,0,0},{2,2,0},{1,1,2}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 2, 0},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{0,1,0},{0,2,0},{1,1,2}] -> [{2,1,0},{0,2,0},{1,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {0, 2, 0},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,0},{1,2,0},{1,1,2}] -> [{2,0,0},{1,2,0},{1,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {1, 2, 0},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{1,0,0},{0,2,0},{1,2,1}] -> [{1,2,0},{0,2,0},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {0, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{0,1,0},{0,2,0},{1,2,1}] -> [{0,1,0},{2,2,0},{1,2,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {0, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{0,0,1},{0,2,0},{1,2,1}] -> [{0,2,1},{0,2,0},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{0,0,0},{1,2,0},{1,2,1}] -> [{0,2,0},{1,2,0},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {1, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{0,0,0},{0,2,1},{1,2,1}] -> [{0,2,0},{0,2,1},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 2, 1},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{0,1,0},{0,2,0},{2,1,1}] -> [{0,1,2},{0,2,0},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {0, 2, 0},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{0,0,1},{0,2,0},{2,1,1}] -> [{0,0,1},{0,2,2},{2,1,1}]
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {0, 2, 0},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{0,0,0},{0,2,1},{2,1,1}] -> [{0,0,2},{0,2,1},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 0},
                    {0, 2, 1},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #endregion

            #region 4th move
            #region [{1,1,2},{2,2,1},{1,0,0}] -> [{1,1,2},{2,2,1},{1,0,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 2},
                    {2, 2, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{1,1,2},{2,2,0},{1,1,0}] -> [{1,1,2},{2,2,2},{1,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 2},
                    {2, 2, 0},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,1,2},{2,2,0},{1,0,1}] -> [{1,1,2},{2,2,0},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 2},
                    {2, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,2,1},{2,2,1},{0,1,0}] -> [{1,2,1},{2,2,1},{0,1,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {2, 2, 1},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{1,2,1},{2,2,0},{1,1,0}] -> [{1,2,1},{2,2,2},{1,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {2, 2, 0},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,2,1},{2,2,0},{0,1,1}] -> [{1,2,1},{2,2,2},{0,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {2, 2, 0},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,2,1},{1,2,1},{2,0,0}] -> [{1,2,1},{1,2,1},{2,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {1, 2, 1},
                    {2, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{1,2,1},{1,2,0},{2,1,0}] -> [{1,2,1},{1,2,0},{2,1,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {1, 2, 0},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{1,2,1},{1,2,0},{2,0,1}] -> [{1,2,1},{1,2,0},{2,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {1, 2, 0},
                    {2, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{1,0,2},{2,2,1},{1,1,0}] -> [{1,0,2},{2,2,1},{1,1,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {2, 2, 1},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{1,0,2},{2,2,1},{1,0,1}] -> [{1,0,2},{2,2,1},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {2, 2, 1},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{1,2,1},{2,2,1},{1,0,0}] -> [{1,2,1},{2,2,1},{1,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {2, 2, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{1,2,0},{2,2,1},{1,1,0}] -> [{1,2,0},{2,2,1},{1,1,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {2, 2, 1},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{1,2,0},{2,2,1},{1,0,1}] -> [{1,2,0},{2,2,1},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 0},
                    {2, 2, 1},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{1,2,1},{0,2,1},{2,1,0}] -> [{1,2,1},{0,2,1},{2,1,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {0, 2, 1},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{1,2,1},{0,2,0},{2,1,1}] -> [{1,2,1},{0,2,2},{2,1,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {0, 2, 0},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,1,2},{2,2,1},{0,0,1}] -> [{1,1,2},{2,2,1},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 2},
                    {2, 2, 1},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,0,2},{2,2,1},{0,1,1}] -> [{1,0,2},{2,2,1},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {2, 2, 1},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,1,1},{1,2,2},{0,0,1}] -> [{2,1,1},{1,2,2},{2,0,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {1, 2, 2},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,1,1},{0,2,2},{1,0,1}] -> [{2,1,1},{2,2,2},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 2, 2},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,1,1},{0,2,2},{0,1,1}] -> [{2,1,1},{0,2,2},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 2, 2},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,1,2},{1,2,1},{0,0,1}] -> [{2,1,2},{1,2,1},{2,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {1, 2, 1},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,1,2},{1,2,0},{1,0,1}] -> [{2,1,2},{1,2,0},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {1, 2, 0},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{2,1,2},{1,2,0},{0,1,1}] -> [{2,1,2},{1,2,0},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {1, 2, 0},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,1,2},{1,2,1},{1,0,0}] -> [{2,1,2},{1,2,1},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {1, 2, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,1,2},{0,2,1},{1,1,0}] -> [{2,1,2},{0,2,1},{1,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {0, 2, 1},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,1,2},{0,2,1},{1,0,1}] -> [{2,1,2},{0,2,1},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {0, 2, 1},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{2,1,1},{0,2,0},{1,2,1}] -> [{2,1,1},{0,2,2},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{2,1,0},{1,2,0},{1,2,1}] -> [{2,1,2},{1,2,0},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {1, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,1,0},{0,2,1},{1,2,1}] -> [{2,1,2},{0,2,1},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {0, 2, 1},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,1,1},{0,2,0},{2,1,1}] -> [{2,1,1},{2,2,0},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 2, 0},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,1,0},{1,2,0},{2,1,1}] -> [{2,1,2},{1,2,0},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {1, 2, 0},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,1,0},{0,2,1},{2,1,1}] -> [{2,1,2},{0,2,1},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {0, 2, 1},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,1,2},{0,2,0},{1,2,1}] -> [{1,1,2},{2,2,0},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 2},
                    {0, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{0,1,2},{1,2,0},{1,2,1}] -> [{2,1,2},{1,2,0},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 2},
                    {1, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,1,2},{0,2,1},{1,2,1}] -> [{2,1,2},{0,2,1},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 2},
                    {0, 2, 1},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{2,0,1},{1,2,2},{1,0,1}] -> [{2,0,1},{1,2,2},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 2, 2},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{2,0,1},{1,2,2},{0,1,1}] -> [{2,0,1},{1,2,2},{0,1,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 2, 2},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,2,1},{1,2,1},{0,0,2}] -> [{1,2,1},{1,2,1},{0,2,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {1, 2, 1},
                    {0, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{1,2,1},{0,2,1},{1,0,2}] -> [{1,2,1},{0,2,1},{1,2,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {0, 2, 1},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{1,2,1},{0,2,1},{0,1,2}] -> [{1,2,1},{0,2,1},{2,1,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {0, 2, 1},
                    {0, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,0,1},{2,2,1},{1,0,2}] -> [{1,2,1},{2,2,1},{1,0,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {2, 2, 1},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{0,1,1},{2,2,1},{1,0,2}] -> [{2,1,1},{2,2,1},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 1},
                    {2, 2, 1},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,1},{2,2,1},{1,1,2}] -> [{2,0,1},{2,2,1},{1,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {2, 2, 1},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{1,2,1},{1,2,0},{0,1,2}] -> [{1,2,1},{1,2,0},{2,1,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {1, 2, 0},
                    {0, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,2,1},{0,2,0},{1,1,2}] -> [{1,2,1},{2,2,0},{1,1,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {0, 2, 0},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{1,2,1},{1,2,2},{0,0,1}] -> [{1,2,1},{1,2,2},{0,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 2, 1},
                    {1, 2, 2},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{0,2,1},{1,2,2},{1,0,1}] -> [{0,2,1},{1,2,2},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 2, 1},
                    {1, 2, 2},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{0,2,1},{1,2,2},{0,1,1}] -> [{0,2,1},{1,2,2},{2,1,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 2, 1},
                    {1, 2, 2},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,0,2},{1,2,1},{1,0,1}] -> [{2,2,2},{1,2,1},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {1, 2, 1},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,0,2},{1,2,1},{0,1,1}] -> [{2,0,2},{1,2,1},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {1, 2, 1},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,0,1},{1,2,0},{1,2,1}] -> [{2,2,1},{1,2,0},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,0,0},{1,2,1},{1,2,1}] -> [{2,2,0},{1,2,1},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 0},
                    {1, 2, 1},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,1,1},{1,2,0},{2,1,0}] -> [{2,1,1},{1,2,0},{2,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {1, 2, 0},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,0,1},{1,2,1},{2,1,0}] -> [{2,0,1},{1,2,1},{2,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 2, 1},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,0,1},{1,2,0},{2,1,1}] -> [{2,0,1},{1,2,2},{2,1,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 2, 0},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,0,1},{1,2,2},{2,0,1}] -> [{1,2,1},{1,2,2},{2,0,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {1, 2, 2},
                    {2, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{0,1,1},{1,2,2},{2,0,1}] -> [{2,1,1},{1,2,2},{2,0,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 1},
                    {1, 2, 2},
                    {2, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{0,0,1},{1,2,2},{2,1,1}] -> [{2,0,1},{1,2,2},{2,1,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 1},
                    {1, 2, 2},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 0));
            }
            #endregion
            #region [{2,1,1},{1,1,0},{2,2,0}] -> [{2,1,1},{1,1,2},{2,2,0}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {1, 1, 0},
                    {2, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{2,1,1},{0,1,1},{2,2,0}] -> [{2,1,1},{2,1,1},{2,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 1, 1},
                    {2, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,1,1},{0,1,0},{2,2,1}] -> [{2,1,1},{2,1,0},{2,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {0, 1, 0},
                    {2, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,1,1},{1,1,2},{0,2,0}] -> [{2,1,1},{1,1,2},{2,2,0}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {1, 1, 2},
                    {0, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,1,0},{1,1,2},{1,2,0}] -> [{2,1,2},{1,1,2},{1,2,0}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {1, 1, 2},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,1,0},{1,1,2},{0,2,1}] -> [{2,1,2},{1,1,2},{0,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {1, 1, 2},
                    {0, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,1,1},{2,1,1},{0,2,0}] -> [{2,1,1},{2,1,1},{2,2,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {2, 1, 1},
                    {0, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,1,0},{2,1,1},{1,2,0}] -> [{2,1,2},{2,1,1},{1,2,0}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {2, 1, 1},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,1,0},{2,1,1},{0,2,1}] -> [{2,1,0},{2,1,1},{2,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {2, 1, 1},
                    {0, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,1,2},{1,1,0},{1,2,0}] -> [{2,1,2},{1,1,2},{1,2,0}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {1, 1, 0},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{2,1,2},{0,1,1},{1,2,0}] -> [{2,1,2},{2,1,1},{1,2,0}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {0, 1, 1},
                    {1, 2, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,1,2},{0,1,0},{1,2,1}] -> [{2,1,2},{0,1,0},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {0, 1, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{2,1,1},{2,1,0},{0,2,1}] -> [{2,1,1},{2,1,0},{2,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {2, 1, 0},
                    {0, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,1,0},{2,1,0},{1,2,1}] -> [{2,1,2},{2,1,0},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 0},
                    {2, 1, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,1,1},{1,1,2},{2,0,0}] -> [{2,1,1},{1,1,2},{2,2,0}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 1},
                    {1, 1, 2},
                    {2, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{2,0,1},{1,1,2},{2,1,0}] -> [{2,0,1},{1,1,2},{2,1,0}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 1, 2},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,0,1},{1,1,2},{2,0,1}] -> [{2,2,1},{1,1,2},{2,0,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 1},
                    {1, 1, 2},
                    {2, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,1,2},{1,1,2},{1,0,0}] -> [{2,1,2},{1,1,2},{1,0,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {1, 1, 2},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,0,2},{1,1,2},{1,1,0}] -> [{2,0,2},{1,1,2},{1,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {1, 1, 2},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 2));
            }
            #endregion
            #region [{2,0,2},{1,1,2},{1,0,1}] -> [{2,2,2},{1,1,2},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {1, 1, 2},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,2,1},{1,1,2},{0,1,0}] -> [{2,2,1},{1,1,2},{2,1,0}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 1},
                    {1, 1, 2},
                    {0, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,2,0},{1,1,2},{1,1,0}] -> [{2,2,2},{1,1,2},{1,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 0},
                    {1, 1, 2},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,2,0},{1,1,2},{0,1,1}] -> [{2,2,2},{1,1,2},{0,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 0},
                    {1, 1, 2},
                    {0, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,2,1},{1,1,2},{0,0,1}] -> [{2,2,1},{1,1,2},{2,0,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 1},
                    {1, 1, 2},
                    {0, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{2,2,0},{1,1,2},{1,0,1}] -> [{2,2,2},{1,1,2},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 0},
                    {1, 1, 2},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{2,1,2},{2,1,1},{1,0,0}] -> [{2,1,2},{2,1,1},{1,2,0}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {2, 1, 1},
                    {1, 0, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 1));
            }
            #endregion
            #region [{2,0,2},{2,1,1},{1,1,0}] -> [{2,2,2},{2,1,1},{1,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {2, 1, 1},
                    {1, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,0,2},{2,1,1},{1,0,1}] -> [{2,2,2},{2,1,1},{1,0,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 0, 2},
                    {2, 1, 1},
                    {1, 0, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{2,2,1},{1,1,0},{2,1,0}] -> [{2,2,1},{1,1,2},{2,1,0}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 1},
                    {1, 1, 0},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{2,2,1},{0,1,1},{2,1,0}] -> [{2,2,1},{2,1,1},{2,1,0}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 1},
                    {0, 1, 1},
                    {2, 1, 0}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,2,1},{0,1,0},{2,1,1}] -> [{2,2,1},{2,1,0},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 2, 1},
                    {0, 1, 0},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{2,1,2},{1,1,0},{0,2,1}] -> [{2,1,2},{1,1,2},{0,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {1, 1, 0},
                    {0, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{2,1,2},{0,1,1},{0,2,1}] -> [{2,1,2},{2,1,1},{0,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {2, 1, 2},
                    {0, 1, 1},
                    {0, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{1,1,0},{2,2,1},{1,0,2}] -> [{1,1,2},{2,2,1},{1,0,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 0},
                    {2, 2, 1},
                    {1, 0, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,0,0},{2,2,1},{1,1,2}] -> [{1,0,2},{2,2,1},{1,1,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 0},
                    {2, 2, 1},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,1,2},{0,2,1},{0,1,2}] -> [{1,1,2},{0,2,1},{2,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 2},
                    {0, 2, 1},
                    {0, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,0,2},{1,2,1},{0,1,2}] -> [{1,0,2},{1,2,1},{2,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {1, 2, 1},
                    {0, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 2, 0));
            }
            #endregion
            #region [{1,0,2},{0,2,1},{1,1,2}] -> [{1,0,2},{2,2,1},{1,1,2}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {0, 2, 1},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{1,0,2},{0,2,1},{1,2,1}] -> [{1,2,2},{0,2,1},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 2},
                    {0, 2, 1},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{0,0,2},{1,2,1},{1,2,1}] -> [{0,2,2},{1,2,1},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 0, 2},
                    {1, 2, 1},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 1));
            }
            #endregion
            #region [{1,1,0},{2,2,0},{1,1,2}] -> [{1,1,0},{2,2,2},{1,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 0},
                    {2, 2, 0},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,0,1},{2,2,0},{1,1,2}] -> [{1,0,1},{2,2,2},{1,1,2}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {2, 2, 0},
                    {1, 1, 2}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{1,1,0},{2,2,0},{1,2,1}] -> [{1,1,0},{2,2,2},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 1, 0},
                    {2, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{0,1,1},{2,2,0},{1,2,1}] -> [{0,1,1},{2,2,2},{1,2,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 1},
                    {2, 2, 0},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 2));
            }
            #endregion
            #region [{0,1,0},{2,2,1},{1,2,1}] -> [{0,1,2},{2,2,1},{1,2,1}] DRAW
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 0},
                    {2, 2, 1},
                    {1, 2, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 0, 2));
            }
            #endregion
            #region [{1,0,1},{0,2,2},{2,1,1}] -> [{1,0,1},{2,2,2},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {1, 0, 1},
                    {0, 2, 2},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #region [{0,1,1},{0,2,2},{2,1,1}] -> [{0,1,1},{2,2,2},{2,1,1}] WIN
            {
                TicTacToeGameStateImpl state = GetGameState((new byte[,]
                {
                    {0, 1, 1},
                    {0, 2, 2},
                    {2, 1, 1}
                }));
                perfectMoves.Add(state.GetStateHashCode(), GetChangedStateWhenSecond(state, 1, 0));
            }
            #endregion
            #endregion

            #endregion
        }

        ~PerfectTicTacToePlayer()
        {
            GameStateFactory<TicTacToeGameStateImpl>.ReturnGameStates(perfectMoves.Values.ToList());
        }

        private TicTacToeGameStateImpl GetGameState(byte[,] board)
        {
            TicTacToeGameStateImpl gameState = GameStateFactory<TicTacToeGameStateImpl>.GetNewGameState();
            gameState.SetState(board);
            return gameState;
        }

        private TicTacToeGameStateImpl GetChangedStateWhenFirst(TicTacToeGameStateImpl state, byte i, byte j)
        {
            state.SetSquare(i, j, 1);
            return state;
        }

        private TicTacToeGameStateImpl GetChangedStateWhenSecond(TicTacToeGameStateImpl state, byte i, byte j)
        {
            state.SetSquare(i, j, 2);
            return state;
        }

        public void PerformMove(Game game, GameState gameState)
        {
            TicTacToeGameStateImpl perfectMove = perfectMoves[gameState.GetStateHashCode()];
            Logger.LogDebug("Perfect Tic Tac Toe move from " + gameState.GetStateHashCode()
                            + " to " + perfectMove.GetStateHashCode() + ".");
            game.PerformMove(perfectMove);
        }
    }
}
