namespace Konyvek
{
    internal class Konyv
    {
        public int Sorszam { get; set; }
        public string Kiado { get; set; }
        public string Mufaj { get; set; }
        public int Oldalszam { get; set; }
        public int Ar { get; set; }
        public int Keszlet { get; set; }

        public Konyv(string sor)
        {
            string[] darabol = sor.Split(',');

            Sorszam = int.Parse(darabol[0]);
            Kiado = darabol[1];
            Mufaj = darabol[2];
            Oldalszam = int.Parse(darabol[3]);
            Ar = int.Parse(darabol[4]);
            Keszlet = int.Parse(darabol[5]);
        }

        public bool megeri_megvenni()
        {
            return Ar <= Oldalszam * 14.0;
        }
    }
}
