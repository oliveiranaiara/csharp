using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        public string? Name { get; set; }

        // Relacionamento 1-N
        public required ICollection<Book?> Books { get; set; }
        public object Id { get; internal set; }
    }
}