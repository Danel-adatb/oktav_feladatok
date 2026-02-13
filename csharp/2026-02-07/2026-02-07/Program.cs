
using _2026_02_07.tasks.alapFeladatok05;
using _2026_02_07.tasks.alapFeladatok06;

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
                
                [58] = ("Task58", Task58.Run),
                [59] = ("Task59", Task59.Run),
                [60] = ("Task60", Task60.Run),
                [61] = ("Task61", Task61.Run),
                [62] = ("Task62", Task62.Run),
                [63] = ("Task63", Task63.Run),
                [64] = ("Task64", Task64.Run),
                [65] = ("Task65", Task65.Run),
                [66] = ("Task66", Task66.Run),
                [67] = ("Task67", Task67.Run),
                [68] = ("Task68", Task68.Run),
                [69] = ("Task69", Task69.Run),
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