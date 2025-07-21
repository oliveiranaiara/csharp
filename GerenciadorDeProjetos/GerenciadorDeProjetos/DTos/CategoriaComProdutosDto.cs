namespace GerenciadorDeProjetos.DTOs
{
    // DTO para exibir uma categoria com sua lista de produtos.
    // ESTA É A CLASSE QUE RESOLVE O PROBLEMA!
    public class CategoriaComProdutosDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        // ENTRA
        // Adicionamos o campo que queremos expor na nossa API.
        public int QuantidadeDeProdutos { get; set; }

        // A lista não é de "Produto", e sim de "ProdutoDto".
        // Como "ProdutoDto" não tem uma referência de volta para Categoria, o ciclo é quebrado.
        public ICollection<ProdutoDto>? Produtos { get; set; }
    }

}
