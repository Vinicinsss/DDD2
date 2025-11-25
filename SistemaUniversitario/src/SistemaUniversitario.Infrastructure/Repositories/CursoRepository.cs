using Microsoft.EntityFrameworkCore;
using SistemaUniversitario.Application.Interfaces;
using SistemaUniversitario.Domain.Entities;
using SistemaUniversitario.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq; // Importante para o Where
using System.Threading.Tasks;

namespace SistemaUniversitario.Infrastructure.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
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
            _context.Entry(curso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Implementação da busca
        public async Task<IEnumerable<Curso>> SearchAsync(string termo)
        {
            // Busca por Nome OU Descrição
            return await _context.Cursos
                .Where(c => c.Nome.Contains(termo) || c.Descricao.Contains(termo))
                .ToListAsync();
        }
    }
}