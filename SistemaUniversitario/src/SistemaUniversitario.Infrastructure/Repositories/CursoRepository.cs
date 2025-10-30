// src/SistemaUniversitario.Infrastructure/Repositories/CursoRepository.cs

using Microsoft.EntityFrameworkCore;
using SistemaUniversitario.Application.Interfaces;
using SistemaUniversitario.Domain.Entities;
using SistemaUniversitario.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaUniversitario.Infrastructure.Repositories
{
    // Esta classe implementa o contrato definido na camada de Aplicação.
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;

        // O DbContext é injetado via construtor (Injeção de Dependência).
        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync(); // Salva as mudanças no banco.
        }

        public async Task DeleteAsync(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task<Curso> GetByIdAsync(int id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        public async Task UpdateAsync(Curso curso)
        {
            // O EF Core rastreia a entidade, então apenas marcar como 'Modified' é suficiente.
            _context.Entry(curso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}