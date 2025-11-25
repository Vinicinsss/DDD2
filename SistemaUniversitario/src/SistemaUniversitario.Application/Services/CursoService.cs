using Mapster;
using SistemaUniversitario.Application.DTOs;
using SistemaUniversitario.Application.Interfaces;
using SistemaUniversitario.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaUniversitario.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task AdicionarAsync(CursoDTO cursoDto)
        {
            var curso = cursoDto.Adapt<Curso>();
            await _cursoRepository.AddAsync(curso);
        }

        public async Task AtualizarAsync(CursoDTO cursoDto)
        {
            var curso = await _cursoRepository.GetByIdAsync(cursoDto.Id);
            if (curso != null)
            {
                cursoDto.Adapt(curso);
                await _cursoRepository.UpdateAsync(curso);
            }
        }

        public async Task<CursoDTO> ObterPorIdAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            return curso?.Adapt<CursoDTO>();
        }

        public async Task<IEnumerable<CursoDTO>> ObterTodosAsync()
        {
            var cursos = await _cursoRepository.GetAllAsync();
            return cursos.Adapt<IEnumerable<CursoDTO>>();
        }

        public async Task RemoverAsync(int id)
        {
            await _cursoRepository.DeleteAsync(id);
        }

        // Implementação da busca com Mapster
        public async Task<IEnumerable<CursoDTO>> PesquisarAsync(string termo)
        {
            var cursos = await _cursoRepository.SearchAsync(termo);
            return cursos.Adapt<IEnumerable<CursoDTO>>();
        }
    }
}