using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok04;

public class Task43_HW
{
    public static void Run()
    {
        int count = Reader.ReadPositiveInt("Please give the count: ");
        var list = new List<int>();

        for (int i = 0; i < count; i++)
        {
            list.Add(Reader.ReadPositiveInt($"Please give the {i+1}. number: "));
        }
        
        Console.Write("Even numbers: ");
        Console.WriteLine(string.Join(", ", list.Where(n => n % 2 == 0)));
    }
}