using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Request;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signManage;

        public LoginService(SignInManager<IdentityUser<int>> signManage)
        {
            _signManage = signManage;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultado = _signManage
                            .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultado.Result.Succeeded)
            {

                return Result.Ok();
            }
            return Result.Fail("Login Falhou");
        }
    }
}
