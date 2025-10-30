// src/SistemaUniversitario.Application/DTOs/CursoDTO.cs

using System.ComponentModel.DataAnnotations;

namespace SistemaUniversitario.Application.DTOs
{
    public class CursoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do curso é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; }
    }
}