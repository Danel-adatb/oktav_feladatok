using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task26
{
    public static void Run()
    {
        int number = Reader.ReadInt("Please enter a number: ");
        Console.WriteLine($"Is prime? -> {Calculation.IsPrime(number)}");
    }
    
    
}