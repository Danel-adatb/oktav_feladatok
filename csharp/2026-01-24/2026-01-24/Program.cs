
using _2026_01_24.tasks.alapFeladatok01;

namespace _2026_01_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Dictionary<int, (string Name, Action Run)>
            {
                [1] = ("Task01", Task01.Run),
                [2] = ("Task02", Task02.Run),
                [3] = ("Task03", Task03.Run),
                [4] = ("Task04", Task04.Run),
                [5] = ("Task05", Task05.Run),
                [6] = ("Task06", Task06.Run),
                [7] = ("Task07", Task07.Run),
                [8] = ("Task08", Task08.Run),
                [9] = ("Task09", Task09.Run),
                [12] = ("Task12", Task12.Run),
                [13] = ("Task13", Task13.Run),
                [14] = ("Task14", Task14.Run),
            };

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Available tasks:");
                foreach (var t in tasks)
                    Console.WriteLine($"{t.Key}. {t.Value.Name}");

                Console.Write("Choose (number) or 'q' to quit: ");
                var input = Console.ReadLine()?.Trim();

                if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
                    return;

                if (!int.TryParse(input, out var choice))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                if (!tasks.TryGetValue(choice, out var task))
                {
                    Console.WriteLine("Unknown task. Try again.");
                    continue;
                }

                Console.WriteLine();
                task.Run();
            }
        }
    }
}