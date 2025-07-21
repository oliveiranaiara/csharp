using GerenciadorDeProjetos.Data;
using GerenciadorDeProjetos.Models;
using GerenciadorDeProjetos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeProjetos.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            // ATENÇÃO: Note que não estamos chamando o SaveChangesAsync() aqui.
            // Isso será responsabilidade de outra classe (Unit of Work), para garantir
            // que múltiplas operações sejam salvas em uma única transação.
        }

        public async Task<Categoria?> FindByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> GetByIdWithProductsAsync(int id) => await _context.Categorias
                 .Include(c => c.Produtos) // Inclui os produtos relacionados à categoria
                 .FirstOrDefaultAsync(c => c.Id == id); // Busca a categoria pelo ID 
    }
}
