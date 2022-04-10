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
    public class GerenteController : ControllerBase
    {
        private GerenteService _GerenteService;

        public GerenteController(GerenteService service)
        {
            _GerenteService = service;
        }

        [HttpPost]
        public IActionResult CreateGerente([FromBody] CreateGerente NewGerente)
        {
            ReadGerente gerente = _GerenteService.CreateGerente(NewGerente);
            return CreatedAtAction(nameof(GetGerenteId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet]
        public IActionResult retornaGerente()
        {
            return Ok(_GerenteService.retornaGerente());
        }

        [HttpGet("{id}")]
        public IActionResult GetGerenteId(int id)
        {
            try
            {
                ReadGerente gerente = _GerenteService.GetGerenteId(id);
                if (gerente != null) return Ok(gerente);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest( error : ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGerente(int id, [FromBody] UpdateGerente GerenteUpdate)
        {
            Result retorno = _GerenteService.UpdateGerente(id, GerenteUpdate);
            if(retorno.IsFailed) return NoContent();
            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGerente(int id)
        {
            Result retorno = _GerenteService.DeleteGerente(id);
            if (retorno.IsFailed) return NoContent();
            return NoContent();
        }
    }
}