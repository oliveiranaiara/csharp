namespace AmoCSHARP.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }

        public string? NomeProduto { get; set; }

        public string? Descrição { get; set; }

        public decimal Preco { get; set; }

        public int Estoque { get; set; }

        public string? Categoria { get; set; }

    }
}
