using Api.Models;
using Api.Repository;
using AutoMapper;
using FluentResults;

namespace Api.Service
{
    public class CinemaService
    {
        private FilmeRepository _Repo;
        private IMapper _Mapp;

        public CinemaService(FilmeRepository repo, IMapper mapp)
        {
            _Repo = repo;
            _Mapp = mapp;
        }

        public ReadCinema CreateCinema(CreateCinema newCinema)
        {
            CinemaModel cinema = _Mapp.Map<CinemaModel>(newCinema);
            _Repo.Cinemas.Add(cinema);
            _Repo.SaveChanges();
            return _Mapp.Map<ReadCinema>(cinema);
        }

        public ReadCinema GetCinemaId(int id)
        {
            CinemaModel cinema = _Repo.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
                return _Mapp.Map<ReadCinema>(cinema);

            return null;
        }

        public List<ReadCinema> RetornaCinema()
        {
            return _Mapp.Map<List<ReadCinema>>(_Repo.Cinemas);
        }

        public Result UpdateCinema(int id, UpdateCinema CinemaUpdate)
        {
            CinemaModel cinema = _Repo.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Filme não encontrado.");
            }

            _Mapp.Map(CinemaUpdate, cinema);
            _Repo.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteCinema(int id)
        {
            CinemaModel cinema = _Repo.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _Repo.Remove(cinema);
            _Repo.SaveChanges();
            return Result.Ok();
        }
    }
}
