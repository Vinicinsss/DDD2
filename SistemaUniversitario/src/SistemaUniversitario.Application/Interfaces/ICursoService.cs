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

        // Novo método no contrato do serviço
        Task<IEnumerable<CursoDTO>> PesquisarAsync(string termo);
    }
}