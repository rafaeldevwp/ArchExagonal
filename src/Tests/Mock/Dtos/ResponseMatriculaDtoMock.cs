using Bogus;
using Bussiness.DTOs;
using Bussiness.Enum;
using Tests.Mock.Entidades;

namespace Tests.Mock.Dtos
{
    public static class ResponseMatriculaDtoMock
    {
        public static ResponseMatriculaDto GenerateMock()
        {
            var matriculaId = Guid.NewGuid();

            var matriculaDtoFaker = new Faker<ResponseMatriculaDto>()
                .RuleFor(m => m.MatriculaId, matriculaId)
                .RuleFor(m => m.DataCriacao, f => f.Date.Past())
                .RuleFor(m => m.DataAlteracao, f => f.Date.Recent())
                .RuleFor(m => m.Status, f => f.PickRandom<eStatusMatricula>())
                .RuleFor(m => m.Aluno, f => AlunoMock.GetMock());

            return matriculaDtoFaker.Generate();
        }
    }
}