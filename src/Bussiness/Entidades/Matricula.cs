using Bussiness.Enum;

namespace Bussiness.Entidades
{
        public class Matricula
        {
            public Guid MatriculaId { get; set; }
            public DateTime DataCriacao { get; } = DateTime.Now;
            public DateTime DataAlteracao { get; set; }
            public eStatusMatricula Status { get; set; }
            public Aluno? Aluno { get; set; }
            public Curso? Curso { get; set; }
        }
}