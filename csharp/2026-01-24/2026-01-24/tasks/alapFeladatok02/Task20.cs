using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task20
{
    public static void Run()
    {
        double b = Reader.ReadDouble("Give the base: ");
        int e = Reader.ReadInt("Give exponent (integer): ");

        double result = Power(b, e);

        Console.WriteLine($"{b}^{e} = {result}");
    }

    private static double Power(double a, int n)
    {
        if (n == 0) return 1;

        double result = 1;
        int exp = Math.Abs(n);

        for (int i = 0; i < exp; i++)
            result *= a;

        // negatív kitevő: 1 / a^|n|
        return n < 0 ? 1.0 / result : result;
    }
}