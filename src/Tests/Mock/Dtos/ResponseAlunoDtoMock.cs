using Bogus;
using Bussiness.DTOs;
using Bussiness.Entidades;
using Bussiness.Enum;

namespace Tests.Mock
{
    public static class ResponseAlunoDtoMock
    {
        public static ObterResponseAlunoDto GetMock()
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


            var alunoFaker = new Faker<ObterResponseAlunoDto>()
                .RuleFor(a => a.AlunoId, f => f.Random.Guid())
                .RuleFor(a => a.Nome, f => f.Person.FullName)
                .RuleFor(a => a.Endereco, f => enderecoFaker.Generate())
                .RuleFor(a => a.statusAluno, f => f.PickRandom<eStatusAluno>());

            return alunoFaker.Generate();
        }

         public static ObterResponseAlunoDto GetMockNull() => default;

    }
}