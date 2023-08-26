using Bussiness.Entidades;
using Bussiness.Interfaces.Services;

namespace Infra.Providers.PagSeguro
{
    public class PagSeguroProvider : IPagamentoService
    {
        public Task ReceberPagamentoAsync(HttpClient httpClient)
        {
            throw new NotImplementedException();
        }

        public async Task SolicitarPagamentoAsync(Matricula matricula)
        {
            throw new NotImplementedException();
        }
    }
}