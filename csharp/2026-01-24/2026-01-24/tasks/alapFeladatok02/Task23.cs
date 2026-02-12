using _2026_01_24.utils;

namespace _2026_01_24.tasks.alapFeladatok02;

public class Task23
{
    public static void Run()
    {
        int originalNumber = Reader.ReadInt("Please give a number: ");
        var array = new List<int>();
        int temp = originalNumber;

        while (temp % 2 == 0)
        {
            array.Add(2);
            temp /= 2;
        }

        if (array.Count == 0)
        {
            Console.WriteLine(originalNumber+" = "+temp);
        }
        else
        {
            Console.WriteLine(originalNumber+" = "+string.Join("*", array)+"*"+temp);
        }
        
    }
}