using System.ComponentModel.DataAnnotations;

namespace viragbolt.Models.DTO
{
    public class CategoryDTO
    {
        [MaxLength(100)]
        public string name { get; set; }
    }
}
