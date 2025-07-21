using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaApi.Models;

namespace BibliotecaApi.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
        Task<Author> AddAsync(Author author);
        Task<Author> UpdateAsync(Author author);
        Task<bool> DeleteAsync(int id);
    }
}