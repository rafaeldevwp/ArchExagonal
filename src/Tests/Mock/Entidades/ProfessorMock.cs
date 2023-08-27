using Bogus;
using Bussiness.Entidades;
using Bussiness.Enum;

namespace Tests.Mock.Entidades
{
    public static class ProfessorMock
    {
        public static Professor GenerateMock()
        {
            var professorId = Guid.NewGuid();

            var professorFaker = new Faker<Professor>()
                .RuleFor(p => p.ProfessorId, professorId)
                .RuleFor(p => p.Nome, f => f.Name.FullName())
                .RuleFor(p => p.CPF, f => GenerateRandomCpf(f)) // Gera um CPF válido fictício
                .RuleFor(p => p.Status, f => f.PickRandomWithout<eStatusProfessor>())
                .RuleFor(p => p.Cursos, f => CursoMock.GenerateListMock(1)) // Gera uma lista de 3 cursos fictícios
                .RuleFor(p => p.DataCadastro, f => f.Date.Past())
                .RuleFor(p => p.DataAlteracao, f => f.Date.Recent());

            return professorFaker.Generate();
        }

         private static string GenerateRandomCpf(Faker faker)
        {
            var cpf = string.Format("{0:D3}.{1:D3}.{2:D3}-{3:D2}", faker.Random.Number(1000), faker.Random.Number(1000), faker.Random.Number(1000), faker.Random.Number(100));
            return cpf;
        }
    }
}