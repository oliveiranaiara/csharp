using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiCatalogo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");



            //inserir datados para seed
            // Categorias
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { CategoriaId = 1, Nome = "Bebidas", ImagemUrl = "bebidas.jpg" },
                new Categoria { CategoriaId = 2, Nome = "Lanches", ImagemUrl = "lanches.jpg" },
                new Categoria { CategoriaId = 3, Nome = "Sobremesas", ImagemUrl = "sobremesas.jpg" }
            );

            // Produtos
            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    ProdutoId = 1,
                    Nome = "Coca-Cola",
                    Descricao = "Refrigerante 2L",
                    Preco = 7.5m,
                    ImagemUrl = "coca.jpg",
                    Estoque = 100,
                    DataCadastro = DateTime.Now, // ou uma data fixa
                    CategoriaId = 1,
                   
                },
                new Produto
                {
                    ProdutoId = 2,
                    Nome = "X-Burguer",
                    Descricao = "Pão, carne e queijo",
                    Preco = 15.0m,
                    ImagemUrl = "xburguer.jpg",
                    Estoque = 50,
                    DataCadastro = DateTime.Now,
                    CategoriaId = 2,
                    
                },
                new Produto
                {
                    ProdutoId = 3,
                    Nome = "Sorvete Napolitano",
                    Descricao = "1L sabor napolitano",
                    Preco = 20.0m,
                    ImagemUrl = "sorvete.jpg",
                    Estoque = 30,
                    DataCadastro = DateTime.Now,
                    CategoriaId = 3,
                    
                }
            );





        }

    }
}