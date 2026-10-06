using System.ComponentModel.DataAnnotations;

namespace filmek.Models
{
    public class Studiok
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Studio { get; set; }
        public int Alapitva { get; set; }
        [MaxLength(30)]
        public string Orszag { get; set; }
        public int Dolgozok { get; set; }

        public Studiok(
            string studio,
            int alapitva,
            string orszag,
            int dolgozok
        ) {
            this.Studio = studio;
            this.Alapitva = alapitva;
            this.Orszag = orszag;
            this.Dolgozok = dolgozok;
        }
    }
}
