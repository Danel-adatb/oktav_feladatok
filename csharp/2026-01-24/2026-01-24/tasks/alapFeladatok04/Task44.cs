using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok04;

public class Task44
{
    public static void Run()
    {
        int count = Reader.ReadPositiveInt("Please give the count: ");
        var list = new List<(int Index, int Value)>();

        for (int i = 0; i < count; i++)
        {
            int value = Reader.ReadPositiveInt($"Please give the {i + 1}. number: ");
            list.Add((i, value));
        }
        
        Console.WriteLine("Even numbers: ");
        foreach (var item in list.Where(n => n.Value % 2 == 0))
        {
            Console.WriteLine($"Index {item.Index + 1}: {item.Value}");
        }
    }
}