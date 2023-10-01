using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Entidades;

namespace Bussiness.Interfaces.Services
{
    public interface IPagamentoService
    {
        Task SolicitarPagamentoAsync(Matricula matricula,CancellationToken cancellationToken);

        Task ReceberPagamentoAsync(HttpClient httpClient, CancellationToken cancellationToken);
    }
}