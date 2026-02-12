using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task31
{
    public static void Run()
    {
        int a = Reader.ReadPositiveInt("Give a: ");
        int b = Reader.ReadPositiveInt("Give b: ");

        long lcm = Calculation.Lcm(a, b);

        Console.WriteLine($"The {a} and {b} numbers' last common multiple: {lcm}");
    }
}