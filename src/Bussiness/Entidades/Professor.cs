using Bussiness.Enum;

namespace Bussiness.Entidades
{
    public class Professor
    {
        public Guid ProfessorId { get; set; }
        public string? Nome { get; set; }
        public string CPF { get; set; }
        public eStatusProfessor Status { get; set; }
        public List<Curso>?  Cursos { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}