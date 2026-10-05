namespace Filmek
{
    internal class Film
    {
        public int Sorszam { get; set; }
        public string Studio { get; set; }
        public string Mufaj { get; set; }
        public int Koltseg { get; set; }
        public int Bevetel { get; set; }
        public int Hossz { get; set; }

        public Film(string sor)
        {
            string[] darabol = sor.Split(',');

            Sorszam = int.Parse(darabol[0]);
            Studio = darabol[1];
            Mufaj = darabol[2];
            Koltseg = int.Parse(darabol[3]);
            Bevetel = int.Parse(darabol[4]);
            Hossz = int.Parse(darabol[5]);
        }

        public bool nyereseges()
        {
            return Bevetel > Koltseg * 1.2;
        }
    }
}
