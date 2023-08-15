namespace Bussiness.Entidades
{
    public class Curso
    {
        public Guid CursoId { get; set; }
        public string? Nome { get; set; }    
        public int Status  { get; set; }
        public Professor? Professor { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}