using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ClockSolver
    {
        private readonly List<int> _clock = new List<int>();
        public ClockSolver(List<int> clock)
        {
            _clock = clock;
        }

        public async Task<ClockSolution> SolveAsync(int startPos)
        {
            List<int> updatedClock = CopyClock(_clock);
            int startNum = updatedClock[startPos];
            updatedClock[startPos] = 0;
            int leftHand = MoveLeftHand(startPos, startNum);
            int rightHand = MoveRightHand(startPos, startNum);

            var currentPath = new ClockSolution()
            {
                NodeNumber = startNum,
                NodePos = startPos,
                UpdatedClock = updatedClock,
                NodeDepth = 1,
            };

            if (leftHand == rightHand)
            {
                currentPath.LeftNumber = updatedClock[leftHand];
                currentPath.RightNumber = 0;
                currentPath.LeftSolution = await SolveAsync(leftHand, updatedClock, 1);
            }
            else
            {
                currentPath.LeftNumber = updatedClock[leftHand];
                currentPath.RightNumber = updatedClock[rightHand];
                currentPath.LeftSolution = await SolveAsync(leftHand, updatedClock, 1);
                currentPath.RightSolution = await SolveAsync(rightHand, updatedClock, 1);
                if (currentPath.RightSolution.Solveable || currentPath.LeftSolution.Solveable)
                {
                    currentPath.Solveable = true;
                    if (currentPath.LeftSolution.Solveable)
                    {
                        currentPath.LeftSolveable = true;
                    }
                    else
                    {
                        currentPath.RightSolveable = true;
                    }
                }
            }

            return currentPath;
        }

        public async Task<ClockSolution> SolveAsync(int startPos, List<int> passedClock, int nodeDepth)
        {
            int startNum = passedClock[startPos];
            if(startNum == 0)
            {
                Console.WriteLine();
            }
            int currentNodeDepth = nodeDepth + 1;
            var updatedClock = CopyClock(passedClock);
            updatedClock[startPos] = 0;
            int leftHand = MoveLeftHand(startPos, startNum);
            int rightHand = MoveRightHand(startPos, startNum);
            var currentPath = new ClockSolution()
            {
                NodeNumber = startNum,
                NodePos = startPos,
                UpdatedClock = updatedClock,
                NodeDepth = currentNodeDepth,
            };

            if (leftHand == rightHand)
            {
                currentPath.LeftNumber = updatedClock[leftHand];
                currentPath.RightNumber = 0;
            }
            else
            {
                currentPath.LeftNumber = updatedClock[leftHand];
                currentPath.RightNumber = updatedClock[rightHand];
            }
            if (currentPath.LeftNumber == 0 && currentPath.RightNumber == 0)
            {
                if (updatedClock.All(x => x == 0))
                {
                    currentPath.Solveable = true;
                }
                return currentPath;
            }
            else if (currentPath.LeftNumber == 0)
            {
                currentPath.RightSolution = await SolveAsync(rightHand, updatedClock, currentNodeDepth);
                if (currentPath.RightSolution.Solveable)
                {
                    currentPath.Solveable = true;
                    currentPath.RightSolveable = true;
                }
            }
            else if (currentPath.RightNumber == 0)
            {
                currentPath.LeftSolution =  await SolveAsync(leftHand, updatedClock, currentNodeDepth);
                if (currentPath.LeftSolution.Solveable)
                {
                    currentPath.Solveable = true;
                    currentPath.LeftSolveable = true;
                }
            }
            else
            {
                currentPath.LeftSolution = await SolveAsync(leftHand, updatedClock, currentNodeDepth);
                currentPath.RightSolution = await SolveAsync(rightHand, updatedClock, currentNodeDepth);
                if (currentPath.RightSolution.Solveable || currentPath.LeftSolution.Solveable)
                {
                    currentPath.Solveable = true;
                    if (currentPath.LeftSolution.Solveable)
                    {
                        currentPath.LeftSolveable = true;
                    }
                    else
                    {
                        currentPath.RightSolveable = true;
                    }
                }
            }

            return currentPath;
        }

        private int MoveLeftHand(int currentPos, int timesToMove)
        {
            int updatedPos = currentPos;
            for (int i = 0; i < timesToMove; i++)
            {
                if (updatedPos - 1 < 0)
                {
                    updatedPos = _clock.Count - 1;
                }
                else
                {
                    updatedPos = updatedPos - 1;
                }
            }
            return updatedPos;
        }

        private int MoveRightHand(int currentPos, int timesToMove)
        {
            int updatedPos = currentPos;
            for (int i = 0; i < timesToMove; i++)
            {
                if (updatedPos + 1 >= _clock.Count)
                {
                    updatedPos = 0;
                }
                else
                {
                    updatedPos = updatedPos + 1;
                }
            }
            return updatedPos;
        }

        private List<int> CopyClock(List<int> passedClock)
        {
            List<int> ints = new List<int>();
            foreach(int i in passedClock)
            {
                ints.Add(i);
            }
            return ints;
        }
    }
}
