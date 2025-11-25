using System.ComponentModel.DataAnnotations;
using SistemaUniversitario.Application.Validations;

namespace SistemaUniversitario.Application.DTOs
{
    public class CursoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        [PrimeiraLetraMaiuscula] // Validação 1
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [DescricaoDiferenteNome] // Validação 2 (Nova)
        public string Descricao { get; set; }
    }
}