using Bussiness.Entidades;
using Bussiness.Enum;
using Bussiness.Interfaces.Repository;
using Bussiness.Interfaces.Services;

namespace Infra.Services.AlunoServices
{
    public class AlunoServices : IAlunoServices
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoServices(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<Aluno> DeleteAsync(Aluno aluno, CancellationToken cancellationToken)
        {
            var alunoRecuperado = await _alunoRepository.ObterAlunoAsync(aluno, cancellationToken);

            if (alunoRecuperado == null || alunoRecuperado.Status == eStatusAluno.Desativado)
                throw new NullReferenceException();

            alunoRecuperado.Status = eStatusAluno.Desativado;
            return await _alunoRepository.UpdateAsync(alunoRecuperado, cancellationToken);
        }

        public async Task<Aluno> InsertAsync(Aluno aluno, CancellationToken cancellationToken)
        {
            var existingAluno = await _alunoRepository.ObterAlunoAsync(aluno, cancellationToken);
            if (existingAluno == null)
                return await _alunoRepository.InsertAsync(aluno, cancellationToken);

            return existingAluno;
        }

        public async Task<Aluno> ObterAlunoAsync(Aluno aluno, CancellationToken cancellationToken)
        {
            return await _alunoRepository.ObterAlunoAsync(aluno, cancellationToken);
        }

        public async Task<ICollection<Aluno>> ObterAlunosAsync(CancellationToken cancellationToken)
        {
            return await _alunoRepository.ObterAlunosAsync(cancellationToken);
        }

        public async Task<Aluno> UpdateAsync(Aluno aluno, CancellationToken cancellationToken)
        {
            var alunoConsultado = await _alunoRepository.ObterAlunoAsync(aluno, cancellationToken);

            if (alunoConsultado == null)
                throw new NullReferenceException();

            return await _alunoRepository.UpdateAsync(aluno, cancellationToken);
        }
    }
}
