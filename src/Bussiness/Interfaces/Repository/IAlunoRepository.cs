using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Entidades;

namespace Bussiness.Interfaces.Repository
{
    public interface IAlunoRepository
    {
        Task<Aluno> InsertAsync(Aluno aluno, CancellationToken cancellationToken);
        Task<Aluno> ObterAlunoAsync(Aluno aluno, CancellationToken cancellationToken);
        Task<ICollection<Aluno>> ObterAlunosAsync(CancellationToken cancellationToken);
        Task<Aluno> UpdateAsync(Aluno aluno,CancellationToken cancellationToken);
        Task<Aluno> Deletesync(Aluno aluno,CancellationToken cancellationToken);

    }
}