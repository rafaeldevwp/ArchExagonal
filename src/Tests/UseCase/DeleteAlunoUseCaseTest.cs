using AutoMapper;
using Bussiness.Entidades;
using Bussiness.Interfaces.Services;
using Bussiness.UseCases;
using NSubstitute;
using Tests.Mock;
using Tests.Mock.Entidades;

namespace Tests.UseCase
{
    public class DeleteAlunoUseCaseTest
    {
        private readonly IAlunoServices _alunoServices;
        private readonly IMapper _mapper;
        private readonly DeleteAlunoUseCase _useCase;
        private Guid correlationId = Guid.NewGuid();

        public DeleteAlunoUseCaseTest()
        {
            _alunoServices = Substitute.For<IAlunoServices>();
            _mapper = Substitute.For<IMapper>();
            _useCase = new DeleteAlunoUseCase(_alunoServices, _mapper);
        }


        [Fact]
        public async Task Executar_ComSucesso()
        {
            // Arrange
            var alunoMock = AlunoMock.GetMock(); // Usando o método de geração de mock
            var alunoDtoMock = ResponseAlunoDtoMock.GetMock();

            var retorno = alunoMock; // O objeto retornado pelo mapeamento é o alunoMock

            _mapper.Map<Aluno>(alunoDtoMock).Returns(retorno); // Configurando o mapeamento do AutoMapper

            _alunoServices.ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(retorno)); // Corrigindo a chamada do método ObterAlunoAsync

            // Act
            await _useCase.Execute(alunoMock, default, correlationId); // Usando alunoDtoMock

            // Assert
            await _alunoServices.Received().ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
            await _alunoServices.DidNotReceive().InsertAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
        }



        [Fact]
        public async Task Executar_AlunoNull()
        {
            // Arrange
            var alunoMock = AlunoMock.GetMockNull(); // Usando o método de geração de mock
            var alunoDtoMock = ResponseAlunoDtoMock.GetMockNull();

            var retorno = alunoMock; // O objeto retornado pelo mapeamento é o alunoMock

            _mapper.Map<Aluno>(alunoDtoMock).Returns(retorno); // Configurando o mapeamento do AutoMapper

            _alunoServices.ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(retorno)); // Corrigindo a chamada do método ObterAlunoAsync

            // Act
            await _useCase.Execute(alunoMock, default, correlationId); // Usando alunoDtoMock

            // Assert
            await _alunoServices.Received().ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
            await _alunoServices.DidNotReceive().UpdateAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
        }



        [Fact]
        public async Task Executar_AlunoStatusDesativado()
        {
            // Arrange
            var alunoMock = AlunoMock.GetMock(); // Usando o método de geração de mock

            _alunoServices.ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(alunoMock)); // Corrigindo a chamada do método ObterAlunoAsync

            // Act
            await _useCase.Execute(alunoMock, default, correlationId); // Usando alunoDtoMock

            // Assert
            await _alunoServices.Received().ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
            await _alunoServices.DidNotReceive().UpdateAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
        }



    }
}