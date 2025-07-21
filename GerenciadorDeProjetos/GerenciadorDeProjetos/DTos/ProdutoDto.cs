namespace GerenciadorDeProjetos.DTOs
{
    // DTO para EXIBIR os dados de um produto.
    // Note que ele não tem a propriedade "Categoria", apenas propriedades simples.
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
    }

}


