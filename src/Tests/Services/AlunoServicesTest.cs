using Bussiness.Interfaces.Repository;
using NSubstitute;
using Tests.Mock.Entidades;
using Infra.Services.AlunoServices;
using Bussiness.Entidades;

namespace Tests.Services
{
    public class AlunoServicesTest
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly AlunoServices _useCase;
        public AlunoServicesTest()
        {
            _alunoRepository = Substitute.For<IAlunoRepository>();
            _useCase = new AlunoServices(_alunoRepository);

        }

        [Fact]
        public async Task InsertAsyncAlunoExiste()
        {
            // Given
            var alunoMock = AlunoMock.GetMock();

            _alunoRepository.ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>())
              .Returns(alunoMock);

            _alunoRepository.InsertAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>())
                .Returns(alunoMock);

            // When
            await _useCase.InsertAsync(alunoMock, default);

            // Then
            await _alunoRepository.Received().ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
            await _alunoRepository.DidNotReceive().InsertAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
        }

        
        [Fact]
        public async Task InsertAsyncAlunoNaoExiste()
        {
            // Given
            var alunoMock = AlunoMock.GetMockNull();

            _alunoRepository.ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>())
              .Returns(alunoMock);

            _alunoRepository.InsertAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>())
                .Returns(alunoMock);

            // When
            await _useCase.InsertAsync(alunoMock, default);

            // Then
            await _alunoRepository.Received().ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
            await _alunoRepository.Received().InsertAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
        }


    }
}
