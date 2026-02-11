using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok01;

public class Task07
{
    private static bool IsTrianglePossible(int a, int b, int c)
    {
        if (a <= 0 || b <= 0 || c <= 0) return false;

        int[] array = { a, b, c };
        Array.Sort(array);

        return (long)array[0] + array[1] > array[2];
    }
    
    public static void Run()
    {
        var a = Reader.ReadInt("Enter first integer: ");
        var b = Reader.ReadInt("Enter second integer: ");
        var c = Reader.ReadInt("Enter third integer: ");
        Console.WriteLine(IsTrianglePossible(a, b, c)
            ? "Triangle is possible."
            : "Triangle is NOT possible.");
    }
}