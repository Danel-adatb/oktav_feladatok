using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok01;

public class Task14
{
    public static void Run()
    {
        double r = Reader.ReadPositiveDouble("Give the circle's radius: ");
        double alpha = Reader.ReadDouble("Enter the central angle in degrees (α): ");

        // Normalizálás: pl. 450° -> 90°
        alpha = alpha % 360;
        if (alpha < 0) alpha += 360;

        double arcLength = (alpha / 360.0) * (2 * Math.PI * r);
        double sectorArea = (alpha / 360.0) * (Math.PI * r * r);

        Console.WriteLine($"Radius (r): {r}");
        Console.WriteLine($"Degree (α): {alpha}°");
        Console.WriteLine($"Circle arc length (s): {arcLength}");
        Console.WriteLine($"Area of circle (A): {sectorArea}");
    }
}