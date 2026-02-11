using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok01;

public class Task09
{
    public static void Run()
    {
        double a = Reader.ReadDouble("Give double a: ");
        double b = Reader.ReadDouble("Give double b: ");
        double c = Reader.ReadDouble("Give double c: ");

        if (a == 0)
        {
            Console.WriteLine("It is not quadratic equation (a = 0).");
            return;
        }

        double D = b * b - 4 * a * c;

        if (D > 0)
        {
            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
            double x2 = (-b - Math.Sqrt(D)) / (2 * a);
            Console.WriteLine($"Existing roots: x1 = {x1}, x2 = {x2}");
        }
        else if (D == 0)
        {
            double x = (-b) / (2 * a);
            Console.WriteLine($"Existing root (double): x = {x}");
        }
        else
        {
            Console.WriteLine("NO existing root (D < 0).");
        }
    }
}