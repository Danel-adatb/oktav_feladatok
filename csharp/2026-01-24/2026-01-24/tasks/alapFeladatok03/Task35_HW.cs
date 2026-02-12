namespace _2026_01_24.tasks.alapFeladatok03;

public class Task35_HW
{
    public static void Run()
    {
        char start = 'a';
        char end = 'z';
        int count = end - start + 1;

        int maxRows = 10;

        // Minimális oszlopszám, hogy sor <= 10 legyen
        int columns = (int)Math.Ceiling(count / (double)maxRows);

        // Sorok száma az adott oszlopszámmal
        int rows = (int)Math.Ceiling(count / (double)columns);

        // Biztonság: ha mégis több lenne, növeljük az oszlopok számát
        while (rows > maxRows)
        {
            columns++;
            rows = (int)Math.Ceiling(count / (double)columns);
        }

        // Több oszlopos kiírás: (betű, ASCII) párok
        // Formátum példa: a(97)
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                int index = r + c * rows; // oszloponként töltjük
                if (index >= count) continue;

                char ch = (char)(start + index);
                int ascii = (int)ch;

                Console.Write($"{ch}({ascii})".PadRight(10));
            }
            Console.WriteLine();
        }
    }
}