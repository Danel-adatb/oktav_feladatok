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
            pointsList.AddRange(int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8]), int.Parse(parts[9]), int.Parse(parts[10]));
            
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
    public static void CalculateScore(List<DataRowFootgolf> rows)
    {
        foreach (DataRowFootgolf row in rows)
        {
            List<int> sorted = row.Points.OrderBy(s => s).ToList();

            List<int> dropped   = sorted.Take(2).ToList();
            List<int> remaining = sorted.Skip(2).ToList();

            int total = remaining.Sum();

            foreach (int score in dropped)
            {
                if (score != 0)
                    total += 10;
            }

            row.TotalPoints = total;
            Console.WriteLine($"Név:  {row.Name} -  {row.Category} - {row.Club} - {row.TotalPoints}");
        }
    }
    
    //Feladat 6.
    public static void WinnerWoman(List<DataRowFootgolf> rows)
    {
        var result = rows.Where(x => x.Category == "Noi").MaxBy(y => y.TotalPoints);
        Console.WriteLine("A bajnok női versenyző:");
        Console.WriteLine($"Név: {result.Name}");
        Console.WriteLine($"Egyesület: {result.Club}");
        Console.WriteLine($"Összpont: {result.TotalPoints}");
    }
    
    //Feladat 7.
    public static void MenStats(List<DataRowFootgolf> rows)
    {
        string outputFile = Path.Combine(SourcePath, "osszpontFF.txt");
        var lines = rows                                      
            .Where(x => x.Category == "Felnott ferfi")
            .OrderByDescending(x => x.TotalPoints)
            .Select(x => $"{x.Name};{x.TotalPoints}");
        
        File.WriteAllLines(outputFile, lines);
    }
    
    //Feladat 8.
    public static void ClubStats(List<DataRowFootgolf> rows)
    {
        var noClubless = rows.Where(x => x.Club != "n.a.").ToList();
        var result = noClubless.GroupBy(x => x.Club).OrderBy(x => x.Key);
        
        foreach (var group in result)
            Console.WriteLine($"{group.Key} - {group.Count()} Fő");
    }
}