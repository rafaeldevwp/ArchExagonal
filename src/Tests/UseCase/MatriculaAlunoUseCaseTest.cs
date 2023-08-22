using AutoMapper;
using Bussiness.Interfaces.Services;
using Bussiness.UseCases;
using NSubstitute;
using Tests.Mock.Entidades;

namespace Tests.UseCase
{
    public class MatriculaAlunoUseCaseTest
    {
        private readonly IMatriculaService _matriculaService;
        private readonly IAlunoServices _alunoService;
        private readonly IMapper _mapper;
        private readonly MatriculaAlunoUseCase _useCase;

        public MatriculaAlunoUseCaseTest()
        {
            _matriculaService = Substitute.For<IMatriculaService>();
            _alunoService = Substitute.For<IAlunoServices>();
            _mapper = Substitute.For<IMapper>();
            _useCase = new MatriculaAlunoUseCase(_matriculaService,_alunoService,_mapper);
        }

        [Fact]
        public async Task Executado_Comsuceso(){

            var alunoMock = AlunoMock.GetMock();
            
        }
    }
}