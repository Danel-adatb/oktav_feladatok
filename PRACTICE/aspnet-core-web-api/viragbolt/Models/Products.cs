using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace viragbolt.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
        public string description { get; set; }
        public int stock { get; set; }
        public int price { get; set; }
        public string imgUrl { get; set; }
        [ForeignKey(nameof(Categories))]
        public int categoryId { get; set; }
    }
}
