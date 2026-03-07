namespace _2026_03_07.utils;

public class Reader
{
    public static int ReadTask(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (int.TryParse(input?.Trim(), out var value) &&  value == 1 || value == 2)
                return value;

            Console.WriteLine("Kérlek próbáld újra!");
        }
    }
}