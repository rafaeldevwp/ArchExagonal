using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bussiness.Entidades
{
    public class Matricula
    {
        public Guid MatriculaId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int Status { get; set; }
        public Aluno? Aluno { get; set; }
        public Curso? Curso { get; set; }
    }
}