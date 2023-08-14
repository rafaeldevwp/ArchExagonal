using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bussiness.Entidades
{
    public class Curso
    {
        public Guid CursoId { get; set; }
        public string? Nome { get; set; }    
        public int Status  { get; set; }
        public Professor? Professor { get; set; }
    }
}