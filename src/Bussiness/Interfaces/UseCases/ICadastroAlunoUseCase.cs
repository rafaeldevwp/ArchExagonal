using Bussiness.Entidades;

namespace Bussiness.Interfaces.UseCases
{
    interface ICadastroAlunoUseCase
    {
        Task Execute(Aluno aluno,CancellationToken cancellationToken,Guid correlationId);
    }
}