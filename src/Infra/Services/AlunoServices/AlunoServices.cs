using Bussiness.Entidades;
using Bussiness.Interfaces.UseCases.Services.AlunoServices;

namespace Infra.Services.AlunoServices
{
    public class AlunoServices : IAlunoServices
    {
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
    }
}