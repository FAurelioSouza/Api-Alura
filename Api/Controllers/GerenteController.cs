using Api.Models;
using Api.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private FilmeRepository _Repo;
        private IMapper _Mapp;

        public GerenteController(FilmeRepository repo, IMapper mapp)
        {
            _Repo = repo;
            _Mapp = mapp;
        }

        [HttpPost]
        public IActionResult CreateGerente([FromBody] CreateGerente NewGerente)
        {
            GerenteModel gerente = _Mapp.Map<GerenteModel>(NewGerente);
            _Repo.Gerentes.Add(gerente);
            _Repo.SaveChanges();
            return CreatedAtAction(nameof(GetGerenteId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet]
        public IActionResult retornaGerente()
        {
            return Ok(_Repo.Gerentes);
        }

        [HttpGet("{id}")]
        public IActionResult GetGerenteId(int id)
        {
            try
            {
                GerenteModel gerente = _Repo.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
                if (gerente != null)
                {
                    ReadGerente returnGerente = _Mapp.Map<ReadGerente>(gerente);
                    return Ok(returnGerente);
                }
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
            GerenteModel gerentes = _Repo.Gerentes.FirstOrDefault(gerentes => gerentes.Id == id);
            if (gerentes == null)
            {
                return NotFound();
            }

            _Mapp.Map(GerenteUpdate, gerentes);

            _Repo.SaveChanges();
            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGerente(int id)
        {
            GerenteModel gerente = _Repo.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }
            _Repo.Remove(gerente);
            _Repo.SaveChanges();
            return NoContent();
        }
    }
}