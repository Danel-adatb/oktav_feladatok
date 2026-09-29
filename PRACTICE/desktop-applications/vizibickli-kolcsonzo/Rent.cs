using System;
using System.Collections.Generic;
using System.Text;

namespace vizibickli_kolcsonzo
{
    public class Rent
    {
        private const string Path = "C:\\GitHubPersonal\\oktav_feladatok\\PRACTICE\\desktop-applications\\vizibickli-kolcsonzo\\kolcsonzesek.txt";

        public string Name { get; set; }
        public string Category { get; set; }
        public int THour { get; set; }
        public int TMinute { get; set; }
        public int BHour { get; set; }
        public int BMinute { get; set; }

        public Rent(
            string name,
            string category,
            int tHour,
            int tMinute,
            int bHour,
            int bMinute
        )
        {
            this.Name = name;
            this.Category = category;
            this.THour = tHour;
            this.TMinute = tMinute;
            this.BHour = bHour;
            this.BMinute = bMinute;
        }

        public override string ToString()
        {
            return $"Név: {this.Name}\n" +
                $"Jármű azonosítója: {this.Category}\n" +
                $"Elvitel óra: {this.THour}\n" +
                $"Elvitel perc: {this.TMinute}\n" +
                $"Visszahozatal órája: {this.BHour}\n" +
                $"Visszahozatal perce: {this.BMinute}\n" +
                $"-----------------------------------\n";
        }

        public static List<Rent> readDatas()
        {
            using (var reader = new StreamReader(Path))
            {
                List<Rent> rents = new List<Rent>();
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var row = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(row)) continue;
                    
                    string[] parts = row.Split(";");
                    rents.Add(new Rent(parts[0], parts[1], Int32.Parse(parts[2]), Int32.Parse(parts[3]), Int32.Parse(parts[4]), Int32.Parse(parts[5])));
                }

                return rents;
            }
        }
    }
}