using GerenciadorDeProjetos.Models;

namespace GerenciadorDeProjetos.Repositories.Interfaces
{
    // Contrato para o repositório de Categoria
    public interface ICategoriaRepository
    {
        // Define um método para buscar uma categoria pelo ID, incluindo seus produtos
        Task<Categoria> GetByIdWithProductsAsync(int id);

        // Define um método para buscar uma categoria pelo ID (sem produtos)
        Task<Categoria?> FindByIdAsync(int id);

        // Define um método para adicionar uma nova categoria
        Task AddAsync(Categoria categoria);
    }

}
