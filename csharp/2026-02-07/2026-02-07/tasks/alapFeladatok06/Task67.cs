using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok06;

public class Task67
{
    public static void Run()
    {
        string[] lines = Reader.ReadFile("forras67.be");
        
        var numbers = new List<int>();
        for (int i = 0; i < lines.Length; i++)
        {
            numbers.Add(int.Parse(lines[i]));
        }
        
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
        double evenSum = evenNumbers.Sum();
        
        Console.Write(string.Join(", ", numbers));
        Console.WriteLine($"\nEven sum: {evenSum}");
    }
}