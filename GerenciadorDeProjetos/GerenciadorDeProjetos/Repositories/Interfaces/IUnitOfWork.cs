namespace GerenciadorDeProjetos.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoriaRepository CategoriaRepository { get; }

        IProdutoRepository ProdutoRepository { get; }

        Task<int> CommitAsync();


    }
}
