using System.ComponentModel.DataAnnotations;

namespace kereparok.Models
{
    public class Marka
    {
        [Key]
        public string Id { get; set; }
        [MaxLength(30)]
        public string Gyarto { get; set; }
        public int Alapitva { get; set; }
        [MaxLength(30)]
        public string Nemzetiseg {  get; set; }
        public int Uzemek { get; set; }

        public Marka(
            string gyarto,
            int alapitva,
            string nemzetiseg,
            int uzemek
        ) { 
            this.Gyarto = gyarto;
            this.Alapitva = alapitva;
            this.Nemzetiseg = nemzetiseg;
            this.Uzemek = uzemek;
        }
    }
}
