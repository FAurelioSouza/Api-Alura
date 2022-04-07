using Api.Models;
using Api.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private FilmeRepository _Repo;
        private IMapper _Mapp;

        public CinemaController(FilmeRepository repo, IMapper mapp)
        {
            _Repo = repo;
            _Mapp = mapp;
        }

        [HttpPost]
        public IActionResult CreateCinema([FromBody] CreateCinema Cinema)
        {
            CinemaModel cinema = _Mapp.Map<CinemaModel>(Cinema);
            _Repo.Cinemas.Add(cinema);
            _Repo.SaveChanges();
            return CreatedAtAction(nameof(ReturnCinemaId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult ReturnCinema()
        {
            return Ok(_Repo.Cinemas);
        }

        [HttpGet("{id}")]
        public IActionResult ReturnCinemaId(int id)
        {
            try
            {
                CinemaModel cinema = _Repo.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
                if (cinema != null)
                {
                    ReadCinema returnCinema = _Mapp.Map<ReadCinema>(cinema);
                    return Ok(returnCinema);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinema(int id, [FromBody] UpdateCinema Cinema)
        {
            try
            {
                CinemaModel cinema = _Repo.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
                if (cinema == null)
                {
                    return NotFound();
                }

                _Mapp.Map(Cinema, cinema);

                _Repo.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.ToString());
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            try
            {
                CinemaModel cinema = _Repo.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
                if (cinema == null)
                {
                    return NotFound();
                }
                _Repo.Remove(cinema);
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
