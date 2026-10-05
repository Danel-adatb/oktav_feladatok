using System.ComponentModel.DataAnnotations;

namespace kereparok.Models
{
    public class KerekparDTO
    {
        [MaxLength(255)]
        public string Gyarto { get; set; }
        [MaxLength(255)]
        public string Tipusa { get; set; }
        public int Ar { get; set; }
        [MaxLength(255)]
        public string Hajtas { get; set; }
        public int Berles { get; set; }

        public KerekparDTO(
            string gyarto,
            string tipus,
            int ar,
            string hajtas,
            int berles
        )
        {
            this.Gyarto = gyarto;
            this.Tipusa = tipus;
            this.Ar = ar;
            this.Hajtas = hajtas;
            this.Berles = berles;
        }
    }
}
