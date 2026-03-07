using System;
using _2026_03_07.utils;

//Helsinki1952
namespace _2026_03_07
{
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Kérem válasszon a feladatok közül: 1 ~ Helsinki | 2 ~ FootGolf");
            int task = Reader.ReadTask("Adja meg a feladat számát: ");
            switch (task)
            {
                case 1:
                    TaskHelsinki();
                    break;
                case 2:
                    TaskFootGold();
                    break;
            }
        }

        public static void TaskHelsinki()
        {
            var rows = Helsinki.ReadDataFromFile("helsinki.txt");

            Console.WriteLine("2. Feladat");
            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Placement} | {row.RacerCount} | {row.SportName} | {row.RaceName}");
            }
            
            Console.WriteLine("\n3. Feladat");
            Console.WriteLine($"Pontszerző helyezések száma: {Helsinki.CountPlacements(rows)}");
            
            Console.WriteLine("\n4. Feladat");
            Helsinki.MedalStatistics(rows);
            
            Console.WriteLine("\n5. Feladat");
            Helsinki.PointStatistics(rows);
            
            Console.WriteLine("\n6. Feladat");
            Helsinki.WhichSportIsBest(rows);
            
            Console.WriteLine("\n7. Feladat");
            Helsinki.WriteModifiedFile(
                Path.Combine(Helsinki.SourcePath, "helsinki2.txt")
            );
            
            Console.WriteLine("\n8. Feladat");
            Helsinki.MostRacers(rows);
        }

        public static void TaskFootGold()
        {
            Console.WriteLine("Ahoj");
        }
    }
}