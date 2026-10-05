using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace kereparok.Models
{
    public class Kerekpar
    {
        [Key]
        public int Sorszam { get; set; }
        [MaxLength(255)]
        public string Gyarto { get; set; }
        [MaxLength(255)]
        public string Tipus { get; set; }
        public int Ar { get; set; }
        [MaxLength(255)]
        public string Hajtas { get; set; }
        public int Berles { get; set; }

        public Kerekpar(
            string gyarto,
            string tipus,
            int ar,
            string hajtas,
            int berles
        ) {
            this.Gyarto = gyarto;
            this.Tipus = tipus;
            this.Ar = ar;
            this.Hajtas = hajtas;
            this.Berles = berles;
        }
    }
}
