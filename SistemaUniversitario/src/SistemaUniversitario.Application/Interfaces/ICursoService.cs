// src/SistemaUniversitario.Application/Interfaces/ICursoService.cs

using SistemaUniversitario.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaUniversitario.Application.Interfaces
{
    public interface ICursoService
    {
        Task<CursoDTO> ObterPorIdAsync(int id);
        Task<IEnumerable<CursoDTO>> ObterTodosAsync();
        Task AdicionarAsync(CursoDTO cursoDto);
        Task AtualizarAsync(CursoDTO cursoDto);
        Task RemoverAsync(int id);
    }
}