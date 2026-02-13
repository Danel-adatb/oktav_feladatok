using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok03;

public class Task36
{
    public static void Run()
    {
        int rows = Reader.ReadPositiveInt("Please give the number of rows: ");
        int cols = Reader.ReadPositiveInt("Please give the number of columns: ");

        for (int r = 1; r <= rows; r++)
        {
            char firstChar = (r % 2 == 0) ? 'O' : 'X'; // páros sor: O, páratlan sor: X

            for (int c = 0; c < cols; c++)
            {
                char ch = (c % 2 == 0) ? firstChar : (firstChar == 'X' ? 'O' : 'X');
                Console.Write(ch);
            }

            Console.WriteLine();
        }
    }
}