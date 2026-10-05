using System.Text;

namespace Konyvek
{
    internal class Program
    {
        public static List<Konyv> lista = new List<Konyv>();

        public static void Beolvas()
        {
            StreamReader sr = new StreamReader("konyvek.csv", Encoding.UTF8);
            sr.ReadLine(); // fejléc

            while (sr.Peek() > -1)
            {
                lista.Add(new Konyv(sr.ReadLine()!));
            }
            sr.Close();
        }

        public static void Feladat5()
        {
            Console.WriteLine("5. feladat - Rövid könyvek:");
            Console.WriteLine("Hány oldalnál rövidebb könyvet keres?");
            int be = int.Parse(Console.ReadLine()!);

            int db = 0;
            foreach (var k in lista)
            {
                if (k.Oldalszam < be)
                {
                    Console.WriteLine($"{k.Kiado}, {k.Mufaj}, {k.Oldalszam} oldal, {k.Ar}");
                    db++;
                }
            }

            if (db == 0)
            {
                Console.WriteLine("Nincs ilyen rövid könyv!");
            }
        }

        public static int Feladat6()
        {
            int db = 0;
            foreach (var k in lista)
            {
                if (!k.megeri_megvenni())
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
            Console.WriteLine($"4. feladat - Könyvek száma a fájlban: {lista.Count}");
            Feladat5();
            Console.WriteLine($"6. feladat - Nem éri meg megvenni\n{Feladat6()} darab könyvet nem éri meg megvenni!");
        }
    }
}
