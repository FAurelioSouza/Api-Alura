using Api.Models;
using Api.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private FilmeRepository _Repo;
        private IMapper _Mapp;

        public SessaoController(FilmeRepository repo, IMapper mapp)
        {
            _Repo = repo;
            _Mapp = mapp;
        }

        [HttpPost]
        public IActionResult CreateSessao([FromBody] CreateSessao NewSessao)
        {
            SessaoModel sessao = _Mapp.Map<SessaoModel>(NewSessao);
            _Repo.Sessoes.Add(sessao);
            _Repo.SaveChanges();
            return CreatedAtAction(nameof(GetSessaoId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet]
        public IActionResult retornaFilme()
        {
            return Ok(_Repo.Sessoes);
        }

        [HttpGet("{id}")]
        public IActionResult GetSessaoId(int id)
        {
            try
            {
                SessaoModel sessao = _Repo.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
                if (sessao != null)
                {
                    ReadSessao returnSessao = _Mapp.Map<ReadSessao>(sessao);
                    return Ok(returnSessao);
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