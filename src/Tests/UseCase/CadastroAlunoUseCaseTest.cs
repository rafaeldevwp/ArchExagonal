using AutoMapper;
using Bussiness.Entidades;
using Bussiness.Interfaces.Services;
using Bussiness.UseCases;
using NSubstitute;
using Tests.Mock;
using Tests.Mock.Entidades;

namespace Tests.UseCase
{
    public class CadastroAlunoUseCaseTest
    {
        private readonly IAlunoServices _alunoServices;
        private readonly IMapper _mapper;
        private readonly CadastroAlunoUseCase _useCase;
        private Guid correlationId = Guid.NewGuid();
        public CadastroAlunoUseCaseTest()
        {
            _alunoServices = Substitute.For<IAlunoServices>();
            _mapper = Substitute.For<IMapper>();
            _useCase = new CadastroAlunoUseCase(_alunoServices, _mapper);
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
        public async Task Executar_ComInsertAluno()
        {
            // Arrange
            var alunoMock = AlunoMock.GetMockNull(); // Usando o método de geração de mock
            var alunoDtoMock = ResponseAlunoDtoMock.GetMock();

            var retorno = alunoMock; // O objeto retornado pelo mapeamento é o alunoMock

            _mapper.Map<Aluno>(alunoDtoMock).Returns(retorno); // Configurando o mapeamento do AutoMapper

            _alunoServices.ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(retorno)); // Corrigindo a chamada do método ObterAlunoAsync

            _alunoServices.InsertAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(retorno));

            // Act
            await _useCase.Execute(alunoMock, default, correlationId); // Usando alunoDtoMock

            // Assert
            await _alunoServices.Received().ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
            await _alunoServices.Received().InsertAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
        }



    }
}