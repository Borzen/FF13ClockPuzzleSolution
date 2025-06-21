// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> clock = new List<int>();
        //{
        //    3, 6, 2, 4, 6, 6, 2, 5, 5, 4, 5, 5
        //};
        while (clock.Count <= 0)
        {
            clock = new List<int>();
            Console.WriteLine("enter a clock from noon to noon seperated by commas");
            Console.WriteLine("Press Q to quit");
            var clockString = Console.ReadLine();
            var clockSplit = clockString.Split(',');
            if (string.Equals(clockString, "q", StringComparison.OrdinalIgnoreCase))
            {
                return;
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
            var solutions = clockSolutions.Where(x => x.Result.Solveable).Select(x=>x.Result).ToList();
            foreach(var solution in solutions)
            { 
                Console.WriteLine("Positions: " + solution.PrintSolutionPos());
                Console.WriteLine("Numbers: " + solution.PrintSolution());
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            Console.WriteLine("This is a pause so you can read evertying\r\n press anykey when done");
            Console.ReadKey();
        }
    }
}
