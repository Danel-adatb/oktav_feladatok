using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok06;

public class Task68
{
    public static void Run()
    {
        string[] lines = Reader.ReadFile("forras68.be");

        var words = new List<string>();
        for (int i = 1; i < lines.Length; i++)
        {
            words.Add(lines[i]);
        }
        
        var shortest = words
            .Where(s => !string.IsNullOrEmpty(s))
            .OrderBy(s => s.Length)
            .FirstOrDefault();

        Console.WriteLine(shortest ?? "No strings.");
    }
}