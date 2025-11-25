using Microsoft.EntityFrameworkCore;
using SistemaUniversitario.Application.Interfaces;
using SistemaUniversitario.Application.Services;
using SistemaUniversitario.Infrastructure.Data;
using SistemaUniversitario.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar a conexão com o Banco de Dados (SQL Server)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Registrar os Serviços e Repositórios (Injeção de Dependência)
// A camada Web pede ICursoService -> O container entrega CursoService
// A camada Service pede ICursoRepository -> O container entrega CursoRepository
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICursoService, CursoService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();