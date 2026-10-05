namespace Jatekok
{
    internal class Jatek
    {
        public int Sorszam { get; set; }
        public string Kiado { get; set; }
        public string Mufaj { get; set; }
        public int Ar { get; set; }
        public string Platform { get; set; }
        public int Jatekido { get; set; }

        public Jatek(string sor)
        {
            string[] darabol = sor.Split(',');

            Sorszam = int.Parse(darabol[0]);
            Kiado = darabol[1];
            Mufaj = darabol[2];
            Ar = int.Parse(darabol[3]);
            Platform = darabol[4];
            Jatekido = int.Parse(darabol[5]);
        }

        public bool megeri()
        {
            return Ar <= Jatekido * 500;
        }
    }
}
