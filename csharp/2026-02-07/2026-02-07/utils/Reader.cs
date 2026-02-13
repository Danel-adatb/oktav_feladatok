namespace _2026_02_07.utils;

public class Reader
{
    private static readonly string SourcePath = @"C:\GitHubPersonal\oktav_feladatok\csharp\2026-02-07\2026-02-07\sources";
    
    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (int.TryParse(input?.Trim(), out var value))
                return value;

            Console.WriteLine("Invalid integer. Try again.");
        }
    }
    
    public static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (double.TryParse(input?.Trim(), out var value))
                return value;

            Console.WriteLine("Invalid double. Try again.");
        }
    }
    
    public static double ReadPositiveDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (double.TryParse(input?.Trim(), out var value) && value > 0)
                return value;

            Console.WriteLine("Invalid double. Try again.");
        }
    }

    public static int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (int.TryParse(input?.Trim(), out var value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Invalid integer. Try again.");
        }
    }

    public static string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();
            
            Console.WriteLine("Please enter a string value. Try again.");
        }
    }

    public static string[] ReadFile(string file)
    {
        var filePath = Path.Combine(SourcePath, file);
        return File.ReadAllLines(filePath);
    }
}