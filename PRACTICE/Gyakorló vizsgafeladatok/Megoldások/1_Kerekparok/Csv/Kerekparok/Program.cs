using System.Text;

namespace Kerekparok
{
    internal class Program
    {
        public static List<Kerekpar> lista = new List<Kerekpar>();

        public static void Beolvas()
        {
            StreamReader sr = new StreamReader("kerekparok.csv", Encoding.UTF8);
            sr.ReadLine(); // fejléc

            while (sr.Peek() > -1)
            {
                lista.Add(new Kerekpar(sr.ReadLine()!));
            }
            sr.Close();
        }

        public static void Feladat5()
        {
            Console.WriteLine("5. feladat - Olcsóbb kerékpárok:");
            Console.WriteLine("Mekkora ár alatt számít olcsónak?");
            int ar = int.Parse(Console.ReadLine()!);

            int db = 0;
            foreach (var k in lista)
            {
                if (k.Ar < ar)
                {
                    Console.WriteLine($"{k.Gyarto}, {k.Tipus}, {k.Hajtas}, {k.Ar}");
                    db++;
                }
            }

            if (db == 0)
            {
                Console.WriteLine("Itt minden kerékpár drága!");
            }
        }

        public static int Feladat6()
        {
            int db = 0;
            foreach (var k in lista)
            {
                if (!k.megeri_berelni())
                {
                    db++;
                }
            }
            return db;
        }

        static void Main(string[] args)
        {
            Beolvas();
            Console.WriteLine($"4. feladat - Kerékpárok száma a fájlban: {lista.Count}");
            Feladat5();
            Console.WriteLine($"6. feladat - Nem éri meg bérelni\n{Feladat6()} darab kerékpárt nem éri meg bérelni!");
        }
    }
}
