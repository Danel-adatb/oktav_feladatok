using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok04;

public class Task48_HW
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

        array.Sort();
        int result = array[0] - array[array.Length - 1];
        Console.WriteLine("Sorted array: "+ string.Join(", ", array));
        Console.WriteLine($"Difference: {Math.Abs(result)}");
    }
}