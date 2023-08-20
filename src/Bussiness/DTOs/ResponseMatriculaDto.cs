using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Entidades;
using Bussiness.Enum;

namespace Bussiness.DTOs
{
    public class ResponseMatriculaDto
    {
        public Guid MatriculaId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public eStatusMatricula Status { get; set; }
        public Aluno? Aluno { get; set; }
    }
}