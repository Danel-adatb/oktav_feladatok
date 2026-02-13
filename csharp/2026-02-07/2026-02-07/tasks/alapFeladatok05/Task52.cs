using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok05;

public class Task52
{
    public static void Run()
    {
        string text = Reader.ReadString("Please give your text: ");

        for (int i = 1; i < text.Length; i += 2)
        {
            Console.WriteLine(text[i]);
        }
    }
}