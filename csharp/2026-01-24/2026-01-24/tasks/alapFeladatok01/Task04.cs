using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok01;

public class Task04
{
    

    public static void Run()
    {
        var a = Reader.ReadInt("Enter first integer: ");
        var b = Reader.ReadInt("Enter second integer: ");

        Console.WriteLine($"Addition:  {a + b}");
        Console.WriteLine($"Deduction: {a - b}");
        Console.WriteLine($"Product: {a * b}");
        Console.WriteLine($"Ratio: {a / b}");
        Console.WriteLine($"Modulo: {a % b}");
    }

}