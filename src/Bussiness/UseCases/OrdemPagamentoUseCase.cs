using Bussiness.Entidades;
using Bussiness.Interfaces.Services;
using Bussiness.Interfaces.UseCases;


namespace Bussiness.UseCases
{
    public class OrdemPagamentoUseCase : IOrdemPagamentoUseCase
    {
        private readonly IPagamentoService _pagamentoService;
        private readonly ICursoService _cursoService;
        private readonly IMatriculaService _matriculaService;

        public OrdemPagamentoUseCase(IPagamentoService pagamentoService, ICursoService cursoService, IMatriculaService matriculaService)
        {
            _pagamentoService = pagamentoService;
            _cursoService = cursoService;
            _matriculaService = matriculaService;
        }

        public async Task Executar(Matricula matricula, CancellationToken cancellationToken, Guid CorrelationID)
        {
            try
            {
                await _pagamentoService.SolicitarPagamentoAsync(matricula,cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}