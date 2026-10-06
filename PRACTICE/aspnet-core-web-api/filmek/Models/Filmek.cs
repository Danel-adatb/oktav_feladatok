using System.ComponentModel.DataAnnotations;

namespace filmek.Models
{
    public class Filmek
    {
        [Key]
        public int Sorszam { get; set; }
        [MaxLength(30)]
        public string Studio { get; set; }
        [MaxLength(30)]
        public string Mufaj { get; set; }
        public int Koltseg { get; set; }
        public int Bevetel { get; set; }
        public int Hossz {  get; set; }

        public Filmek(
            string studio,
            string mufaj,
            int koltseg,
            int bevetel,
            int hossz
        ) {
            this.Studio = studio;
            this.Mufaj = mufaj;
            this.Koltseg = koltseg;
            this.Bevetel = bevetel;
            this.Hossz = hossz;
        }

    }
}
