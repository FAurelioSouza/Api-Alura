using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessao, SessaoModel>();
            CreateMap<SessaoModel, ReadSessao>()
                .ForMember(Read => Read.HorarioDeInicio, Read => Read
                .MapFrom(Read => Read.HorarioDeEncerramento
                .AddMinutes(Read.Filme.Duracao * (-1))));
            //CreateMap<UpdateFilme, SessaoModel>();
        }
    }
}
