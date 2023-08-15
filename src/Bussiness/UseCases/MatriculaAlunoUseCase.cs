using Bussiness.Entidades;
using Bussiness.Interfaces.UseCases;
using Bussiness.Interfaces.Services;

namespace Bussiness.UseCases
{
    public class MatriculaAlunoUseCase : IMatriculaAlunoUseCase
    {
        
        private readonly IMatriculaService _matriculaService;

        public MatriculaAlunoUseCase( IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        public async Task Execute(Aluno aluno, CancellationToken cancellationToken, Guid CorrelationId)
        {
            if(await _matriculaService.ObterMatricula(aluno,cancellationToken,CorrelationId) is null)
                await _matriculaService.InsertAsync(aluno,cancellationToken,CorrelationId);
        }
    }
}