using System;
using System.Collections.Generic;
using System.Text;

namespace autoapp
{
    internal class Auto
    {
        private const string Path = "C:/GitHubPersonal/oktav_feladatok/PRACTICE/desktop-applications/autoapp/autok.csv";

        public int Id {  get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int SoldCount { get; set; }
        public int AvgSoldPrice { get; set; }

        public Auto(string row)
        {
            string[] data = row.Split([';'], StringSplitOptions.RemoveEmptyEntries);

            this.Id = Int32.Parse(data[0]);
            this.Brand = data[1];
            this.Model = data[2];
            this.Year= Int32.Parse(data[3]);
            this.Color = data[4];
            this.SoldCount = Int32.Parse(data[5]);
            this.AvgSoldPrice = Int32.Parse(data[6]);
        }

        public override string ToString()
        {
            return $"Sorszám: {this.Id}\n" +
                $"Márka: {this.Brand}\n" +
                $"Modell: {this.Model}\n" +
                $"Évjárat: {this.Year}\n" +
                $"Szín: {this.Color}\n" +
                $"Eladott DB: {this.SoldCount}\n" +
                $"Átlag eladási ár: {this.AvgSoldPrice}\n" +
                $"-----------------";
        }

        public static List<Auto> readData()
        {
            using (var reader = new StreamReader(Path))
            {
                List<Auto> cars = new List<Auto>();
                reader.ReadLine();

                while (!reader.EndOfStream) 
                { 
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    cars.Add(new Auto(line));
                }

                return cars;
            }
        }
    }
    }
