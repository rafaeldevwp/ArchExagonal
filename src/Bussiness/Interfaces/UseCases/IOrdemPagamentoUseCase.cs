using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Entidades;

namespace Bussiness.Interfaces.UseCases
{
    public interface IOrdemPagamentoUseCase
    {
        Task Executar(Aluno aluno,Curso curso,CancellationToken cancellationToken, Guid CorrelationID);
    }
}