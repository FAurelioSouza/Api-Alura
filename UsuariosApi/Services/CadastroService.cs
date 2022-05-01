using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Models.Usuario;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private IMapper _mapp;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapp, UserManager<IdentityUser<int>> userManager)
        {
            _mapp = mapp;
            _userManager = userManager;
        }

        public Result CadastroUsuario(CreateUsuario newUsuario)
        {
            UsuarioModel usuario = _mapp.Map<UsuarioModel>(newUsuario);
            IdentityUser<int> usuarioIdentity = _mapp.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, newUsuario.Password);
            if (resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail(resultadoIdentity.Result.ToString());
        }
    }
}
