using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task22
{
    public static void Run()
    {
        int number;
        int sum = 0;
        do
        {
            number = Reader.ReadInt("Give a number: ");
            sum += number;
        } while (number < 10);
        
        Console.WriteLine($"Sum: {sum}");
    }
}