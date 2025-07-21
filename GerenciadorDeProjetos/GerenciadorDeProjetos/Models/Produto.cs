using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeProjetos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        // Chave estrangeira para a Categoria
        public int CategoriaId { get; set; }

        // Propriedade de navegação: Um produto pertence a uma categoria.
        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }
    }

}
