using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task17
{
    public static void Run()
    {
        int number = Reader.ReadPositiveInt("Give a number: ");
        
        Console.WriteLine($"{number} distributors: ");
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0) Console.Write(i + " ");
        }
    }
}