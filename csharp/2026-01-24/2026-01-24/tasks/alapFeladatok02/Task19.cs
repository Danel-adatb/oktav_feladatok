using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task19
{
    public static void Run()
    {
        int number = Reader.ReadPositiveInt("Give a number: ");
        int count = 0;
        
        for (int i = 1; i <= number; i++)
            if (number % i == 0)
                count += i;

        if(number*2 == count)
            Console.WriteLine($"'{number}' is a perfect number.");
        else
            Console.WriteLine($"'{number}' is NOT a perfect number.");
    }
}