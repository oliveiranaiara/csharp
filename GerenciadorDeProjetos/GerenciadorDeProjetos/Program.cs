using GerenciadorDeProjetos.Data;
using GerenciadorDeProjetos.Repositories;
using GerenciadorDeProjetos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// *** SOLU��O: Adicione esta configura��o ***
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Ignora os ciclos de refer�ncia em vez de lan�ar uma exce��o.
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


// Add services to the container.


// Pega a string de conex�o do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Adiciona o AppDbContext ao container de servi�os.
// Isso permite que ele seja injetado em outras partes da aplica��o (como os controllers).
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// --- IN�CIO DAS NOVAS LINHAS ---
// AddScoped significa que uma nova inst�ncia dos reposit�rios ser� criada
// para cada requisi��o HTTP, e a mesma inst�ncia ser� usada durante
// todo o ciclo de vida dessa requisi��o.
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
