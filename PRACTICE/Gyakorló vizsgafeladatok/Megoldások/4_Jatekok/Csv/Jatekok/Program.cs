using System.Text;

namespace Jatekok
{
    internal class Program
    {
        public static List<Jatek> lista = new List<Jatek>();

        public static void Beolvas()
        {
            StreamReader sr = new StreamReader("jatekok.csv", Encoding.UTF8);
            sr.ReadLine(); // fejléc

            while (sr.Peek() > -1)
            {
                lista.Add(new Jatek(sr.ReadLine()!));
            }
            sr.Close();
        }

        public static void Feladat5()
        {
            Console.WriteLine("5. feladat - Hosszú játékok:");
            Console.WriteLine("Legalább hány órás játékidejű játékot keres?");
            int be = int.Parse(Console.ReadLine()!);

            int db = 0;
            foreach (var k in lista)
            {
                if (k.Jatekido >= be)
                {
                    Console.WriteLine($"{k.Kiado}, {k.Mufaj}, {k.Platform}, {k.Jatekido} óra");
                    db++;
                }
            }

            if (db == 0)
            {
                Console.WriteLine("Nincs ilyen hosszú játék!");
            }
        }

        public static int Feladat6()
        {
            int db = 0;
            foreach (var k in lista)
            {
                if (!k.megeri())
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
            Console.WriteLine($"4. feladat - Játékok száma a fájlban: {lista.Count}");
            Feladat5();
            Console.WriteLine($"6. feladat - Nem éri meg megvenni\n{Feladat6()} darab játékot nem éri meg megvenni!");
        }
    }
}
