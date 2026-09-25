using System.ComponentModel.DataAnnotations;

namespace viragbolt.Models
{
    public class Categories
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
    }
}
