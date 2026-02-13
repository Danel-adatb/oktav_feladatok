using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok05;

public class Task57
{
    public static void Run()
    {
        string sentence = Reader.ReadString("Please give your sentence: ");

        string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            string w = words[i];

            // első karakter nagybetű + maradék változatlan
            words[i] = char.ToUpper(w[0]) + w.Substring(1);
            Console.WriteLine(words[i]);
        }
    }
}