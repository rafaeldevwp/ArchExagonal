using Bussiness.Entidades;

namespace Bussiness.Interfaces.Services
{
    public interface ICursoService
    {
        Task<Curso> InsertAsync(Curso curso, CancellationToken cancellationToken);
        Task<Curso> ObterCursoAsync(Curso curso, CancellationToken cancellationToken);
        Task<Curso> UpdateCursoAsync(Curso curso, CancellationToken cancellationToken);
        Task<Curso> DeleteCursoAsync(Curso curso, CancellationToken cancellationToken);
        Task<ICollection<Curso>> ObterCursosAsync(CancellationToken cancellationToken);
    }
}