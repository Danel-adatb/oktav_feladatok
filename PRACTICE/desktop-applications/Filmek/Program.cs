using System.Net.NetworkInformation;

namespace Filmek
{
    internal class Program
    {
        private const string Path = "C:\\GitHubPersonal\\oktav_feladatok\\PRACTICE\\Gyakorló vizsgafeladatok\\Források\\2_Filmek\\csv\\filmek.csv";

        static void Main(string[] args)
        {
            List<Film> filmek = new List<Film>();
            ReadData(filmek);

            Console.WriteLine($"4. feladat - Filmek száma a fájlban: {filmek.Count}");
            Console.WriteLine("5. feladat - Hosszú filmek:");
            int length = ReadLength();
            FilterByLength(filmek, length);
            Console.WriteLine("6. feladat - Nem nyereséges filmek");
            IsBenefical(filmek);
        }

        public static List<Film> ReadData(List<Film> filmek) { 
            using(var reader = new StreamReader(Path))
            {
                reader.ReadLine();

                while(!reader.EndOfStream)
                {
                    var row = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(row)) continue;
                    filmek.Add(new Film(row));
                }


                return filmek;
            }
        }

        public static int ReadLength()
        {
            Console.WriteLine("Hány percnél hosszabb filmet keres?");
            var raw = Console.ReadLine();
            if(int.TryParse(raw, out int number)) return number; else return 0;
        }

        public static void FilterByLength(List<Film> filmek, int length)
        {
            List<Film> filtered = filmek.Where(f => f.Hossz > length).ToList();
            if(filtered.Count == 0) Console.WriteLine("Nincs ilyen hosszú film!");
            foreach (Film f in filtered) Console.WriteLine($"{f.Studio}, {f.Mufaj}, {f.Hossz}perc, {f.Bevetel}");
        }

        public static void IsBenefical(List<Film> filmek)
        {
            int count = 0;
            foreach (Film f in filmek) if (!Film.IsBenefical(f)) count++;
            Console.WriteLine($"{count} darab film nem nyereséges!");
        }
    }
}
