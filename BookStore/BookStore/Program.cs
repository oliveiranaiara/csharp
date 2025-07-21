using BibliotecaApi.Data;
using BibliotecaApi.Repositories;
using BibliotecaApi.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("BibliotecaDb")); // Pode trocar para SQL Server se quiser

// Repositories
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();