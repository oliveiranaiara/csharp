using GerenciadorDeProjetos.Data;
using GerenciadorDeProjetos.Repositories;
using GerenciadorDeProjetos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// *** SOLUÇÃO: Adicione esta configuração ***
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Ignora os ciclos de referência em vez de lançar uma exceção.
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


// Add services to the container.


// Pega a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Adiciona o AppDbContext ao container de serviços.
// Isso permite que ele seja injetado em outras partes da aplicação (como os controllers).
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// --- INÍCIO DAS NOVAS LINHAS ---
// AddScoped significa que uma nova instância dos repositórios será criada
// para cada requisição HTTP, e a mesma instância será usada durante
// todo o ciclo de vida dessa requisição.
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
// --- FIM DAS NOVAS LINHAS ---


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

app.Run();
