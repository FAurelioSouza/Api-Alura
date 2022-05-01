using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Request;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        private LoginService _loginService;


        [HttpPost]
        public IActionResult logaUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogaUsuario(request);
            if (resultado.IsFailed) return Unauthorized();
            return Ok();
        }
    }
}
