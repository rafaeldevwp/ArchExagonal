using Bogus;
using Bussiness.Entidades;
using Bussiness.Enum;

namespace Tests.Mock.Entidades
{
    public static class CursoMock
    {
        public static Curso GenerateMock()
        {
            var cursoId = Guid.NewGuid();

            var cursoFaker = new Faker<Curso>()
                .RuleFor(c => c.CursoId, cursoId)
                .RuleFor(c => c.Nome, f => f.Commerce.ProductName())
                .RuleFor(c => c.Status, f => f.PickRandom<eStatusCurso>())
                .RuleFor(c => c.Professor, f => ProfessorMock.GenerateMock())
                .RuleFor(c => c.DataInicio, f => f.Date.Past())
                .RuleFor(c => c.DataFim, f => f.Date.Future());

            return cursoFaker.Generate();
        }

        public static List<Curso> GenerateListMock(int numberOfCourses = 10)
        {
            var cursoFaker = new Faker<Curso>()
                .RuleFor(c => c.CursoId, f => Guid.NewGuid())
                .RuleFor(c => c.Nome, f => f.Commerce.ProductName())
                .RuleFor(c => c.Status, f => f.PickRandom<eStatusCurso>())
                .RuleFor(c => c.Professor, f => ProfessorMock.GenerateMock())
                .RuleFor(c => c.DataInicio, f => f.Date.Past())
                .RuleFor(c => c.DataFim, f => f.Date.Future())
                .Generate(numberOfCourses); // Use Generate() para gerar a lista

            return cursoFaker.ToList(); // Converta o cursoFaker para uma lista
        }

        public static Curso GenerateMockNull() => default;

    }
}