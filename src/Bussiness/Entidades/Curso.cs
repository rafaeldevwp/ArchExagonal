using Bussiness.Enum;

namespace Bussiness.Entidades
{
    public class Curso
    {
        public Guid CursoId { get; set; }
        public string? Nome { get; set; }    
        public eStatusCurso Status  { get; set; }
        public Professor? Professor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public double Preco { get; set; }
    }
}