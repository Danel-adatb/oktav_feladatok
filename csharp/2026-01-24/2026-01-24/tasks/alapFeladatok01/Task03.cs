using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok01;

public class Task03
{
    public static void Run()
    {
        var number = Reader.ReadInt("Enter integer number: ");

        Console.WriteLine($"You entered: {number}");
    }
}