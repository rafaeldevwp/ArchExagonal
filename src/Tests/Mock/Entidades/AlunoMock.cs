using Bogus;
using Bussiness.Entidades;

namespace Tests.Mock.Entidades
{
    public static class AlunoMock
    {
        public static Aluno GetMock()
        {
            var faker = new Faker();

            var enderecoFaker = new Faker<Endereco>()
                .RuleFor(e => e.EnderecoId, f => f.Random.Guid())
                .RuleFor(e => e.Numero, f => f.Random.Int(1, 1000))
                .RuleFor(e => e.Rua, f => f.Address.StreetName())
                .RuleFor(e => e.Bairro, f => f.Address.City())
                .RuleFor(e => e.Cidade, f => f.Address.City())
                .RuleFor(e => e.Estado, f => f.Address.StateAbbr())
                .RuleFor(e => e.Complemento, f => f.Address.SecondaryAddress());

            var alunoFaker = new Faker<Aluno>()
                .RuleFor(a => a.AlunoId, f => f.Random.Guid())
                .RuleFor(a => a.Nome, f => f.Person.FullName)
                .RuleFor(a => a.Idade, f => f.Random.Int(18, 30))
                .RuleFor(a => a.CPF, f => GenerateRandomCpf(f))
                .RuleFor(a => a.Endereco, f => enderecoFaker.Generate());

            return alunoFaker.Generate();
        }

        public static Aluno GetMockNull() => default;

        private static string GenerateRandomCpf(Faker faker)
        {
            var cpf = string.Format("{0:D3}.{1:D3}.{2:D3}-{3:D2}", faker.Random.Number(1000), faker.Random.Number(1000), faker.Random.Number(1000), faker.Random.Number(100));
            return cpf;
        }
    }
}