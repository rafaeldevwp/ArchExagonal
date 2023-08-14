using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bussiness.Entidades
{
    public class Aluno
    {
        public Guid AlunoId { get; set; }   
        public string? Nome { get; set; }
        public int Idade { get; set; }  
        public decimal CPF { get; set; }    
        public Matricula? Matricula { get; set; }
    }
}