using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok06;

public class Task63
{
    public static void Run()
    {
        string[] lines = Reader.ReadFile("forras63.be");
        
        if (lines.Length == 0 || !int.TryParse(lines[0].Trim(), out int count))
        {
            Console.WriteLine("Invalid or missing count in the first line.");
            return;
        }

        Console.WriteLine($"Count = {count}");

        var numbers = new List<int>();
        for (int i = 1; i < lines.Length; i++)
        {
            numbers.Add(int.Parse(lines[i]));
        }

        var filtered = numbers
            .OrderByDescending(s => s)
            .ToList();

        Console.WriteLine(string.Join(", ", filtered));
    }
}