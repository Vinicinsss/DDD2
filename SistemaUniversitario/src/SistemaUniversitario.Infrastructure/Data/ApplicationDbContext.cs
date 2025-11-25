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

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; } // Nova tabela

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração explícita do relacionamento 1:N
            modelBuilder.Entity<Disciplina>()
                .HasOne(d => d.Curso)
                .WithMany(c => c.Disciplinas)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.Cascade); // Se apagar curso, apaga disciplinas

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}