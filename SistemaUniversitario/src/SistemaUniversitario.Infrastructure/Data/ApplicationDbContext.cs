// src/SistemaUniversitario.Infrastructure/Data/ApplicationDbContext.cs

using Microsoft.EntityFrameworkCore;
using SistemaUniversitario.Domain.Entities;
using System.Reflection;

namespace SistemaUniversitario.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Mapeia a entidade 'Curso' para uma tabela chamada 'Cursos' no banco de dados.
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Este método é útil para configurações mais complexas (Fluent API),
            // mas para nosso CRUD simples, não precisamos adicionar nada aqui por enquanto.
            // Ele pode aplicar configurações de outros arquivos automaticamente.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}