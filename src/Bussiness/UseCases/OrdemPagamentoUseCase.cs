using Bussiness.Entidades;
using Bussiness.Interfaces.Services;
using Bussiness.Interfaces.UseCases;

namespace Bussiness.UseCases
{
    public class OrdemPagamentoUseCase : IOrdemPagamentoUseCase
    {
        private readonly IPagamentoService _pagamentoService;

        public OrdemPagamentoUseCase(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        public async Task Executar(Matricula matricula, CancellationToken cancellationToken, Guid CorrelationID)
        {
            try
            {
                await _pagamentoService.SolicitarPagamentoAsync(matricula);
            }
            catch (Exception)
            {

            }

          
        }
    }
}