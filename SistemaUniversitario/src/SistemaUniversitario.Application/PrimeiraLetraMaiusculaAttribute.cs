using System.ComponentModel.DataAnnotations;

namespace SistemaUniversitario.Application.Validations
{
    // Requisito 6: Validação personalizada 1
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success; // Deixa o [Required] lidar com nulos
            }

            var texto = value.ToString();
            if (char.IsLower(texto[0]))
            {
                return new ValidationResult("A primeira letra deve ser maiúscula.");
            }

            return ValidationResult.Success;
        }
    }
}