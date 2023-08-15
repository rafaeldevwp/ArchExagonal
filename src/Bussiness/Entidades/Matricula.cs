using Bussiness.Enum;

namespace Bussiness.Entidades
{
        public class Matricula
        {
            public Guid MatriculaId { get; set; }
            public DateTime DataCriacao { get; set; }
            public DateTime DataAlteracao { get; set; }
            public eStatusMatricula Status { get; set; }
            public Aluno? Aluno { get; set; }
            public List<Curso>? Curso { get; set; }
        }
}