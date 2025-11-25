namespace SistemaUniversitario.Domain.Entities
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }

        // Chave Estrangeira
        public int CursoId { get; set; }
        
        // Propriedade de Navegação (Relacionamento)
        public virtual Curso Curso { get; set; }
    }
}