using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Bussiness.Entidades;

namespace Tests.Mock
{
    public static class EnderecoMock
    {
        public static Endereco GetMock()
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

        return enderecoFaker.Generate();
    }
        
    }
}