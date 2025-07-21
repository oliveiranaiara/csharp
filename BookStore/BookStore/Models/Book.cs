using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        public required string Title { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public required Author Author { get; set; }
    }
}
