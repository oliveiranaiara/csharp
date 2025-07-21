using ApiCatalogo.Models;

namespace ApiCatalogo.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);

        Task<bool> SaveChangesAsync();

        //Task<Categoria?> GetCategoriaComProdutosAsync(int id);
    }
}