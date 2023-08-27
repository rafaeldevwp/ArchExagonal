using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Entidades;
using Bussiness.Interfaces.Repository;

namespace Infra.Repository
{
    public class CursoRepository : ICursoRepository
    {
        public Task<Curso> DeleteCursoAsync(Curso curso, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Curso> InsertAsync(Curso curso, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Curso> ObterCursoAsync(Curso curso, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Curso>> ObterCursosAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Curso> UpdateCursoAsync(Curso curso, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}