using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Entidades;
using Bussiness.Interfaces.Repository;

namespace Infra.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        public Task<Aluno> Deletesync(Aluno aluno, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> InsertAsync(Aluno aluno, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> ObterAlunoAsync(Aluno aluno, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Aluno>> ObterAlunosAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> UpdateAsync(Aluno aluno, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}