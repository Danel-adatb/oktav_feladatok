using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok06;

public class Task62
{
    public static void Run()
    {
        string[] lines = Reader.ReadFile("forras62.be");
        
        if (lines.Length == 0 || !int.TryParse(lines[0].Trim(), out int count))
        {
            Console.WriteLine("Invalid or missing count in the first line.");
            return;
        }

        Console.WriteLine($"Count = {count}");

        var words = new List<string>();
        for (int i = 1; i < lines.Length; i++)
        {
            words.Add(lines[i]);
        }

        var filtered = words
            .Where(s => s.ToLower().StartsWith("a"))
            .ToList();

        Console.WriteLine(string.Join(", ", filtered));
    }
}