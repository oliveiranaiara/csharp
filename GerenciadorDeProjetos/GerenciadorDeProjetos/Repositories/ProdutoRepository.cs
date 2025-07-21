using GerenciadorDeProjetos.Data;
using GerenciadorDeProjetos.Models;
using GerenciadorDeProjetos.Repositories.Interfaces;

namespace GerenciadorDeProjetos.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        // Novamente, sem SaveChangesAsync() aqui.
    }

    public Task AddSync(Produto produto)
    {
        throw new NotImplementedException();
    }
}
