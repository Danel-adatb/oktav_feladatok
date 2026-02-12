using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok01;

public class Task13
{
    public static void Run()
    {
        double d = Reader.ReadPositiveDouble("Give the diameter: ");
        double radius = d / 2;
        double district = 2*Math.PI*radius;
        double area = Math.PI*radius*radius;
        
        Console.WriteLine($"District: {district}, Area: {area}");
    }
}