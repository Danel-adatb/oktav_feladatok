using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok06;

public class Task69
{
    public static void Run()
    {
        string[] lines = Reader.ReadFile("forras69.be");
        
        var words = new List<string>();
        for (int i = 1; i < lines.Length; i++)
        {
            words.Add(lines[i]);
        }

        var filtered = words
            .Where(s => !s.ToLower().StartsWith("a"))
            .ToList();

        Console.WriteLine(string.Join(", ", filtered));
    }
}