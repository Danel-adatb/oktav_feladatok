using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok06;

public class Task65
{
    public static void Run()
    {
        string[] lines = Reader.ReadFile("forras65.be");

        var numbers = new List<int>();
        for (int i = 1; i < lines.Length; i++)
        {
            numbers.Add(int.Parse(lines[i]));
        }

        Console.Write(string.Join(", ", numbers));
        Console.WriteLine($"\nMin: {numbers.Min()}");
    }
}