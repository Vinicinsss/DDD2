// src/SistemaUniversitario.Domain/Entities/Curso.cs

namespace SistemaUniversitario.Domain.Entities
{
    // Esta é a nossa entidade de domínio.
    // Ela representa o conceito central de 'Curso' no sistema.
    // Contém apenas as propriedades e a lógica de negócio que são intrínsecas a um curso,
    // sem se preocupar com como será salva no banco ou exibida na tela.
    public class Curso
    {
        // Chave primária da entidade.
        public int Id { get; set; }

        // Propriedades do curso.
        public string Nome { get; set; }
        public string Descricao { get; set; }

        // Futuramente, você poderia adicionar regras de negócio aqui.
        // Por exemplo, um método para validar se o nome do curso é válido
        // segundo as regras da universidade.
        // public bool IsValid() { ... }

        // Também poderia ter outras propriedades ou listas de entidades relacionadas,
        // como uma lista de Alunos ou Disciplinas.
        // public virtual ICollection<Disciplina> Disciplinas { get; set; }
    }
}