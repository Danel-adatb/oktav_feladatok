using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok05;

public class Task50
{
    public static void Run()
    {
        string text = Reader.ReadString("Please enter your word: ");
        
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);

            if (i < text.Length - 1)
                Console.Write(' ');
        }

        Console.WriteLine();
    }
}