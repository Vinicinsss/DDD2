// src/SistemaUniversitario.Application/Services/CursoService.cs

using SistemaUniversitario.Application.DTOs;
using SistemaUniversitario.Application.Interfaces;
using SistemaUniversitario.Domain.Entities; // Erro temporário
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaUniversitario.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        // A dependência é injetada via construtor
        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task AdicionarAsync(CursoDTO cursoDto)
        {
            // Aqui você poderia usar um AutoMapper, mas para simplificar vamos fazer manualmente
            var curso = new Curso
            {
                Nome = cursoDto.Nome,
                Descricao = cursoDto.Descricao
            };
            await _cursoRepository.AddAsync(curso);
        }

        public async Task AtualizarAsync(CursoDTO cursoDto)
        {
            var curso = await _cursoRepository.GetByIdAsync(cursoDto.Id);
            if (curso != null)
            {
                curso.Nome = cursoDto.Nome;
                curso.Descricao = cursoDto.Descricao;
                await _cursoRepository.UpdateAsync(curso);
            }
        }

        public async Task<CursoDTO> ObterPorIdAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null) return null;

            return new CursoDTO
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Descricao = curso.Descricao
            };
        }

        public async Task<IEnumerable<CursoDTO>> ObterTodosAsync()
        {
            var cursos = await _cursoRepository.GetAllAsync();
            var cursosDto = new List<CursoDTO>();

            foreach (var curso in cursos)
            {
                cursosDto.Add(new CursoDTO
                {
                    Id = curso.Id,
                    Nome = curso.Nome,
                    Descricao = curso.Descricao
                });
            }
            return cursosDto;
        }

        public async Task RemoverAsync(int id)
        {
            await _cursoRepository.DeleteAsync(id);
        }
    }
}