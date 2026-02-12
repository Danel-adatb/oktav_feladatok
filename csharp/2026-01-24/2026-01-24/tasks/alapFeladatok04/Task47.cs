using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok04;

public class Task47
{
    public static void Run()
    {
        int count = Reader.ReadPositiveInt("Please give the count: ");
        string[] array = new string[count];

        for (int i = 0; i < count; i++)
        {
            string value = Reader.ReadString($"Please give the {i + 1}. name: ");
            array[i] = value;
        }
        
        string nameToFind = Reader.ReadString("Please give the name to find: ");

        int times = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i].ToLower() == nameToFind.ToLower()) times++;
        
        Console.WriteLine($"The name '{nameToFind}' was found {times}x times!");
    }
}