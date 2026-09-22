using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class ManufacturerDTO
    {
        [MaxLength(30)]
        public string Name { get; set; }
        public int Founded { get; set; }
        [MaxLength(30)]
        public string Nationality { get; set; }
        public int Subsidiary { get; set; }
    }
}
