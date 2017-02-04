using DynamicHeuristicAlgorithmCore.PlayerInterface;
using DynamicHeuristicAlgorithmCore.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicHeuristicAlgorithmCore.GameInterface
{
    public abstract class GameStatistics
    {
        public bool StartedPlaying;
        public long Score;
        public List<Tuple<GameState, GameState>> Moves = new List<Tuple<GameState, GameState>>();
        public List<double> MovesDurations = new List<double>();
        public double GameDuration;

        ~GameStatistics()
        {
            ReturnMovesStates();
        }

        public void SaveStatistics(string filename)
        {
            bool exists = File.Exists(filename);
            using (StreamWriter stream = new StreamWriter(filename, true))
            {
                if (!exists)
                {
                    Logger.LogDebug("Thread " + Thread.CurrentThread.ManagedThreadId + " - No file in " + filename + ". Creating new one with header.");
                    WriteHeader(stream);
                    stream.WriteLine();
                }
                Logger.LogDebug("Thread " + Thread.CurrentThread.ManagedThreadId + " - Writing statistics to file.");
                WriteStatistics(stream);
                stream.WriteLine();
                Logger.LogDebug("Thread " + Thread.CurrentThread.ManagedThreadId + " - Done writing statistics to file.");
            }
        }

        protected virtual void WriteStatistics(StreamWriter stream)
        {
            stream.Write(StartedPlaying + ";");

            stream.Write(Score + ";");

            stream.Write(Moves.Count + ";");

            int n = MovesDurations.Count;
            stream.Write(GameDuration + ";");

            double sumMovesDuration = 0;
            for(int i = 0; i < n; ++i)
            {
                sumMovesDuration += MovesDurations[i];
            }
            double averageMoveDuration = sumMovesDuration / n;
            stream.Write(averageMoveDuration + ";");

            double moveDurationMedian = (n % 2 == 0 ? 
                (MovesDurations[n / 2 - 1] + MovesDurations[n / 2]) / 2 : 
                MovesDurations[(n - 1) / 2]);
            stream.Write(moveDurationMedian + ";");

            double moveDurationStandardDeviation = 0;
            for(int i = 0; i < n; ++i)
            {
                moveDurationStandardDeviation += 
                    (MovesDurations[i] - averageMoveDuration) * (MovesDurations[i] - averageMoveDuration);
            }
            moveDurationStandardDeviation /= n;
            moveDurationStandardDeviation = Math.Sqrt(moveDurationStandardDeviation);
            stream.Write(moveDurationStandardDeviation);
        }

        protected virtual void WriteHeader(StreamWriter stream)
        {
            stream.Write("STARTED_PLAYING;");
            stream.Write("SCORE;");
            stream.Write("NUMBER_OF_MOVES;");
            stream.Write("GAME_DURATION;");
            stream.Write("AVERAGE_MOVE_DURATION;");
            stream.Write("MOVE_DURATION_MEDIAN;");
            stream.Write("MOVE_DURATION_STANDARD_DEVIATION");
        }

        public virtual void Clear()
        {
            StartedPlaying = true;
            Score = 0;
            ReturnMovesStates();
            Moves.Clear();
            MovesDurations.Clear();
            GameDuration = 0;
        }

        private void ReturnMovesStates()
        {
            Type gameStateFactoryType = typeof(GameStateFactory<>);
            Type[] typeArgs = { GetGameStateType() };
            Type gameStateFactory = gameStateFactoryType.MakeGenericType(typeArgs);
            MethodInfo returnStateMethod = gameStateFactory.GetMethod("ReturnGameState");
            foreach(Tuple<GameState, GameState> move in Moves)
            {
                returnStateMethod.Invoke(null, new object[] { move.Item1 });
                returnStateMethod.Invoke(null, new object[] { move.Item2 });
            }
        }

        protected abstract Type GetGameStateType();
    }
}
