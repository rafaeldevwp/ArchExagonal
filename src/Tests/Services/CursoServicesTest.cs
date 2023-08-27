using Bussiness.Interfaces.Repository;
using NSubstitute;
using Tests.Mock.Entidades;
using Bussiness.Entidades;
using Infra.Services;

namespace Tests.Services
{
    public class CursoServicesTest
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly CursoService _useCase;
        public CursoServicesTest()
        {
            _cursoRepository = Substitute.For<ICursoRepository>();
            _useCase = new CursoService(_cursoRepository);

        }

        [Fact]
        public async Task InsertAsyncNaoExiste()
        {
            // Given
            var cursoMock = CursoMock.GenerateMockNull();

            _cursoRepository.ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
              .Returns(cursoMock);

            _cursoRepository.InsertAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
                .Returns(cursoMock);

            // When
            await _useCase.InsertAsync(cursoMock, default);

            // Then
            await _cursoRepository.Received().ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());
            await _cursoRepository.Received().InsertAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());
        }


        [Fact]
        public async Task InsertAsyncCursoJaExiste()
        {
            // Given
            var cursoMock = CursoMock.GenerateMock();

            _cursoRepository.ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
              .Returns(cursoMock);

            _cursoRepository.InsertAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
                .Returns(cursoMock);

            // When
            //await _useCase.InsertAsync(cursoMock, default);

            // Then
            await Assert.ThrowsAsync<ArgumentNullException>(() => _useCase.InsertAsync(cursoMock, default));
            await _cursoRepository.Received().ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());
            await _cursoRepository.DidNotReceive().InsertAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());
        }


        [Fact]
        public async Task InsertAsyncCursoJaAtivo()
        {
            // Given
            var cursoMock = CursoMock.GenerateMock();
            cursoMock.Status = Bussiness.Enum.eStatusCurso.Ativo;

            _cursoRepository.ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
              .Returns(cursoMock);

            _cursoRepository.InsertAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
                .Returns(cursoMock);

            // When
            //await _useCase.InsertAsync(cursoMock, default);

            // Then
            await Assert.ThrowsAsync<ArgumentNullException>(() => _useCase.InsertAsync(cursoMock, default));
            await _cursoRepository.Received().ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());
            await _cursoRepository.DidNotReceive().InsertAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());
        }



        [Fact]
        public async Task DeleteAsyncCursoNaoExiste()
        {
            // Given
            var cursoMock = CursoMock.GenerateMockNull();

            _cursoRepository.ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
              .Returns(cursoMock);

            _cursoRepository.UpdateCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
                .Returns(cursoMock);

            // When
            // await _useCase.DeleteAsync(CursoMock, default);

            // Then
            await Assert.ThrowsAsync<ArgumentNullException>(() => _useCase.DeleteCursoAsync(cursoMock, default));
            await _cursoRepository.Received().ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());
            await _cursoRepository.DidNotReceive().UpdateCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());

        }


        [Fact]
        public async Task DeleteAsyncCursoDesativado()
        {
            // Given
            var cursoMock = CursoMock.GenerateMock();
            cursoMock.Status = Bussiness.Enum.eStatusCurso.Desativado;

            _cursoRepository.ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
              .Returns(cursoMock);

            _cursoRepository.UpdateCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
                .Returns(cursoMock);

            // When
            // await _useCase.DeleteAsync(CursoMock, default);

            // Then
            await Assert.ThrowsAsync<ArgumentNullException>(() => _useCase.DeleteCursoAsync(cursoMock, default));
            await _cursoRepository.Received().ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());
            await _cursoRepository.DidNotReceive().UpdateCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());

        }


        [Fact]
        public async Task DeleteAsyncCursoComSucesso()
        {
            // Given
            var cursoMock = CursoMock.GenerateMock();
            cursoMock.Status = Bussiness.Enum.eStatusCurso.Ativo;

            _cursoRepository.ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
              .Returns(cursoMock);

            _cursoRepository.UpdateCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
                .Returns(cursoMock);

            // When
            await _useCase.DeleteCursoAsync(cursoMock, default);

            // Then
            //await Assert.ThrowsAsync<NullReferenceException>(() => _useCase.DeleteAsync(CursoMock, default));
            await _cursoRepository.Received().ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());
            await _cursoRepository.Received().UpdateCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());

        }




        [Fact]
        public async Task UpdateAsyncCursoComSucesso()
        {
            // Given
            var cursoMock = CursoMock.GenerateMock();
            cursoMock.Status = Bussiness.Enum.eStatusCurso.Desativado;

            _cursoRepository.ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
              .Returns(cursoMock);

            _cursoRepository.UpdateCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
                .Returns(cursoMock);

            // When
            await _useCase.UpdateCursoAsync(cursoMock, default);

            // Then
            //await Assert.ThrowsAsync<NullReferenceException>(() => _useCase.DeleteAsync(CursoMock, default));
            await _cursoRepository.Received().ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());
            await _cursoRepository.Received().UpdateCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());

        }


        [Fact]
        public async Task UpdateAsyncCursoNaoExiste()
        {
            // Given
            var cursoMock = CursoMock.GenerateMock();

            _cursoRepository.ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
              .Returns(cursoMock);

            _cursoRepository.UpdateCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>())
                .Returns(cursoMock);

            // When
            // await _useCase.DeleteAsync(CursoMock, default);

            // Then
            await Assert.ThrowsAsync<ArgumentNullException>(() => _useCase.UpdateCursoAsync(cursoMock, default));
            await _cursoRepository.Received().ObterCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());
            await _cursoRepository.DidNotReceive().UpdateCursoAsync(Arg.Any<Curso>(), Arg.Any<CancellationToken>());

        }




    }
}
