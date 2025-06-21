using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ClockSolution
    {
        public int? NodeNumber { get; set; } = null;
        public int LeftNumber { get; set; }
        public int RightNumber { get; set; }

        public int NodePos { get; set; }

        public bool Solveable { get; set; } = false;
        public int NodeDepth { get; set; }
        public bool LeftSolveable { get; set; } = false;
        public bool RightSolveable { get; set; } = false;

        public List<int> UpdatedClock { get; set; }
        public ClockSolution? LeftSolution { get; set; }
        public ClockSolution? RightSolution { get; set; }

        public string PrintSolution()
        {
            if(Solveable)
            {
                if (LeftSolveable)
                {
                    return NodeNumber.ToString() + " -> " + LeftSolution.PrintSolution();
                }
                else if (RightSolveable) {
                    return NodeNumber.ToString() + " -> " + RightSolution.PrintSolution();
                }
                else
                {
                    return NodeNumber.ToString();
                }
            }
            else
            {
                return "NOT SOLVEABLE";
            }
        }

        public string PrintSolutionPos()
        {
            if (Solveable)
            {
                if (LeftSolveable)
                {
                    return NodePos.ToString() + " -> " + LeftSolution.PrintSolutionPos();
                }
                else if (RightSolveable)
                {
                    return NodePos.ToString() + " -> " + RightSolution.PrintSolutionPos();
                }
                else
                {
                    return NodePos.ToString();
                }
            }
            else
            {
                return "NOT SOLVEABLE";
            }
        }

        public override string ToString()
        {
            if (NodeNumber == null)
                return "";
            if (LeftSolution != null && RightSolution != null)
            {
                var leftString = NodeNumber.Value.ToString() + " -> " + LeftSolution.ToString();
                var rightString = "\r\n";
                rightString += NodeNumber.Value.ToString() + " -> " + RightSolution.ToString();
                return leftString + rightString;
            }
            else if(LeftSolution != null)
            {
                var leftString = NodeNumber.Value.ToString() + " -> " + LeftSolution.ToString();
                return leftString;
            }
            else if(RightSolution != null)
            {
                var rightString = NodeNumber.Value.ToString() + " -> " + RightSolution.ToString();
                return rightString;
            }
            else
            {
                return NodeNumber.Value.ToString() + "  | " + NodeDepth.ToString();
            }

        }
    }
}
