using Bussiness.Entidades;

namespace Bussiness.Interfaces.Services
{
    public interface IMatriculaService
    {
        Task<Matricula> InsertAsync(Aluno aluno,CancellationToken cancellationToken,Guid correlationId);
        Task<Matricula> ObterMatricula(Aluno aluno,CancellationToken cancellationToken,Guid correlationId);
        Task<List<Matricula>> ObterMatriculas();
    }
}