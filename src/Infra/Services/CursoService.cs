using Bussiness.Entidades;
using Bussiness.Interfaces.Repository;
using Bussiness.Interfaces.Services;

namespace Infra.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<Curso> DeleteCursoAsync(Curso curso, CancellationToken cancellationToken)
        {
            var cursoRecuperado = await _cursoRepository.ObterCursoAsync(curso, cancellationToken);

            if (cursoRecuperado == null || cursoRecuperado.Status == Bussiness.Enum.eStatusCurso.Desativado)
                throw new ArgumentNullException();

            cursoRecuperado.Status = Bussiness.Enum.eStatusCurso.Desativado;

            return await _cursoRepository.UpdateCursoAsync(cursoRecuperado, cancellationToken);
        }

        public async Task<Curso> InsertAsync(Curso curso, CancellationToken cancellationToken)
        {
            var existeCurso = await _cursoRepository.ObterCursoAsync(curso, cancellationToken);

            if (existeCurso != null || existeCurso?.Status == Bussiness.Enum.eStatusCurso.Ativo)
                throw new ArgumentNullException();

            return await _cursoRepository.InsertAsync(curso, cancellationToken);
        }

        public async  Task<Curso> ObterCursoAsync(Curso curso, CancellationToken cancellationToken)
        {
          return await _cursoRepository.ObterCursoAsync(curso, cancellationToken);
        }

        public async Task<ICollection<Curso>> ObterCursosAsync(CancellationToken cancellationToken)
        {
             return await _cursoRepository.ObterCursosAsync(cancellationToken);
        }

        public async Task<Curso> UpdateCursoAsync(Curso curso, CancellationToken cancellationToken)
        {
            var cursoConsulta = await _cursoRepository.ObterCursoAsync(curso, cancellationToken);

            if (cursoConsulta == null)
                throw new NullReferenceException();

            return await _cursoRepository.UpdateCursoAsync(curso, cancellationToken);
        }
    }
}