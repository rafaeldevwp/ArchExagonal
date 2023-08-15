namespace Bussiness.Entidades
{
    public class Professor
    {
        public Guid ProfessorId { get; set; }
        public string? Nome { get; set; }
        public decimal CPF { get; set; }
        public int Status { get; set; }
        public List<Curso>?  Cursos { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}