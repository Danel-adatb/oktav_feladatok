namespace Jaratok
{
    internal class Jarat
    {
        public int Sorszam { get; set; }
        public string Legitarsasag { get; set; }
        public string Celallomas { get; set; }
        public int Ar { get; set; }
        public int Tavolsag { get; set; }
        public int Ules { get; set; }

        public Jarat(string sor)
        {
            string[] darabol = sor.Split(',');

            Sorszam = int.Parse(darabol[0]);
            Legitarsasag = darabol[1];
            Celallomas = darabol[2];
            Ar = int.Parse(darabol[3]);
            Tavolsag = int.Parse(darabol[4]);
            Ules = int.Parse(darabol[5]);
        }

        public bool olcso()
        {
            return Ar <= Tavolsag * 40;
        }
    }
}
