using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok03;

public class Task37
{
    public static void Run()
    {
        int a = Reader.ReadPositiveInt("Give a number: ");

        for (int i = 1; i <= a; i++)
        {
            Console.WriteLine(new string('*', i));
        }
    }
}