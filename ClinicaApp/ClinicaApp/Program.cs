using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Adiciona os serviços ao contêiner
builder.Services.AddControllersWithViews();


// Injeção do BD no projeto

builder.Services.AddDbContext<ClinicaApp.Data.ClinicaContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("clinicaApp")));


var app = builder.Build();

// Configura o pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS por padrão: 30 dias
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();