using Api.Models;
using Api.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeRepository _Repo;
        private IMapper _Mapp;

        public FilmeController(FilmeRepository repo, IMapper mapp)
        {
            _Repo = repo;
            _Mapp = mapp;
        }

        [HttpPost]
        public IActionResult CreateFilme([FromBody] CreateFilme NewFilme)
        {
            FilmeModel filme = _Mapp.Map<FilmeModel>(NewFilme);
            _Repo.Filmes.Add(filme);
            _Repo.SaveChanges();
            return CreatedAtAction(nameof(GetFilmeId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult retornaFilme()
        {
            return Ok(_Repo.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmeId(int id)
        {
            try
            {
                FilmeModel filme = _Repo.Filmes.FirstOrDefault(filme => filme.Id == id);
                if (filme != null)
                {
                    ReadFilme returnFilme = _Mapp.Map<ReadFilme>(filme);
                    return Ok(returnFilme);
                }
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
            FilmeModel filme = _Repo.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            _Mapp.Map(FilmeUpdate, filme);

            _Repo.SaveChanges();
            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            FilmeModel filme = _Repo.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _Repo.Remove(filme);
            _Repo.SaveChanges();
            return NoContent();
        }
    }
}