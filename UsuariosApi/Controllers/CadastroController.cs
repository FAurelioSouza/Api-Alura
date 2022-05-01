using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Models.Usuario;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService CadastroService)
        {
            _cadastroService = CadastroService;
        }

        [HttpPost]
        public IActionResult CadastroUsuario([FromBody]CreateUsuario newUsuario)
        {
            Result resultado = _cadastroService.CadastroUsuario(newUsuario);
            if (resultado.IsFailed) return StatusCode(500, resultado);
            return Ok();
        }
    }
}
