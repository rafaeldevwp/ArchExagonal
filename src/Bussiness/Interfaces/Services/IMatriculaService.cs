using Bussiness.Entidades;

namespace Bussiness.Interfaces.Services
{
    public interface IMatriculaService
    {
        Task<Matricula> InsertAsync(Matricula matricula,CancellationToken cancellationToken,Guid correlationId);
        Task<Matricula> ObterMatriculaAsync(Aluno aluno,CancellationToken cancellationToken,Guid correlationId);
        Task<List<Matricula>> ObterMatriculasAsync(CancellationToken cancellationToken);

        Task<List<Matricula>> ObterMatriculasAsync();
    }
}