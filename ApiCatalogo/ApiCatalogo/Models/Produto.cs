using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        public string? Nome { get; set; }

        public string? Descricao { get; set; } = string.Empty;

        public decimal Preco { get; set; }

        public string? ImagemUrl { get; set; }

        public float Estoque { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
