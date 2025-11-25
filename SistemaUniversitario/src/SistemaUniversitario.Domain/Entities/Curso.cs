using System.Collections.Generic;

namespace SistemaUniversitario.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        // Relacionamento 1:N (Um Curso tem muitas Disciplinas)
        public virtual ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
    }
}