using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok05;

public class Task53
{
    public static void Run()
    {
        string text = Reader.ReadString("Please give your text: ");

        for (int i = 0; i < text.Length; i++)
        {
            int ascii = (int)text[i];
            Console.WriteLine($"{text[i]}({ascii})");
        }
    }
}