using Bussiness.Entidades;
using Bussiness.Interfaces.Services;

namespace Infra.Services.Matricula
{
    public class MatriculaService : IMatriculaService
    {
     
        public Task<Bussiness.Entidades.Matricula> InsertAsync(Aluno aluno, CancellationToken cancellationToken, Guid correlationId)
        {
            throw new NotImplementedException();
        }

 
        public Task<Bussiness.Entidades.Matricula> ObterMatricula(Aluno aluno, CancellationToken cancellationToken, Guid correlationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bussiness.Entidades.Matricula>> ObterMatriculas()
        {
            throw new NotImplementedException();
        }
    }
}