using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Tool
    {
        [Key]
        public int Id { get; set; }
        public int Serial {  get; set; }
        [MaxLength(30)]
        public string Manufacturer { get; set; }
        [MaxLength(30)]
        public string Type { get; set; }
        public int Price { get; set; }
        [MaxLength(30)]
        public string Source { get; set; }
        public int RentPrice { get; set; }
    }
}
