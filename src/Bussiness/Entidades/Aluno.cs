using Bussiness.Enum;

namespace Bussiness.Entidades
{
    public class Aluno
    {
        public Guid AlunoId { get; set; }   
        public string? Nome { get; set; }
        public int Idade { get; set; }  
        //TO DO Voltar CPF para Decimal e realizar novos testes - Realizar pesquisas sobre como resolver o problema
        public string? CPF { get; set; }    
        public eStatusAluno Status { get; set; }
        public Endereco? Endereco { get; set; }
    
    }
}