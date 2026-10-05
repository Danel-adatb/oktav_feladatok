using System.Text;

namespace Jaratok
{
    internal class Program
    {
        public static List<Jarat> lista = new List<Jarat>();

        public static void Beolvas()
        {
            StreamReader sr = new StreamReader("jaratok.csv", Encoding.UTF8);
            sr.ReadLine(); // fejléc

            while (sr.Peek() > -1)
            {
                lista.Add(new Jarat(sr.ReadLine()!));
            }
            sr.Close();
        }

        public static void Feladat5()
        {
            Console.WriteLine("5. feladat - Járatok a célállomásra:");
            Console.WriteLine("Melyik célállomásra keres járatot?");
            string be = Console.ReadLine()!;

            int db = 0;
            foreach (var k in lista)
            {
                if (k.Celallomas.Equals(be, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{k.Legitarsasag}, {k.Ar}, {k.Tavolsag} km");
                    db++;
                }
            }

            if (db == 0)
            {
                Console.WriteLine("Nincs ilyen célállomás!");
            }
        }

        public static int Feladat6()
        {
            int db = 0;
            foreach (var k in lista)
            {
                if (!k.olcso())
                {
                    db++;
                }
            }
            return db;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Beolvas();
            Console.WriteLine($"4. feladat - Járatok száma a fájlban: {lista.Count}");
            Feladat5();
            Console.WriteLine($"6. feladat - Drága járatok\n{Feladat6()} darab járat drága!");
        }
    }
}
