namespace _2026_03_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var countries = Orszag.ReadDataFromFile("adatok-utf8.txt");
            Console.WriteLine("2. Feladat");
            Orszag.SecondTask(countries);
            Console.WriteLine("3. Feladat");
            Orszag.ThirdTask(countries);
            Console.WriteLine("4. Feladat");
            Orszag.ForthTask(countries);
            Console.WriteLine("5. Feladat");
            Orszag.FifthTask(countries);
            Console.WriteLine("6. Feladat");
            Orszag.SixthTask(countries);
            Console.WriteLine("7. Feladat");
            Orszag.SeventhTask(countries);
        }
    }
}