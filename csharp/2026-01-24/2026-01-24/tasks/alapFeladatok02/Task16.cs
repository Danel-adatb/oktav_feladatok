using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task16
{
    public static void Run()
    {
        int number = Reader.ReadPositiveInt("Give a number to count to: ");
        int i = 1;

        Console.WriteLine("Numbers: ");
        while (i <= number)
        {
            Console.Write($"{i}\n");
            i++;
        }
    }
}