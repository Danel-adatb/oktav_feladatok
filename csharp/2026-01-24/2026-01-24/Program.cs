
using _2026_01_24.tasks.alapFeladatok01;
using _2026_01_24.tasks.alapFeladatok02;
using _2026_01_24.tasks.alapFeladatok03;
using _2026_01_24.tasks.alapFeladatok04;

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
                
                [15] = ("Task15", Task15.Run),
                [16] = ("Task16", Task16.Run),
                [17] = ("Task17", Task17.Run),
                [18] = ("Task18", Task18.Run),
                [19] = ("Task19", Task19.Run),
                [20] = ("Task20", Task20.Run),
                [21] = ("Task21", Task21.Run),
                [22] = ("Task22", Task22.Run),
                [23] = ("Task23", Task23.Run),
                [24] = ("Task24", Task24.Run),
                [26] = ("Task26", Task26.Run),
                [27] = ("Task27", Task27.Run),
                [28] = ("Task28", Task28.Run),
                [29] = ("Task29", Task29.Run),
                [30] = ("Task30", Task30.Run),
                [31] = ("Task31", Task31.Run),
                
                [32] = ("Task32", Task32.Run),
                [33] = ("Task33", Task33.Run),
                [35] = ("Task35", Task35_HW.Run),
                
                [42] = ("Task42", Task42.Run),
                [43] = ("Task43", Task43_HW.Run),
                [44] = ("Task44", Task44.Run),
                [45] = ("Task45", Task45.Run),
                [46] = ("Task46", Task46_HW.Run),
                [47] = ("Task47", Task47.Run),
                [48] = ("Task48", Task48_HW.Run),
                [49] = ("Task49", Task49.Run),
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