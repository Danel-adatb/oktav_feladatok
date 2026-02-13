using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok05;

public class Task55
{
    public static void Run()
    {
        string sentence = Reader.ReadString("Please give your sentence: ");

        string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}