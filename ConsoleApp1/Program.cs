// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        var keepRunning = true;
        while (keepRunning)
        {
           keepRunning = MainLoop();
        }
    }

    private static bool MainLoop()
    {
        List<int> clock = new List<int>();

        while (clock.Count <= 0)
        {
            clock = new List<int>();
            Console.WriteLine("enter a clock starting at noon clockwise seperated by commas");
            Console.WriteLine("Press Q to quit");
            var clockString = Console.ReadLine();
            var clockSplit = clockString.Split(',');
            if (string.Equals(clockString, "q", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            foreach (var clockItem in clockSplit)
            {
                if (int.TryParse(clockItem, out int value))
                {
                    clock.Add(value);
                }
                else
                {
                    Console.WriteLine("Error Reading: " + clockItem);
                    Console.WriteLine("Please try again");
                    Console.Clear();

                }
            }
        }
        List<Task<ClockSolution>> clockSolutions = new List<Task<ClockSolution>>();

        var solver = new ClockSolver(clock);
        for (int i = 0; i < clock.Count; i++)
        {
            clockSolutions.Add(solver.SolveAsync(i));
        }
        try
        {
            Task.WhenAll(clockSolutions).Wait();
            var solutions = clockSolutions.Where(x => x.Result.Solveable).Select(x => x.Result).ToList();
            foreach (var solution in solutions)
            {
                Console.WriteLine("Positions: " + solution.PrintSolutionPos());
                Console.WriteLine("Numbers: " + solution.PrintSolution());
                Console.WriteLine();
            }
            Console.WriteLine("This is a pause so you can read evertying\r\npress Q to quit and anything else to run again.");
            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.Q)
            {
                return false;
            }
            else
            {
                Console.Clear();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.WriteLine("\r\n\r\nSomething broke HARD. Please copy the console's output, the clock you were trying to solve and put them in a github issue here. https://github.com/Borzen/FF13ClockPuzzleSolution/issues/new ");
            Console.ReadLine();
            return false;
        }
    }
}
