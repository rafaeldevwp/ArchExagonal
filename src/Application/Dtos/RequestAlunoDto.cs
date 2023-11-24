using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class RequestAlunoDto
    {
        [Required]
        public decimal CPF { get; set; }
    }
}
