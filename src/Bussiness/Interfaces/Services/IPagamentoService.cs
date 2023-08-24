using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Entidades;

namespace Bussiness.Interfaces.Services
{
    public interface IPagamentoService
    {
        Task SolicitarPagamentoAsync(Aluno aluno,Curso curso);

        Task ReceberPagamentoAsync(HttpClient httpClient);
    }
}