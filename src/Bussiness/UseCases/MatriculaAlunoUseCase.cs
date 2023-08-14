using Bussiness.Entidades;
using Bussiness.Interfaces.UseCases;
using Bussiness.Interfaces.UseCases.Services.AlunoServices;

namespace Bussiness.UseCases
{
    public class MatriculaAlunoUseCase : IMatriculaAlunoUseCase
    {
        private readonly IAlunoServices _alunoServices;

        public MatriculaAlunoUseCase(IAlunoServices alunoServices)
        {
            _alunoServices = alunoServices;
        }

        public async Task Execute(Aluno aluno, CancellationToken cancellationToken, Guid CorrelationId)
        {
            if (await _alunoServices.ObterAlunoAsync(aluno, cancellationToken) is null)
                await _alunoServices.InsertAsync(aluno,cancellationToken);
        }
    }
}