namespace Kerekparok
{
    internal class Kerekpar
    {
        public int Sorszam { get; set; }
        public string Gyarto { get; set; }
        public string Tipus { get; set; }
        public int Ar { get; set; }
        public string Hajtas { get; set; }
        public int BerlesiDij { get; set; }

        public Kerekpar(string sor)
        {
            string[] darabol = sor.Split(',');

            Sorszam = int.Parse(darabol[0]);
            Gyarto = darabol[1];
            Tipus = darabol[2];
            Ar = int.Parse(darabol[3]);
            Hajtas = darabol[4];
            BerlesiDij = int.Parse(darabol[5]);
        }

        public bool megeri_berelni()
        {
            return BerlesiDij <= Ar * 0.02;
        }
    }
}
