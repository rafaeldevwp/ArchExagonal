using Bussiness.Entidades;
using Bussiness.Interfaces.Providers;
using Bussiness.Interfaces.Services;

namespace Infra.Providers.PagSeguro
{
   
    public class PagSeguroProvider : IPagamentoService
    {
         private readonly IHttpService _httpService;

        public PagSeguroProvider(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task ReceberPagamentoAsync(HttpClient httpClient)
        {
            throw new NotImplementedException();
        }

        public Task SolicitarPagamentoAsync(Matricula matricula)
        {
           throw new NotImplementedException();
        }
    }
 }