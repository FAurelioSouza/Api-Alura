using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilme, FilmeModel>();
            CreateMap<FilmeModel, ReadFilme>();
            CreateMap<UpdateFilme, FilmeModel>();
        }
    }
}
