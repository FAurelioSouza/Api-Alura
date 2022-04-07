using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEndereco, EnderecoModel>();
            CreateMap<EnderecoModel, ReadEndereco>();
            CreateMap<UpdateEndereco, EnderecoModel>();
        }
    }
}
