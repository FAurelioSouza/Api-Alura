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
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _EnderecoService;

        public EnderecoController(EnderecoService service)
        {
            _EnderecoService = service;
        }

        [HttpPost]
        public IActionResult CreateEndereco([FromBody] CreateEndereco Endereco)
        {
            ReadEndereco endereco = _EnderecoService.CreateEndereco(Endereco);
            return CreatedAtAction(nameof(ReturnEnderecoId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IActionResult ReturnEndereco()
        {
            return Ok(_EnderecoService.ReturnEndereco());
        }

        [HttpGet("{id}")]
        public IActionResult ReturnEnderecoId(int id)
        {
            try
            {
                ReadEndereco endereco = _EnderecoService.ReturnEnderecoId(id);
                if (endereco != null) return Ok(endereco);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEndereco(int id, [FromBody] UpdateEndereco Endereco)
        {
            try
            {
                Result retorno = _EnderecoService.UpdateEndereco(id, Endereco);
                if (retorno.IsFailed) return NoContent();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.ToString());
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            try
            {
                Result retorno = _EnderecoService.DeleteEndereco(id);
                if (retorno.IsFailed) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.ToString());
            }
        }
    }
}
