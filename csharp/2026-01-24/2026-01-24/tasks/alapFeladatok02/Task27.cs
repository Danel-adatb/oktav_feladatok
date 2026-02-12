using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task27
{
    public static void Run()
    {
        int number = Reader.ReadPositiveInt("Enter an integer: ");
        var list = new List<int>();

        for (int i = 1; i <= number; i++)
            if(Calculation.IsPrime(i))
                list.Add(i);
        
        Console.WriteLine("Primes: ");
        Console.Write(string.Join(", ", list));
    }
}