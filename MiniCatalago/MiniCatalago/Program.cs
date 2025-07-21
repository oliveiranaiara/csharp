using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


//1. Configura��o da WebAPI
var builder = WebApplication.CreateBuilder(args);


// Configura��o do Entity Framework Core com InMemory Database
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



//3. Cria��o da rota ou ENDPOINT MONOLITICO
app.MapPost("/products", async (Product product, ProductDbContext dbContext) =>
{
    //resposabilidade #1: VAlida��o dos dados de entrada
    if (string.IsNullOrEmpty(product.Name) || product.Price <= 0)
    {
        return Results.BadRequest("Nome do produto e pre�o s�o Obrigat�rios");
    }

    //responsabilidade #2: L�gica de neg�cio (calular o desconto)
    decimal finalPrice = product.Price;
    if (product.Type == "Eletr�nico")
    {
        finalPrice *= 0.9m; // 10% de desconto
    }
    else if (product.Type == "Vestu�rio")
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

    //responsabilidade #3: Persist�ncia dos dados
    dbContext.Products.Add(finalProduct);
    await dbContext.SaveChangesAsync();


    //responsabilidade #4: Retorno da resposta
    Console.WriteLine($"Produto {finalProduct.Name} adicionado com sucesso! Pre�o de: {finalPrice:C}");

    return Results.Created($"/products/{finalProduct.Id}", finalProduct);
});


app.Run();


//4. Defini��es de Entidade e Context
public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; } //exe. elet�nico, vetu�rio

}



public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}