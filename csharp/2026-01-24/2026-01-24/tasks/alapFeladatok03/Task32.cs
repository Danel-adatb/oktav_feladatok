using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok03;

public class Task32
{
    public static void Run()
    {
        int n = Reader.ReadPositiveInt("Give number: ");
        
        for (int row = 1; row <= n; row++)
        {
            for (int col = 1; col <= n; col++)
            {
                Console.Write($"{row * col,4}");
            }
            Console.WriteLine();
        }
    }
}