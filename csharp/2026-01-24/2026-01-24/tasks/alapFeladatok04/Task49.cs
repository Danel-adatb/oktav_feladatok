using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok04;

public class Task49
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

        //array.Sort(); ?? :D
        for (int i = array.Length; i > 0; i--)
            for (int j = 0; j < i-1; j++)
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
        
        Console.Write("Bubble Sort: ");
        Console.WriteLine(string.Join(", ", array));
    }
}