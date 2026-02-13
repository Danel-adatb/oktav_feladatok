using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok06;

public class Task60
{
    public static void Run()
    {
        string[] lines = Reader.ReadFile("forras60.be");
        
        if (lines.Length == 0 || !int.TryParse(lines[0].Trim(), out int count))
        {
            Console.WriteLine("Invalid or missing count in the first line.");
            return;
        }

        Console.WriteLine($"Count = {count}");
        
        var numbers = new List<int>();
        for (int i = 0; i < lines.Length; i++)
        {
            numbers.Add(int.Parse(lines[i]));
        }
        
        var oddNumbers = numbers.Where(n => n % 2 != 0).ToList();
        int oddCount = oddNumbers.Count;
        double oddAverage = oddCount > 0 ? oddNumbers.Average() : 0;
        
        Console.WriteLine($"Odd count: {oddCount}");
        Console.WriteLine(oddCount > 0 ? $"Odd average: {oddAverage}" : "Odd average: N/A (no odd numbers)");
    }
}