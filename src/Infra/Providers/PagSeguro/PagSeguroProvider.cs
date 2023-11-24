using Bussiness.Entidades;
using Bussiness.Interfaces.Providers;
using Bussiness.Interfaces.Services;
using Infra.Providers.Configs;
using Infra.Providers.PagSeguro.Model;

namespace Infra.Providers.PagSeguro
{

    public class PagSeguroProvider : IPagamentoService
    {
        private readonly IHttpService _httpService;
        private readonly IMatriculaService _matriculaService;
        private readonly IPagSeguroProviderSettings _pagSeguroProviderSettings;


        public PagSeguroProvider(IHttpService httpService, IMatriculaService matriculaService, IPagSeguroProviderSettings pagSeguroProviderSettings)
        {
            _httpService = httpService;
            _matriculaService = matriculaService;
            _pagSeguroProviderSettings = pagSeguroProviderSettings;
        }

        public Task ReceberPagamentoAsync(HttpClient httpClient, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SolicitarPagamentoAsync(Matricula matricula, CancellationToken cancellationToken)
        {
                var listaCursos = await _matriculaService.ObterMatriculasAsync(cancellationToken);
                var matriculasPendentes = listaCursos.Where(c => c.Status == Bussiness.Enum.eStatusMatricula.PendentePagamento);

                matriculasPendentes.ToList().ForEach(data =>
                {
                    new PaymentRequest
                    {
                        ItemId1 = data.Curso.CursoId.ToString(),
                        ItemDescription1 = data.Curso.Nome,
                        SenderName = data.Aluno.Nome,
                        ItemAmount1 = data.Curso.Preco.ToString()
                    };

                    _httpService.authParameter.Token = _pagSeguroProviderSettings.Token;
                    _httpService.PutJsonAsync<PaymentRequest>(_pagSeguroProviderSettings.BaseUrl, data);

                });
            }

        }
    
}