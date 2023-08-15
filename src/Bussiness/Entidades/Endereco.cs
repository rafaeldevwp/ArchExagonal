using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bussiness.Entidades
{
    public class Endereco
    {
        public Guid EnderecoId { get; set; }
        public int Numero { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }  
        public string? Complemento { get; set; }
    }
}