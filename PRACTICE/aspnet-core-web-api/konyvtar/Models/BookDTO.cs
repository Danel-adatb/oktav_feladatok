using System.ComponentModel.DataAnnotations;

namespace konyvtar.Models
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        [AllowedValues(0, 1)]
        public int Available { get; set; }
    }
}
