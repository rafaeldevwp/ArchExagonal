using Bussiness.Entidades;
using Bussiness.Enum;

namespace Bussiness.DTOs
{
    public class ObterResponseAlunoDto
    {
        public Guid AlunoId { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public Endereco? Endereco { get; set; }
        public eStatusAluno statusAluno { get; set; }
    }
}