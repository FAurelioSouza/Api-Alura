 using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerente, GerenteModel>();
            CreateMap<GerenteModel, ReadGerente>();
            CreateMap<UpdateGerente, GerenteModel>();
        }
    }
}
