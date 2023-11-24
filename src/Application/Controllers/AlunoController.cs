using Application.Dtos;
using AutoMapper;
using Bussiness.DTOs;
using Bussiness.Entidades;
using Bussiness.Interfaces.Repository;
using Bussiness.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAlunoServices _alunoServices;
        private readonly CancellationToken cancellationToken;

        public AlunoController(IMapper mapper, IAlunoServices alunoServices)
        {
            _mapper = mapper;
            _alunoServices = alunoServices;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAluno([FromQuery] RequestAlunoDto request)
        {
            if (request is null) return BadRequest();

            _mapper.Map<ObterRequestAlunoDto>(request);

            return Ok();
        }

        [HttpGet("ObterAlunos")]
        public async Task<IEnumerable<Aluno>> ObterAlunos()
        {
            return new List<Aluno>()
            {
                new Aluno{  AlunoId =  Guid.NewGuid() ,
                            CPF = "41950673081",
                            Endereco = new Endereco{ EnderecoId = Guid.NewGuid(), Bairro = "Sao Genaro"},
                            Idade = 32 ,
                            Nome = "Rafael",
                            Status = Bussiness.Enum.eStatusAluno.Ativo},

                 new Aluno{  AlunoId =  Guid.NewGuid() ,
                            CPF = "41950673081",
                            Endereco = new Endereco{ EnderecoId = Guid.NewGuid(), Bairro = "Sao Genaro"},
                            Idade = 32 ,
                            Nome = "Rafael",
                            Status = Bussiness.Enum.eStatusAluno.Ativo}

            };
        }


        [HttpGet("ObterAlunoId/{id}")]
        public async Task<Aluno> ObterAlunoId(int id)
        {

                    if (id == 1)
                    {
                        return new Aluno
                        {
                            AlunoId = Guid.NewGuid(),
                            CPF = "41950673081",
                            Endereco = new Endereco { EnderecoId = Guid.NewGuid(), Bairro = "Sao Genaro" },
                            Idade = 32,
                            Nome = "Rafael",
                            Status = Bussiness.Enum.eStatusAluno.Ativo
                        };
                    }
                    else
                        return new Aluno();
        }


    }
}