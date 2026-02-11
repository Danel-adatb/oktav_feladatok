using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok01;

public class Task05
{
    public static void Run()
    {
        var a = Reader.ReadInt("Enter first integer: ");
        var b = Reader.ReadInt("Enter second integer: ");

        if (a < b)
        {
            Console.WriteLine($"{a} is smaller than {b}");
        }
        else
        {
            Console.WriteLine($"{a} is bigger than {b}");
        }
    }
}