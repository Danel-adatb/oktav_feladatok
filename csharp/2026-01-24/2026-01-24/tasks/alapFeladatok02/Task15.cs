using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task15
{
    public static void Run()
    {
        int number = Reader.ReadPositiveInt("Give a number to count to: ");

        Console.WriteLine("Numbers: ");
        for (int i = 1; i <= number; i++)
        {
            Console.Write($"{i} ");
        }
    }
}