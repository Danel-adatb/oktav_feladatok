using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok01;

public class Task08
{
    public static void Run()
    {
        var a = Reader.ReadIntWithNegativityValidation("Enter first integer: ");
        var b = Reader.ReadIntWithNegativityValidation("Enter second integer: ");
        int[] array = { a, b };
        double arithmeticMean = (double)(array[0] + array[1])/array.Length;
        double geometricMean = Math.Sqrt(a * b);
        
        Console.WriteLine($"Arithmetic mean: {arithmeticMean}");
        Console.WriteLine($"Geometric mean: {geometricMean}");
    }
}