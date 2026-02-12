using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok01;

public class Task12
{
    public static void Run()
    {
        double a = Reader.ReadDouble("Give a: ");
        double b = Reader.ReadDouble("Give b: ");
        double c = Reader.ReadDouble("Give c: ");

        double volume = a * b * c;
        double surface = 2 * (a * b + a * c + b * c);
        
        Console.WriteLine($"Volume: {volume}");
        Console.WriteLine($"Surface: {surface}");
    }
}