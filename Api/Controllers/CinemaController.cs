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
    public class CinemaController : ControllerBase
    {
        private CinemaService _CinemaService;
        public CinemaController(CinemaService service)
        {
            _CinemaService = service;
        }

        [HttpPost]
        public IActionResult CreateCinema([FromBody] CreateCinema Cinema)
        {
            ReadCinema cinema = _CinemaService.CreateCinema(Cinema);
            return CreatedAtAction(nameof(ReturnCinemaId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult ReturnCinema()
        {
            return Ok(_CinemaService.RetornaCinema());
        }

        [HttpGet("{id}")]
        public IActionResult ReturnCinemaId(int id)
        {
            try
            {
                ReadCinema cinema = _CinemaService.GetCinemaId(id);
                if (cinema != null) return Ok(cinema);
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
                Result resultado = _CinemaService.UpdateCinema(id, Cinema);
                if (resultado.IsFailed) return NoContent();
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
                Result resultado = _CinemaService.DeleteCinema(id);
                if (resultado.IsFailed) return NoContent();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.ToString());
            }
        }
    }
}
