using Bussiness.Entidades;
using Bussiness.Interfaces.UseCases;
using Bussiness.Interfaces.Services;
using Bussiness.Enum;
using AutoMapper;
using Bussiness.DTOs;

namespace Bussiness.UseCases
{
    public class MatriculaAlunoUseCase : IMatriculaAlunoUseCase
    {

        private readonly IMatriculaService _matriculaService;
        private readonly IAlunoServices _alunoService;
        private readonly IMapper _mapper;

        public MatriculaAlunoUseCase(IMatriculaService matriculaService, IAlunoServices alunoService, IMapper mapper)
        {
            _matriculaService = matriculaService;
            _alunoService = alunoService;
            _mapper = mapper;
        }

        public async Task Execute(Aluno aluno, Curso curso, CancellationToken cancellationToken, Guid CorrelationId)
        {
            try
            {
                var alunoRecuperado = await _alunoService.ObterAlunoAsync(aluno, cancellationToken);

                if (alunoRecuperado is null)
                    return;

                var matricula = await _matriculaService.ObterMatriculaAsync(alunoRecuperado, cancellationToken, CorrelationId);

                if (matricula is not null && matricula?.Status == eStatusMatricula.Ativa)
                    return;

                _mapper.Map<ResponseMatriculaDto>
                         (await _matriculaService.InsertAsync(alunoRecuperado, curso, cancellationToken, CorrelationId));
            }
            catch (Exception)
            {
                throw;
            }

            await Task.CompletedTask;
        }


    }
}