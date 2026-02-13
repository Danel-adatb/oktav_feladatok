using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok03;

public class Task39
{
    public static void Run()
    {
        int m = Reader.ReadPositiveInt("Give m: ");
        int n = Reader.ReadPositiveInt("Give n: ");

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                bool border = row == 0 || row == n - 1 || col == 0 || col == m - 1;
                Console.Write(border ? '*' : ' ');
            }
            Console.WriteLine();
        }
    }
}