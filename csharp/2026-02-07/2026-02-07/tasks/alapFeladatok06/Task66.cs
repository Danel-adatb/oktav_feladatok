using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok06;

public class Task66
{
    public static void Run()
    {
        string[] lines = Reader.ReadFile("forras66.be");

        var numbers = new List<int>();
        for (int i = 1; i < lines.Length; i++)
        {
            numbers.Add(int.Parse(lines[i]));
        }

        int biggestEven = numbers.Where(n => n % 2 == 0).Max();
        
        Console.Write(string.Join(", ", numbers));
        Console.WriteLine($"\nMax Even: {biggestEven}");
    }
}