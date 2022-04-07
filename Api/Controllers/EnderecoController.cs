using Api.Models;
using Api.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private FilmeRepository _Repo;
        private IMapper _Mapp;

        public EnderecoController(FilmeRepository repo, IMapper mapp)
        {
            _Repo = repo; 
            _Mapp = mapp;
        }

        [HttpPost]
        public IActionResult CreateEndereco([FromBody] CreateEndereco Endereco)
        {
            EnderecoModel endereco = _Mapp.Map<EnderecoModel>(Endereco);
            _Repo.Enderecos.Add(endereco);
            _Repo.SaveChanges();
            return CreatedAtAction(nameof(ReturnEnderecoId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IActionResult ReturnCinema()
        {
            return Ok(_Repo.Enderecos);
        }

        [HttpGet("{id}")]
        public IActionResult ReturnEnderecoId(int id)
        {
            try
            {
                EnderecoModel endereco = _Repo.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
                if (endereco != null)
                {
                    ReadEndereco returnEndereco = _Mapp.Map<ReadEndereco>(endereco);
                    return Ok(returnEndereco);
                }
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
                EnderecoModel endereco = _Repo.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
                if (endereco == null)
                {
                    return NotFound();
                }

                _Mapp.Map(Endereco, endereco);

                _Repo.SaveChanges();
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
                EnderecoModel endereco = _Repo.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
                if (endereco == null)
                {
                    return NotFound();
                }
                _Repo.Remove(endereco);
                _Repo.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.ToString());
            }
        }
    }
}
