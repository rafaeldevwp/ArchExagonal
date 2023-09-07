using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Entidades;

namespace Bussiness.DTOs
{
    public class ObterRequestMatriculaDto
    {
        public int Matricula { get; set; }
        public Aluno? Aluno { get; set; }
    }
}