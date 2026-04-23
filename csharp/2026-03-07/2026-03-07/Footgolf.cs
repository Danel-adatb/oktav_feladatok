namespace _2026_03_07;

public class Footgolf
{
    public static readonly string SourcePath = @"C:\GitHubPersonal\oktav_feladatok\csharp\2026-03-07\2026-03-07\sources";
    
    //Feladat 2.
    public static List<DataRowFootgolf> ReadDataFromFile(string fileName)
    {
        var result = new List<DataRowFootgolf>();
        
        var filePath = Path.Combine(SourcePath, fileName);
        foreach (var line in File.ReadAllLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<int> pointsList = new List<int>();
            pointsList.AddRange(int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]));
            
            result.Add(new DataRowFootgolf
            {
                Name  = parts[0],
                Category = parts[1],
                Club  = parts[2],
                Points = pointsList
            });
        }

        return result;
    }
    
    //Feladat 3.
    public static void CountNamesByCategory(List<DataRowFootgolf> rows)
    {
        var racersByCategory = rows
            .GroupBy(x => x.Category)
            .Sum(x => x.Count());
        
        Console.WriteLine($"Versenyzők száma: {racersByCategory}");
    }

    //Feladat 4.
    public static void WomenRatio(List<DataRowFootgolf> rows)
    {
        int womenCount = rows.Where(x => x.Category == "Noi").Count();
        int all = rows.Count();
        double ratio =  (double)womenCount / (double)all;
        
        Console.WriteLine($"ASD: {all}");
        Console.WriteLine($"A női versenyzők száma: {ratio:P2}");
    }
    
    //Feladat 5.  
}