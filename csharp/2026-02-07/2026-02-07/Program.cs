
using _2026_02_07.tasks.alapFeladatok05;

namespace _2026_02_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Dictionary<int, (string Name, Action Run)>
            {
                [50] = ("Task50", Task50.Run),
                [51] = ("Task51", Task51.Run),
                [52] = ("Task52", Task52.Run),
                [53] = ("Task53", Task53.Run),
                [54] = ("Task54", Task54.Run),
                [55] = ("Task55", Task55.Run),
                [56] = ("Task56", Task56.Run),
                [57] = ("Task57", Task57.Run),
            };

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Available tasks:");
                foreach (var t in tasks)
                    Console.Write($"{t.Key} ");

                Console.Write("\nChoose (number) or 'q' to quit: ");
                var input = Console.ReadLine()?.Trim();

                if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
                    return;

                if (!int.TryParse(input, out var choice))
                {
                    Console.WriteLine("\nInvalid input. Try again.");
                    continue;
                }

                if (!tasks.TryGetValue(choice, out var task))
                {
                    Console.WriteLine("\nUnknown task. Try again.");
                    continue;
                }

                Console.WriteLine();
                task.Run();
            }
        }
    }
}