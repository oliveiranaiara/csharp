using GerenciadorDeProjetos.Data;
using GerenciadorDeProjetos.Repositories.Interfaces;

namespace GerenciadorDeProjetos.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        public ICategoriaRepository CategoriaRepository { get; private set; }
        public IProdutoRepository ProdutoRepository { get; private set; }

        /*
        public UnitOfWork(AppDbContext context, ICategoriaRepository categoriaRepository, IProdutoRepository produtoRepository)
        {
            _context = context;
            this.categoriaRepository = categoriaRepository;
            this.produtoRepository = produtoRepository;
        }
        */

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            // Inicializa os repositórios com o contexto
            CategoriaRepository = new CategoriaRepository(_context);
            ProdutoRepository = new ProdutoRepository(_context);
        }



        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

