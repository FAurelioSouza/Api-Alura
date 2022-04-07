using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinema, CinemaModel>();
            CreateMap<CinemaModel, ReadCinema>();
            CreateMap<UpdateCinema, CinemaModel>();
        }
    }
}
