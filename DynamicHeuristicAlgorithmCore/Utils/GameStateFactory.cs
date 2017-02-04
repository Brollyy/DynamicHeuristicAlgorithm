using DynamicHeuristicAlgorithmCore.GameInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicHeuristicAlgorithmCore.Utils
{
    public static class GameStateFactory<T> where T : GameState, new()
    {
        private static Queue<T> inactivePool = new Queue<T>();
        private static HashSet<T> activePool = new HashSet<T>();

        private static Object lockObject = new Object();

        public static T GetNewGameState(T gameState)
        {
            T newGameState = default(T);
            lock(lockObject)
            {
                if (inactivePool.Any())
                {
                    newGameState = inactivePool.Dequeue();
                    newGameState.SetState(gameState);
                }
                else
                {
                    newGameState = new T();
                    newGameState.SetState(gameState);
                }
                activePool.Add(newGameState);
            }
            return newGameState;
        }

        public static T GetNewGameState()
        {
            T newGameState = default(T);
            lock(lockObject)
            {
                if (inactivePool.Any())
                {
                    newGameState = inactivePool.Dequeue();
                    newGameState.Clear();
                }
                else
                {
                    newGameState = new T();
                }
                activePool.Add(newGameState);
            }
            return newGameState;
        }

        public static void ReturnGameStates(List<T> gameStates)
        {
            lock(lockObject)
            {
                foreach (T gameState in gameStates)
                {
                    if (activePool.Contains(gameState))
                    {
                        activePool.Remove(gameState);
                        inactivePool.Enqueue(gameState);
                    }
                }
            }
        }

        public static void ReturnGameState(T gameState)
        {
            lock(lockObject)
            {
                if (activePool.Contains(gameState))
                {
                    activePool.Remove(gameState);
                    inactivePool.Enqueue(gameState);
                }
            }
        }
    }
}
