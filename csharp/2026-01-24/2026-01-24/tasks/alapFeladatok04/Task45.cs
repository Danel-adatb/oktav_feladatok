using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok04;

public class Task45
{
    public static void Run()
    {
        int count = Reader.ReadPositiveInt("Please give the count: ");
        int[] array = new int[count];

        for (int i = 0; i < count; i++)
        {
            int value = Reader.ReadPositiveInt($"Please give the {i + 1}. array number: ");
            array[i] = value;
        }
        
        int number = Reader.ReadPositiveInt("Please give another number: ");

        array.Sort();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == number)
            {
                Console.WriteLine($"Found the number '{number}' at  index {i}.");
                return;
            }
        }
        
        Console.WriteLine($"There was no such number in the array!");
    }
}