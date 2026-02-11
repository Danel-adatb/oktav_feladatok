namespace _2026_01_24.tasks.alapFeladatok01;

public class Task02
{
    public static void Run()
    {
        Console.WriteLine("Enter your name: ");
        string? rawName = Console.ReadLine();
        
        string name = string.IsNullOrWhiteSpace(rawName)
            ? "Unknown Name"
            : rawName.Trim();
        
        Console.WriteLine($"Hello {name}!");
    }
}