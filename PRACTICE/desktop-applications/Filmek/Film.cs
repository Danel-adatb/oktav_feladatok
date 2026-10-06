namespace Filmek
{
    internal class Film
    {
        public int Sorszam {  get; set; }
        public string Studio { get; set; }
        public string Mufaj { get; set; }
        public int Koltsegvetes { get; set; }
        public int Bevetel { get; set; }
        public int Hossz {  get; set; }

        public Film(string row)
        {
            var parts = row.Split(",");

            this.Sorszam = int.Parse(parts[0]);
            this.Studio = parts[1];
            this.Mufaj = parts[2];
            this.Koltsegvetes = int.Parse(parts[3]);
            this.Bevetel = int.Parse(parts[4]);
            this.Hossz = int.Parse(parts[5]);
        }

        public static bool IsBenefical(Film film)
        {
            double value = (double)film.Bevetel / film.Koltsegvetes;
            Console.WriteLine($"DEBUG: {value}");
            if (value < 1.2) return true; else return false;
        }
    }
}
