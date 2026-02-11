using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok01;

public class Task06
{
    public static void Run()
    {
        var a = Reader.ReadInt("Enter first integer: ");
        var b = Reader.ReadInt("Enter second integer: ");
        var c = Reader.ReadInt("Enter third integer: ");
        int[] array = {a, b, c}; 

        Console.WriteLine($"\nSmallest number: {array.Min()}");
    }
}