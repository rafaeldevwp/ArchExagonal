using AutoMapper;
using Bussiness.DTOs;
using Bussiness.Entidades;
using Bussiness.Enum;
using Bussiness.Interfaces.Services;
using Bussiness.Interfaces.UseCases;

namespace Bussiness.UseCases
{
    public class DeleteAlunoUseCase : IDeleteAlunoUseCase
    {
        private readonly IAlunoServices _alunoService;
        private readonly IMapper _mapper;

        public DeleteAlunoUseCase(IAlunoServices alunoService, IMapper mapper)
        {
            _alunoService = alunoService;
            _mapper = mapper;
        }

        public async Task Execute(Aluno aluno, CancellationToken cancellationToken, Guid correlationId)
        {
            try
            {
                var alunoRecuperado = await _alunoService.ObterAlunoAsync(aluno, cancellationToken);

                if (alunoRecuperado is null)
                    return;

                if (alunoRecuperado.Status.Equals((int)eStatusAluno.Desativado))
                    return;

                alunoRecuperado.Status = eStatusAluno.Desativado;
                var alunoDesativado = await _alunoService.UpdateAsync(alunoRecuperado, cancellationToken);

                _mapper.Map<ResponseAlunoDto>(alunoDesativado);

            }
            catch (Exception)
            {
                throw;
            }

            await Task.CompletedTask;
        }
    }
}