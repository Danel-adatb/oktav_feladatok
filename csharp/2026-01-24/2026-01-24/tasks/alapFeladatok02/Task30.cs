using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task30
{
    public static void Run()
    {
        int a = Reader.ReadPositiveInt("Give a: ");
        int b = Reader.ReadPositiveInt("Give b: ");

        int gcd = Calculation.Gcd(a, b);

        Console.WriteLine($"The {a} and {b} numbers' greatest common divident: {gcd}");
    }
}