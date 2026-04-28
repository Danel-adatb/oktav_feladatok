namespace _2026_03_08;

﻿class Orszag
{
    public static readonly string SourcePath = @"C:\GitHubPersonal\oktav_feladatok\csharp\2026-03-08\2026-03-08\resources";
    
    public string Orszagnev { get; private set; }
    public int Terulet { get; private set; }
    public int Nepesseg { get; private set; }
    public string Fovaros { get; private set; }
    public int FovarosNepesseg { get; private set; }
    public bool? IsCenterPopulated { get; private set; }

    public Orszag(string orszagnev, int terulet, int nepesseg, string fovaros, int fovarosNepesseg, bool? isCenterPopulated)
    {
        Orszagnev = orszagnev;
        Terulet = terulet;
        Nepesseg = nepesseg;
        Fovaros = fovaros;
        FovarosNepesseg = fovarosNepesseg;
        IsCenterPopulated = isCenterPopulated;
    }

    public override string ToString()
    {
        return $"Országnév: {this.Orszagnev} - Terület: {this.Terulet} - Népesség: {this.Nepesseg} - Főváros: {this.Fovaros} - Főváros Népesség: {this.FovarosNepesseg} - Főváros arány: {this.IsCenterPopulated}";
    }

    private static bool isCenterPopulated(int nepesseg, int fovarosNepesseg)
    {
        double percent = (double)(fovarosNepesseg * 100) / (double)nepesseg*1000;
        return percent > 30.0;
    }
    
    public static List<Orszag> ReadDataFromFile(string fileName)
    {
        var result = new List<Orszag>();
        
        var filePath = Path.Combine(SourcePath, fileName);
        foreach (var line in File.ReadAllLines(filePath).Skip(1))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
            
            int nepesseg = 0;
            if (parts[2].Contains("g"))
            {
                string[] charsToRemove = { "g" };
                string temp = "";
                foreach (var c in charsToRemove)
                {
                    temp = parts[2].Replace(c, string.Empty);
                }

                nepesseg = int.Parse(temp) * 10000;
            }
            else
            {
                nepesseg = int.Parse(parts[2]);
            }

            var orszag = new Orszag(
                parts[0],
                int.Parse(parts[1]),
                nepesseg,
                parts[3],
                int.Parse(parts[4]),
                isCenterPopulated(nepesseg,  int.Parse(parts[4]))
            );
            
            result.Add(orszag);
        }

        return result;
    }
    
    

    public static void SecondTask(List<Orszag> countries)
    {
        foreach (var country in countries)
        {
            Console.WriteLine(country);
        }
    }

    public static void ThirdTask(List<Orszag> countries)
    {
        var total = countries.Count();
            
        Console.WriteLine($"A beolvasott országok száma: {total}");
    }

    public static void ForthTask(List<Orszag> countries)
    {
        //Népsűrűség = Össznépesség / Összterület
        var china = countries.Find(c => c.Orszagnev == "Kína");
        if (china != null)
        {
            double result = (double)china.Nepesseg / (double)china.Terulet;
            Console.WriteLine($"Kína népsűrűsége: {result:F2} fő/km^2");
        }
        else
        {
            Console.WriteLine("Nem található Kína nevezetű város!");
        }
    }

    public static void FifthTask(List<Orszag> countries)
    {
        var china = countries.Find(c => c.Orszagnev == "Kína");
        var india = countries.Find(c => c.Orszagnev == "India");
        var populationDifference = china.Nepesseg - india.Nepesseg;
        Console.WriteLine($"Kínában a lakosság {Math.Abs(populationDifference)} fővel volt több.");
    }

    public static void SixthTask(List<Orszag> countries)
    {
        var thirdMostPop = countries.OrderByDescending(c => c.Nepesseg).ToList();
        Console.WriteLine($"A harmadik legnépesebb ország: {thirdMostPop[2].Orszagnev}, a lakosság {thirdMostPop[2].Nepesseg} fő.");
    }

    public static void SeventhTask(List<Orszag> countries)
    {
        Console.WriteLine("A következő országok lakosságának több mint 30%-a a fővárosban lakik:");
        foreach (var country in countries)
        {
            if(country.IsCenterPopulated == true) Console.WriteLine($"{country.Orszagnev} ({country.Fovaros})");
        }
    }
}