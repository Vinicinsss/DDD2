using SistemaUniversitario.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaUniversitario.Application.Interfaces
{
    public interface ICursoRepository
    {
        Task<Curso> GetByIdAsync(int id);
        Task<IEnumerable<Curso>> GetAllAsync();
        Task AddAsync(Curso curso);
        Task UpdateAsync(Curso curso);
        Task DeleteAsync(int id);
        
        // Novo método para a busca dinâmica
        Task<IEnumerable<Curso>> SearchAsync(string termo);
    }
}