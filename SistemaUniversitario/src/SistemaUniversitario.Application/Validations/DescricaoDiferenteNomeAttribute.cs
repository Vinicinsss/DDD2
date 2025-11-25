using System.ComponentModel.DataAnnotations;
using SistemaUniversitario.Application.DTOs; // Para acessar o CursoDTO

namespace SistemaUniversitario.Application.Validations
{
    public class DescricaoDiferenteNomeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Convertemos o objeto que está sendo validado para o nosso DTO
            var cursoDto = (CursoDTO)validationContext.ObjectInstance;

            // 'value' aqui é o valor da propriedade onde colocamos o atributo (ex: Descricao)
            if (value != null && cursoDto.Nome != null)
            {
                if (value.ToString().Trim().ToLower() == cursoDto.Nome.Trim().ToLower())
                {
                    return new ValidationResult("A descrição não pode ser idêntica ao nome do curso.");
                }
            }

            return ValidationResult.Success;
        }
    }
}