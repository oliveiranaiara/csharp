namespace GerenciadorDeProjetos.Models
{
 

    public class Categoria
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        //Entra 
        //Novo escopo para demonstrar a transação 
        public int QuantidadeProdutos { get; set; }

        // Propriedade de navegação: Uma categoria pode ter vários produtos.
        // É ESSENCIAL para o EF Core entender a relação.
        // ATENÇÃO: Essa linha será a causa do nosso futuro erro de serialização.
        public ICollection<Produto>? Produtos { get; set; }
        public int QuantidadeDeProdutos { get; internal set; }
    }

}
