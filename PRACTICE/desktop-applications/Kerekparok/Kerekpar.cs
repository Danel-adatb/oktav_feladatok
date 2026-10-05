using System;
using System.Collections.Generic;
using System.Text;

namespace Kerekparok
{
    public class Kerekpar
    {

        public int Sorszam {  get; set; }
        public string Gyarto { get; set; }
        public string Tipusa { get; set; }
        public int Ar {  get; set; }
        public string Hajtas { get; set; }
        public int BerlesiDij {  get; set; }

        public Kerekpar(string row)
        {
            string[] parts = row.Split(',');

            this.Sorszam = int.Parse(parts[0]);
            this.Gyarto = parts[1];
            this.Tipusa = parts[2];
            this.Ar = int.Parse(parts[3]);
            this.Hajtas = parts[4];
            this.BerlesiDij = int.Parse(parts[5]);
        }

        public static bool WorthToRent(Kerekpar bicycle)
        {
            double deadline = bicycle.Ar * 0.02;
            if ((double)bicycle.BerlesiDij > deadline) return false; else return true;
        }
    }
}
