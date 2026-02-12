using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task24
{
    public static void Run()
    {
        string input = Reader.ReadString("Please enter your string: ");
        while (input.ToLower() != "alma")
        {
            input = Reader.ReadString("Please enter your string: ");
        }
        
        Console.WriteLine("Az alma gyümölcs!");
    }
}