using Api.Models;
using Api.Repository;
using Api.Service;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _FilmeService;

        public FilmeController(FilmeService service)
        {
            _FilmeService = service;
        }

        [HttpPost]
        public IActionResult CreateFilme([FromBody] CreateFilme NewFilme)
        {
            ReadFilme filme =  _FilmeService.CreateFilme(NewFilme);
            return CreatedAtAction(nameof(GetFilmeId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult retornaFilme()
        {
            return Ok(_FilmeService.RetornaFilme());
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmeId(int id)
        {
            try
            {
                ReadFilme filme = _FilmeService.GetFilmeId(id);
                if (filme != null) return Ok(filme);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest( error : ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilme(int id, [FromBody] UpdateFilme FilmeUpdate)
        {
            Result resultado = _FilmeService.UpdateFilme(id, FilmeUpdate);
            if (resultado.IsSuccess) return NoContent();
            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            Result Resultado = _FilmeService.DeleteFilme(id);
            if (Resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}