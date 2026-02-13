using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok05;

public class Task54
{
    public static void Run()
    {
        string text = Reader.ReadString("Please give your text: ");

        for (int i = text.Length - 1; i >= 0 ; i--)
        {
            Console.Write(text[i]);
        }
    }
}