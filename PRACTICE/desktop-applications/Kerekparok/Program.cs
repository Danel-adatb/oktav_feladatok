namespace Kerekparok
{
    public class Program
    {
        public const string Path = "C:\\GitHubPersonal\\oktav_feladatok\\PRACTICE\\Gyakorló vizsgafeladatok\\Források\\1_Kerekparok\\csv\\kerekparok.csv";

        static void Main(string[] args)
        {
            List<Kerekpar> bicycles = new List<Kerekpar>();
            bicycles = ReadData();

            Console.WriteLine($"4. Feladat: Kerekparok száma a fajlban: {bicycles.Count}");
            
            Console.WriteLine($"5. Feladat: Olcsobb kerekparok: ");
            Console.WriteLine("Mekkora ar alatt szamit olcsonak?");
            var readData = Console.ReadLine() ?? null;
            int price = 0;
            try
            {
                if (readData != null) price = int.Parse(readData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba: " + ex.Message);
            }
            List<Kerekpar> cheap = GetCheap(bicycles, price);
            if(cheap.Count() == 0)
            {
                Console.WriteLine("Itt minden kerepar draga!");
            } else
            {
                foreach (Kerekpar k in cheap)
                {
                    Console.WriteLine($"{k.Gyarto}, {k.Tipusa}, {k.Hajtas}, {k.Ar}");
                }
            }

            Console.WriteLine($"6. Feladat: Nem eri meg berelni!");
            int count = 0;
            foreach(Kerekpar k in bicycles)
            {
                if (!Kerekpar.WorthToRent(k)) count++;
            }
            Console.WriteLine($"{count} darab kerekpart nem eri meg berelni!");

        }

        public static List<Kerekpar> ReadData()
        {
            List<Kerekpar> list = new List<Kerekpar>();

            using (var reader = new StreamReader(Path))
            {
                reader.ReadLine();

                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line)) continue;
                    list.Add(new Kerekpar(line));
                }

                return list;
            }
        }

        public static List<Kerekpar> GetCheap(List<Kerekpar> bicycles, int price)
        {
            List<Kerekpar> filtered = bicycles.Where(c => c.Ar < price).ToList();

            return filtered;
        }
    }
}