
using ApiCatalogo.Data;
using ApiCatalogo.Models;
using ApiCatalogo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatalogoFinal.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public Task<T> AddAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            return Task.FromResult(entity);
        }

        public async Task<bool> DeleteAsync<T>(int id) where T : class
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            _context.Set<T>().Remove(entity);
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task<T> UpdateAsync<T>(T entity) where T : class
        {
            // O método Update do EF não é async, ele apenas muda o estado da entidade.
            // A operação de salvar (SaveChangesAsync) é que é assíncrona.
            _context.Set<T>().Update(entity);
            return Task.FromResult(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Categoria?> GetCategoriaComProdutosAsync(int id)
        {
            return await _context.Categorias
                                 .Include(c => c.Produtos) // Inclui a lista de produtos
                                 .FirstOrDefaultAsync(c => c.CategoriaId == id);
        }

    }
}
