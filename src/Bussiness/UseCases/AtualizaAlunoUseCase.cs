using AutoMapper;
using Bussiness.DTOs;
using Bussiness.Entidades;
using Bussiness.Interfaces.Services;
using Bussiness.Interfaces.UseCases;

namespace Bussiness.UseCases
{
    public class AtualizaAlunoUseCase : IAtualizaAlunoUseCase
    {
        private readonly IAlunoServices _alunoService;
        private readonly IMapper _mappper;


        public AtualizaAlunoUseCase(IAlunoServices alunoService, IMapper mappper)
        {
            _alunoService = alunoService;
            _mappper = mappper;
        }

        public async Task Execute(Aluno aluno, CancellationToken cancellationToken, Guid correlationId)
        {
            try
            {
                var alunoConsultado = await _alunoService.ObterAlunoAsync(aluno, cancellationToken);
                if (alunoConsultado is null)
                    return;
                    
                _mappper.Map<ResponseAlunoDto>(await _alunoService.UpdateAsync(aluno, cancellationToken));
            }
            catch (Exception)
            {
                throw;
            }

            await Task.CompletedTask;
        }
    }
}