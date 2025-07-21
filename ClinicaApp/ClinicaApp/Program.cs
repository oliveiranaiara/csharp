using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Adiciona os servi�os ao cont�iner
builder.Services.AddControllersWithViews();


// Inje��o do BD no projeto

builder.Services.AddDbContext<ClinicaApp.Data.ClinicaContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("clinicaApp")));


var app = builder.Build();

// Configura o pipeline de requisi��o HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS por padr�o: 30 dias
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();