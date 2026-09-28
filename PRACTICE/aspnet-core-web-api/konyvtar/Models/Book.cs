using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace konyvtar.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "text")]
        public string Title { get; set; }
        [Column(TypeName = "text")]
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        [AllowedValues(0, 1)]
        public int Available { get; set; }

        public override string ToString()
        {
            string availability = this.Available == 0 ? "Non available" : "Available";

            return $"Id: {this.Id}\n" +
                $"Title: {this.Title}\n" +
                $"Author: {this.Author}\n" +
                $"Publication Year: {this.PublicationYear}\n" +
                $"Available: {availability}";
        }
    }
}
