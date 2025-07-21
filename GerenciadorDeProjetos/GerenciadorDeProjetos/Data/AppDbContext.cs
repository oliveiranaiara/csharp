using GerenciadorDeProjetos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeProjetos.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            // Mapeia o modelo Categoria para uma tabela "Categorias" no banco
            public DbSet<Categoria> Categorias { get; set; }

            // Mapeia o modelo Produto para uma tabela "Produtos" no banco
            public DbSet<Produto> Produtos { get; set; }
        }

    }

