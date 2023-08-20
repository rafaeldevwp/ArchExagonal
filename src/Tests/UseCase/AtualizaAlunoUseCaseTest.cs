using AutoMapper;
using Bussiness.Entidades;
using Bussiness.Interfaces.Services;
using Bussiness.UseCases;
using NSubstitute;
using Tests.Mock;
using Tests.Mock.Entidades;

namespace Tests.UseCase
{
    public class AtualizaAlunoUseCaseTest
    {
        private readonly IAlunoServices _alunoService;
        private readonly IMapper _mappper;
        private readonly AtualizaAlunoUseCase _useCase;
        private readonly Guid correlationId = Guid.NewGuid();

        public AtualizaAlunoUseCaseTest()
        {
            _alunoService = Substitute.For<IAlunoServices>();
            _mappper = Substitute.For<IMapper>();
            _useCase = new AtualizaAlunoUseCase(_alunoService, _mappper);

        }

        [Fact]
        public async Task Executar_ComSucesso()
        {

            //Arrange
            var alunoMock = AlunoMock.GetMock();
            var alunoDTO = ResponseAlunoDtoMock.GetMock();
            var retorno = alunoMock; // O objeto retornado pelo mapeamento é o alunoMock

            _mappper.Map<Aluno>(alunoDTO)
            .Returns(retorno); // Configurando o mapeamento do AutoMapper

            _alunoService.ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(alunoMock));

            //Act
            await _useCase.Execute(alunoMock, default, correlationId);

            //Assert
            await _alunoService.Received().UpdateAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());

        }


        [Fact]
        public async Task Executar_ComExcecao()
        {

            //Arrange
            var alunoMock = AlunoMock.GetMock();
            var alunoDTO = ResponseAlunoDtoMock.GetMock();
            var retorno = alunoMock; // O objeto retornado pelo mapeamento é o alunoMock

            _mappper.Map<Aluno>(alunoDTO)
            .Returns(retorno); // Configurando o mapeamento do AutoMapper

            _alunoService.ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromException<Aluno>(new Exception()));

            //Act
            await _useCase.Execute(alunoMock, default, correlationId);

            //Assert
            await _alunoService.DidNotReceive().UpdateAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());

        }



         [Fact]
        public async Task Executar_ComAlunoNull()
        {

            //Arrange
            var alunoMock = AlunoMock.GetMockNull();
            var alunoDTO = ResponseAlunoDtoMock.GetMockNull();
            var retorno = alunoMock; // O objeto retornado pelo mapeamento é o alunoMock

            _mappper.Map<Aluno>(alunoDTO)
            .Returns(retorno); // Configurando o mapeamento do AutoMapper
            
            _alunoService.ObterAlunoAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>())
                .Returns(alunoMock);

            //Act
            await _useCase.Execute(alunoMock, default, correlationId);

            //Assert
            await _alunoService.DidNotReceive().UpdateAsync(Arg.Any<Aluno>(), Arg.Any<CancellationToken>());
            Assert.Null(retorno);
        }



    }
}