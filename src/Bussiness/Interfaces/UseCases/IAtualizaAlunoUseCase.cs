using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Entidades;

namespace Bussiness.Interfaces.UseCases
{
    public interface IAtualizaAlunoUseCase
    {
         Task Execute(Aluno aluno,CancellationToken cancellationToken,Guid correlationId);
    }
}