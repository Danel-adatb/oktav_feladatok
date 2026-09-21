using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public int Founded { get; set; }
        [MaxLength(30)]
        public string Nationality { get; set; }
        public int subsidiary { get; set; }
    }
}
