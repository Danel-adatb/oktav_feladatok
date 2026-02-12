using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task18
{
    public static void Run()
    {
        int number = Reader.ReadPositiveInt("Give a number: ");
        int count = 0;
        
        for (int i = 1; i <= number; i++)
            if (number % i == 0)
                count += i;
        
        Console.WriteLine($"'{number}' distributors sum: {count}");
    }
}