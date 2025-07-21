using GerenciadorDeProjetos.Models;

namespace GerenciadorDeProjetos.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task AddAsync(Produto produto);
        Task AddSync(Produto produto);
    }
}
