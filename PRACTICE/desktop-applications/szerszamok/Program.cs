using System.Reflection;
using System.Runtime.CompilerServices;
using szerszamok;

namespace Program
{
    class Program
    {
        public const string Path = "C:/GitHubPersonal/oktav_feladatok/PRACTICE/desktop-applications/szerszamok/szerszamok.csv";

        static void Main(string[] args)
        {
            List<Szerszam> tools = new List<Szerszam>();
            // using: garantálja, hogy a fájl akkor is lezárul, ha kivétel keletkezik olvasás közben
            using (var reader = new StreamReader(Path))
            {
                readTools(reader, tools);
            }

            //Feladat 4.
            Console.WriteLine($"4. Feladat - Szerszámok száma a fájlban: {countTools(tools)}");
            
            //Feladat 5.
            Console.WriteLine($"5. Feladat - Drágább szerszámok:");
            List<Szerszam> expensiveTools = moreExpensiveTools(tools);
            if (expensiveTools == null)
            {
                Console.WriteLine("Itt minden szerszám olcsó!");
            }
            else
            {
                foreach (Szerszam tool in expensiveTools)
                {
                    Console.WriteLine(tool.ToString());
                }
            }

            //Feladat 6.
            Console.WriteLine($"6. Feladat - Megérős szerszámok bérlésének darabszáma: {countWorthToRentableTools(tools)}");

        }

        public static List<Szerszam> readTools(StreamReader reader, List<Szerszam> tools)
        {
            // Az első sor a fejléc (sorszám,gyártó,...), ezt ki kell hagyni
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                tools.Add(new Szerszam(line));
            }

            return tools;
        }

        public static int countTools(List<Szerszam> tools)
        {
            return tools.Count;
        }

        public static List<Szerszam>? moreExpensiveTools(List<Szerszam> tools) 
        {
            List<Szerszam> expensive = new List<Szerszam>();

            Console.WriteLine("Mekkora ár felett számít drágának?");
            string priceStr = Console.ReadLine();
            int price = Int32.Parse(priceStr);

            foreach (Szerszam tool in tools)
            {
                if (tool.Price > price)
                {
                    expensive.Add(tool);
                }
            }

            if (expensive.Count > 0)
            {
                return expensive;
            } else
            {
                return null;
            }
        }

        public static int countWorthToRentableTools(List<Szerszam> tools)
        {
            int count = 0;
            foreach(Szerszam tool in tools)
            {
                if (tool.worthToRent()) count++;
            }

            return count;
        }
    }
}