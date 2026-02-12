using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task28
{
    public static void Run()
    {
        int number = Reader.ReadPositiveInt("Please give an integer: ");

        if (number < 2)
            Console.WriteLine("The number is smaller than 2.");
        else
            Console.WriteLine($"The '{number}' prime dividents: {string.Join(", ", Calculation.GetPrimeDivisors(number))}");
    }
}