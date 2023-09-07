using AutoMapper;
using Bussiness.DTOs;
using Bussiness.Entidades;

namespace Application.Configs
{
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs()
        {
            CreateMap<Aluno, ObterRequestAlunoDto>()
            .ReverseMap();
            CreateMap<Aluno, ObterResponseAlunoDto>()
            .ReverseMap();
        }
    }
}