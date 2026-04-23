namespace _2026_03_07;

public class Helsinki
{
    public static readonly string SourcePath = @"C:\GitHubPersonal\oktav_feladatok\csharp\2026-03-07\2026-03-07\sources";
    
    private static readonly Dictionary<int, int> PointMap = new  Dictionary<int, int> {
        { 1, 7 },
        { 2, 5 },
        { 3, 4 },
        { 4, 3 },
        { 5, 2 },
        { 6, 1 }
    };
    
    //Feladat 2.
    public static List<DataRowHelsinki> ReadDataFromFile(string fileName)
    {
        var result = new List<DataRowHelsinki>();

        var filePath = Path.Combine(SourcePath, fileName);
        foreach (var line in File.ReadAllLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 4)
                continue; // skip malformed lines

            result.Add(new DataRowHelsinki
            {
                Placement  = int.Parse(parts[0]),
                RacerCount = int.Parse(parts[1]),
                SportName  = parts[2],
                RaceName = parts[3]
            });
        }

        return result;
    }

    //Feladat 3.
    public static int CountPlacements(List<DataRowHelsinki> rows)
    {
        return rows.Count();
    }
        
    //Feladat 4.
    public static void MedalStatistics(List<DataRowHelsinki> rows)
    {
        var medals = rows
            .Where(x => x.Placement >= 1 && x.Placement <= 3)
            .GroupBy(x => x.Placement)
            .ToDictionary(g => g.Key, g => g.Count());

        var firstPlace = medals.GetValueOrDefault(1, 0);
        var secondPlace = medals.GetValueOrDefault(2, 0);
        var thirdPlace = medals.GetValueOrDefault(3, 0);

        Console.WriteLine($"Arany: {firstPlace}");
        Console.WriteLine($"Ezüst: {secondPlace}");
        Console.WriteLine($"Bronz: {thirdPlace}");
        Console.WriteLine($"Összesen: {firstPlace + secondPlace + thirdPlace}");
    }
    
    //Feladat 5.
    public static void PointStatistics(List<DataRowHelsinki> rows)
    {
        int totalPoints = rows
            .Where(x => PointMap.ContainsKey(x.Placement))
            .Sum(x => PointMap[x.Placement]);

        Console.WriteLine($"Olimpiai pontok száma: {totalPoints}");
    }
    
    //Feladat 6.
    public static void WhichSportIsBest(List<DataRowHelsinki> rows)
    {
        int uszas = rows.Count(x => x.Placement <= 3 && x.SportName == "uszas");
        int torna  = rows.Count(x => x.Placement <= 3 && x.SportName == "torna");

        if (uszas > torna)
            Console.WriteLine($"Az úszásban szereztek több érmet ({uszas}).");
        else if (torna > uszas)
            Console.WriteLine($"A tornában szereztek több érmet ({torna}).");
        else
            Console.WriteLine("Egyenlő volt az érmek száma.");
    }
    
    //Feladat 7.
    public static void WriteModifiedFile(string outputFile)
    {
        var filePath = Path.Combine(SourcePath, "helsinki.txt");
        var lines = File.ReadLines(filePath)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line =>
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int placement  = int.Parse(parts[0]);
                int racerCount = int.Parse(parts[1]);
                string sportName = parts[2].Replace("kajakkenu", "kajak-kenu");
                string raceName  = parts[3].Replace("kajakkenu", "kajak-kenu");

                int points = PointMap.GetValueOrDefault(placement, 0);

                return $"{placement} {racerCount} {points} {sportName} {raceName}";
            });

        foreach (var line in lines)
        {
            Console.WriteLine($"{line}");
        }
        
        File.WriteAllLines(outputFile, lines);
    }
    
    //Feladat 8.
    public static void MostRacers(List<DataRowHelsinki> rows)
    {
        var max = rows.Max(x => x.RacerCount);
        var biggest = rows.Where(x => x.RacerCount == max).ToList();
        
        Console.WriteLine($"Helyezés: {biggest[0].Placement}");
        Console.WriteLine($"Sportág: {biggest[0].SportName}");
        Console.WriteLine($"Versenyszám: {biggest[0].RaceName}");
        Console.WriteLine($"Sportolók száma: {biggest[0].RacerCount}");
        
    }
}