using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Entidades;

namespace Bussiness.Interfaces.UseCases.Services.AlunoServices
{
    public interface IAlunoServices
    {
        Task<Aluno> InsertAsync(Aluno aluno, CancellationToken cancellationToken);
        Task<Aluno> ObterAlunoAsync(Aluno aluno, CancellationToken cancellationToken);
        Task<ICollection<Aluno>> ObterAlunosAsync(CancellationToken cancellationToken);
    }
}