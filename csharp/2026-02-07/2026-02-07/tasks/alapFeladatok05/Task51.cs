using _2026_02_07.utils;

namespace _2026_02_07.tasks.alapFeladatok05;

public class Task51
{
    public static void Run()
    {
        string text = Reader.ReadString("Please enter your word: ");
        string forbiddenLetter = Reader.ReadString("Please enter your forbidden letter: ");
        
        for (int i = 0; i < text.Length; i++)
        {
            if (forbiddenLetter.ToLower().Contains(text[i].ToString().ToLower())) continue;
            Console.Write(text[i]);

            if (i < text.Length - 1)
                Console.Write(' ');
        }
    }
}