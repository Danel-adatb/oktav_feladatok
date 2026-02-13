using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok03;

public class Task38
{
    public static void Run()
    {
        int rows = Reader.ReadPositiveInt("Give the height of the triangle: ");

        for (int i = 1; i <= rows; i++)
        {
            // bal oldali szóközök (középre igazítás)
            Console.Write(new string(' ', rows - i));

            // csillagok (páratlan darabszám: 1,3,5,...)
            Console.WriteLine(new string('*', 2 * i - 1));
        }
    }
}