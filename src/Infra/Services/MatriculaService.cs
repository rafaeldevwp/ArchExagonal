using Bussiness.Entidades;
using Bussiness.Interfaces.Services;

namespace Infra.Services.Matricula
{
    public class MatriculaService : IMatriculaService
    {
        public Task<Bussiness.Entidades.Matricula> InsertAsync(Aluno aluno, Curso curso, CancellationToken cancellationToken, Guid correlationId)
        {
            throw new NotImplementedException();
        }

        public Task<Bussiness.Entidades.Matricula> ObterMatriculaAsync(Aluno aluno, CancellationToken cancellationToken, Guid correlationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bussiness.Entidades.Matricula>> ObterMatriculasAsync()
        {
            throw new NotImplementedException();
        }
    }
}