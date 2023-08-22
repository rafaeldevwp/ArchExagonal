using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bussiness.Interfaces.Services
{
    public interface IOrdemPagamento
    {
        Task SolicitarPagamento(double Valor);
    }
}