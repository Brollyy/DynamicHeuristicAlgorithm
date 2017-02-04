using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2048Core
{
    public class _2048BoardState
    {
        public ulong Board;

        private static Mutex _lock = new Mutex();

        private static Dictionary<ushort, int> scoreLookup = new Dictionary<ushort, int>();
        private static Dictionary<ushort, ushort> moveDownRightLookup = new Dictionary<ushort, ushort>();

        public static void SetUpLookups()
        {
            _lock.WaitOne();
            if (scoreLookup.Count == 0 && moveDownRightLookup.Count == 0)
            {
                for (ushort i = 0; i < 16; ++i)
                {
                    for (ushort j = 0; j < 16; ++j)
                    {
                        for (ushort k = 0; k < 16; ++k)
                        {
                            for (ushort l = 0; l < 16; ++l)
                            {
                                AddDownRight(i, j, k, l);
                            }
                        }
                    }
                }
            }
            _lock.ReleaseMutex();
        }

        private static void AddDownRight(ushort i, ushort j, ushort k, ushort l)
        {
            if(l == 0)
            {
                if(k == 0)
                {
                    if(j == 0)
                    {
                        if(i != 0)
                        {
                            moveDownRightLookup.Add((ushort)(i << 12), i);
                            scoreLookup.Add((ushort)(i << 12), 0);
                        }
                    }
                    else
                    {
                        if(i == j)
                        {
                            moveDownRightLookup.Add((ushort)((i << 12) + (j << 8)), (ushort)(i + 1));
                            scoreLookup.Add((ushort)((i << 12) + (j << 8)), 1 << (i + 1));
                        }
                        else
                        {
                            moveDownRightLookup.Add((ushort)((i << 12) + (j << 8)), (ushort)((i << 4) + j));
                            scoreLookup.Add((ushort)((i << 12) + (j << 8)), 0);
                        }
                    }
                }
                else
                {
                    if(j == 0)
                    {
                        if(i == k)
                        {
                            moveDownRightLookup.Add((ushort)((i << 12) + (k << 4)), (ushort)(i + 1));
                            scoreLookup.Add((ushort)((i << 12) + (k << 4)), 1 << (i + 1));
                        }
                        else
                        {
                            moveDownRightLookup.Add((ushort)((i << 12) + (k << 4)), (ushort)((i << 4) + k));
                            scoreLookup.Add((ushort)((i << 12) + (k << 4)), 0);
                        }
                    }
                    else
                    {
                        if(j == k)
                        {
                            moveDownRightLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4)), (ushort)((i << 4) + j + 1));
                            scoreLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4)), 1 << (j + 1));
                        }
                        else
                        {
                            if(i == j)
                            {
                                moveDownRightLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4)), (ushort)(((i + 1) << 4) + k));
                                scoreLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4)), 1 << (i + 1));
                            }
                            else
                            {
                                moveDownRightLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4)), (ushort)((i << 8) + (j << 4) + k));
                                scoreLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4)), 0);
                            }
                        }
                    }
                }
            }
            else
            {
                if(k == 0)
                {
                    if(j == 0)
                    {
                        if(i == l)
                        {
                            moveDownRightLookup.Add((ushort)((i << 12) + l), (ushort)(i + 1));
                            scoreLookup.Add((ushort)((i << 12) + l), 1 << (i + 1));
                        }
                        else if(i != 0)
                        {
                            moveDownRightLookup.Add((ushort)((i << 12) + l), (ushort)((i << 4) + l));
                            scoreLookup.Add((ushort)((i << 12) + l), 0);
                        }
                    }
                    else
                    {
                        if(j == l)
                        {
                            moveDownRightLookup.Add((ushort)((i << 12) + (j << 8) + l), (ushort)((i << 4) + (j + 1)));
                            scoreLookup.Add((ushort)((i << 12) + (j << 8) + l), 1 << (j + 1));
                        }
                        else
                        {
                            if(i == j)
                            {
                                moveDownRightLookup.Add((ushort)((i << 12) + (j << 8) + l), (ushort)(((i + 1) << 4) + l));
                                scoreLookup.Add((ushort)((i << 12) + (j << 8) + l), 1 << (i + 1));
                            }
                            else
                            {
                                moveDownRightLookup.Add((ushort)((i << 12) + (j << 8) + l), (ushort)((i << 8) + (j << 4) + l));
                                scoreLookup.Add((ushort)((i << 12) + (j << 8) + l), 0);
                            }
                        }
                    }
                }
                else
                {
                    if (k == l)
                    {
                        if(j == 0)
                        {
                            moveDownRightLookup.Add((ushort)((i << 12) + (k << 4) + l), (ushort)((i << 4) + (k + 1)));
                            scoreLookup.Add((ushort)((i << 12) + (k << 4) + l), 1 << (k + 1));
                        }
                        else
                        {
                            if(i == j)
                            {
                                moveDownRightLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4) + l), (ushort)(((i + 1) << 4) + (k + 1)));
                                scoreLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4) + l), (1 << (i + 1)) + (1 << (k + 1)));
                            }
                            else
                            {
                                moveDownRightLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4) + l), (ushort)((i << 8) + (j << 4) + (k + 1)));
                                scoreLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4) + l), 1 << (k + 1));
                            }
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            if (i != 0)
                            {
                                if (i == k)
                                {
                                    moveDownRightLookup.Add((ushort)((i << 12) + (k << 4) + l), (ushort)(((i + 1) << 4) + l));
                                    scoreLookup.Add((ushort)((i << 12) + (k << 4) + l), 1 << (i + 1));
                                }
                                else
                                {
                                    moveDownRightLookup.Add((ushort)((i << 12) + (k << 4) + l), (ushort)((i << 8) + (k << 4) + l));
                                    scoreLookup.Add((ushort)((i << 12) + (k << 4) + l), 0);
                                }
                            }
                        }
                        else
                        {
                            if (j == k)
                            {
                                moveDownRightLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4) + l), (ushort)((i << 8) + ((j + 1) << 4) + l));
                                scoreLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4) + l), 1 << (j + 1));
                            }
                            else if (i == j)
                            {
                                moveDownRightLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4) + l), (ushort)(((i + 1) << 8) + (k << 4) + l));
                                scoreLookup.Add((ushort)((i << 12) + (j << 8) + (k << 4) + l), 1 << (i + 1));
                            }
                        }
                    }
                }
            }
        }

        public _2048BoardState()
        {
            Clear();
        }

        public void Clear()
        {
            Board = 0UL;
        }

        public _2048BoardState(_2048BoardState state)
        {
            SetBoard(state.Board);
        }

        public void SetBoard(ulong state)
        {
            Board = state;
        }

        public _2048BoardState(ulong state) : base()
        {
            SetBoard(state);
        }

        public Tuple<bool,int> MoveUp()
        {
            _lock.WaitOne();
            bool changed = false;
            int score = 0;
            for(byte i = 0; i < 4; ++i)
            {
                ushort col = (ushort)((GetCell(3, i) << 12) + (GetCell(2, i) << 8) + (GetCell(1, i) << 4) + GetCell(0, i));
                if(moveDownRightLookup.ContainsKey(col))
                {
                    changed = true;
                    score += scoreLookup[col];
                    col = moveDownRightLookup[col];
                    SetCell(0, i, (byte)(col & 0xF));
                    SetCell(1, i, (byte)((col >> 4) & 0xF));
                    SetCell(2, i, (byte)((col >> 8) & 0xF));
                    SetCell(3, i, (byte)((col >> 12) & 0xF));
                }
            }
            _lock.ReleaseMutex();

            return new Tuple<bool, int>(changed, score);
        }

        public Tuple<bool,int> MoveDown()
        {
            _lock.WaitOne();
            bool changed = false;
            int score = 0;
            for (byte i = 0; i < 4; ++i)
            {
                ushort col = (ushort)((GetCell(0, i) << 12) + (GetCell(1, i) << 8) + (GetCell(2, i) << 4) + GetCell(3, i));
                if (moveDownRightLookup.ContainsKey(col))
                {
                    changed = true;
                    score += scoreLookup[col];
                    col = moveDownRightLookup[col];
                    SetCell(3, i, (byte)(col & 0xF));
                    SetCell(2, i, (byte)((col >> 4) & 0xF));
                    SetCell(1, i, (byte)((col >> 8) & 0xF));
                    SetCell(0, i, (byte)((col >> 12) & 0xF));
                }
            }
            _lock.ReleaseMutex();

            return new Tuple<bool, int>(changed, score);
        }

        public Tuple<bool, int> MoveLeft()
        {
            _lock.WaitOne();
            bool changed = false;
            int score = 0;
            for(byte i = 0; i < 4; ++i)
            {
                ushort row = (ushort)((GetCell(i, 3) << 12) + (GetCell(i, 2) << 8) + (GetCell(i, 1) << 4) + GetCell(i, 0));
                if(moveDownRightLookup.ContainsKey(row))
                {
                    changed = true;
                    score += scoreLookup[row];
                    row = moveDownRightLookup[row];
                    SetCell(i, 0, (byte)(row & 0xF));
                    SetCell(i, 1, (byte)((row >> 4) & 0xF));
                    SetCell(i, 2, (byte)((row >> 8) & 0xF));
                    SetCell(i, 3, (byte)((row >> 12) & 0xF));
                }
            }
            _lock.ReleaseMutex();

            return new Tuple<bool, int>(changed, score);
        }

        public Tuple<bool, int> MoveRight()
        {
            _lock.WaitOne();
            bool changed = false;
            int score = 0;
            for (byte i = 0; i < 4; ++i)
            {
                int offset = ((3 - i) << 4);
                ushort row = (ushort)((Board >> offset) & 0xFFFF);
                if (moveDownRightLookup.ContainsKey(row))
                {
                    changed = true;
                    score += scoreLookup[row];
                    row = moveDownRightLookup[row];
                    Board &= ~(0xFFFFUL << offset);
                    Board += (ulong)(row) << offset;
                }
            }
            _lock.ReleaseMutex();

            return new Tuple<bool, int>(changed, score);
        }

        public byte GetCell(byte i, byte j)
        {
            return (byte)((Board >> ((((3 - i) << 4) + ((3 - j) << 2)))) & 0xF);
        }

        public void SetCell(byte i, byte j, byte x)
        {
            int offset = (((3 - i) << 4) + ((3 - j) << 2));
            Board &= ~(0xFUL << offset);
            Board += (ulong)(x) << offset;
        }

        public bool IsTerminal()
        {
            for(byte i = 0; i < 4; ++i)
            {
                for(byte j = 0; j < 4; ++j)
                {
                    byte v = GetCell(i, j);
                    if(v != 0)
                    {
                        if (i > 0 && GetCell((byte)(i - 1), j) == v) return false;
                        if (i < 3 && GetCell((byte)(i + 1), j) == v) return false;
                        if (j > 0 && GetCell(i, (byte)(j - 1)) == v) return false;
                        if (j < 3 && GetCell(i, (byte)(j + 1)) == v) return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    public class _2048Game
    {
        private _2048BoardState boardState;

        public _2048Game()
        {
            _2048BoardState.SetUpLookups();
            boardState = new _2048BoardState();
        }

        public void RestartGame()
        {
            boardState.Clear();
        }

        public _2048BoardState GetBoardState()
        {
            return boardState;
        }

        public void MakeMove(ulong move)
        {
            boardState.Board = move;
        }
    }
}
