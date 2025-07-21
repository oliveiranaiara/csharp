using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


//1. Configuração da WebAPI
var builder = WebApplication.CreateBuilder(args);


// Configuração do Entity Framework Core com InMemory Database
// Add services to the container.

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseInMemoryDatabase("ProductDB"));




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



//3. Criação da rota ou ENDPOINT MONOLITICO
app.MapPost("/products", async (Product product, ProductDbContext dbContext) =>
{
    //resposabilidade #1: VAlidação dos dados de entrada
    if (string.IsNullOrEmpty(product.Name) || product.Price <= 0)
    {
        return Results.BadRequest("Nome do produto e preço são Obrigatórios");
    }

    //responsabilidade #2: Lógica de negócio (calular o desconto)
    decimal finalPrice = product.Price;
    if (product.Type == "Eletrônico")
    {
        finalPrice *= 0.9m; // 10% de desconto
    }
    else if (product.Type == "Vestuário")
    {
        finalPrice *= 0.8m; // 20% de desconto

    }
    //e se for outro type?

    var finalProduct = new Product
    {
        Name = product.Name,
        Price = finalPrice,
        Type = product.Type
    };

    //responsabilidade #3: Persistência dos dados
    dbContext.Products.Add(finalProduct);
    await dbContext.SaveChangesAsync();


    //responsabilidade #4: Retorno da resposta
    Console.WriteLine($"Produto {finalProduct.Name} adicionado com sucesso! Preço de: {finalPrice:C}");

    return Results.Created($"/products/{finalProduct.Id}", finalProduct);
});


app.Run();


//4. Definições de Entidade e Context
public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; } //exe. eletônico, vetuário

}



public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}