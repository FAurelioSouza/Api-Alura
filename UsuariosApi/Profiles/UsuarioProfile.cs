using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Models.Usuario;

namespace UsuariosApi.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuario, UsuarioModel>();
            CreateMap<UsuarioModel, IdentityUser<int>>();
        }
    }
}
