using Bussiness.Entidades;

namespace Bussiness.Interfaces.Services
{
    public interface IAlunoServices
    {
        Task<Aluno> InsertAsync(Aluno aluno, CancellationToken cancellationToken);
        Task<Aluno> ObterAlunoAsync(Aluno aluno, CancellationToken cancellationToken);
        Task<Aluno> ObterAlunoIdAsync(long Cpf, CancellationToken cancellationToken);
        Task<ICollection<Aluno>> ObterAlunosAsync(CancellationToken cancellationToken);
        Task<Aluno> UpdateAsync(Aluno aluno,CancellationToken cancellationToken);
        Task<Aluno> DeleteAsync(Aluno aluno,CancellationToken cancellationToken);
    }
}