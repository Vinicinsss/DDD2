// src/SistemaUniversitario.Application/Interfaces/ICursoRepository.cs

using SistemaUniversitario.Domain.Entities; // Você precisará criar essa entidade depois
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
    }
}