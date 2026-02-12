using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task29
{
    public static void Run()
    {
        int number = Reader.ReadPositiveInt("Please give an integer");
        
        if (number < 2)
        {
            Console.WriteLine("2-nél kisebb számnak nincs klasszikus prímtényezős felbontása.");
        }
        else
        {
            var factors = Calculation.PrimeFactorization(number);

            Console.Write($"{number} = ");
            Console.WriteLine(string.Join(" * ", factors.ConvertAll(f => $"{f.Prime}^{f.Power}")));
        }
            
    }
}