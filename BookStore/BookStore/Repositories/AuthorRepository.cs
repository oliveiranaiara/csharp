using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Models;
using BibliotecaApi.Data;
using BibliotecaApi.Repositories.Interfaces;

namespace BibliotecaApi.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAsync() =>
            await _context.Authors.Include(a => a.Books).ToListAsync();

        public async Task<Author> GetByIdAsync(int id) =>
            await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.AuthorId == id);

        public async Task<Author> AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return false;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}