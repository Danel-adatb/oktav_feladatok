using System.Text;

namespace Filmek
{
    internal class Program
    {
        public static List<Film> lista = new List<Film>();

        public static void Beolvas()
        {
            StreamReader sr = new StreamReader("filmek.csv", Encoding.UTF8);
            sr.ReadLine(); // fejléc

            while (sr.Peek() > -1)
            {
                lista.Add(new Film(sr.ReadLine()!));
            }
            sr.Close();
        }

        public static void Feladat5()
        {
            Console.WriteLine("5. feladat - Hosszú filmek:");
            Console.WriteLine("Hány percnél hosszabb filmet keres?");
            int be = int.Parse(Console.ReadLine()!);

            int db = 0;
            foreach (var k in lista)
            {
                if (k.Hossz > be)
                {
                    Console.WriteLine($"{k.Studio}, {k.Mufaj}, {k.Hossz} perc, {k.Bevetel}");
                    db++;
                }
            }

            if (db == 0)
            {
                Console.WriteLine("Nincs ilyen hosszú film!");
            }
        }

        public static int Feladat6()
        {
            int db = 0;
            foreach (var k in lista)
            {
                if (!k.nyereseges())
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
            Console.WriteLine($"4. feladat - Filmek száma a fájlban: {lista.Count}");
            Feladat5();
            Console.WriteLine($"6. feladat - Nem nyereséges filmek\n{Feladat6()} darab film nem nyereséges!");
        }
    }
}
