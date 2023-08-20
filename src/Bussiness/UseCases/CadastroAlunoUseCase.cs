using AutoMapper;
using Bussiness.DTOs;
using Bussiness.Entidades;
using Bussiness.Interfaces.Services;
using Bussiness.Interfaces.UseCases;

namespace Bussiness.UseCases
{
    public class CadastroAlunoUseCase : ICadastroAlunoUseCase
    {
        private readonly IAlunoServices _alunoServices;
        private readonly IMapper _mapper;
        public CadastroAlunoUseCase(IAlunoServices alunoServices, IMapper mapper)
        {
            _alunoServices = alunoServices;
            _mapper = mapper;
        }

        public async Task Execute(Aluno aluno, CancellationToken cancellationToken, Guid correlationId)
        {
            if (await _alunoServices.ObterAlunoAsync(aluno, cancellationToken) is null)
            {
                _mapper.Map<ResponseAlunoDto>
                   (await _alunoServices.InsertAsync(aluno, cancellationToken));
            }
            else
            {
                _mapper.Map<ResponseAlunoDto>
                   (await _alunoServices.ObterAlunoAsync(aluno, cancellationToken));
            }

            await Task.CompletedTask;
        }
    }
}