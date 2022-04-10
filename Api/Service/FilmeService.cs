using Api.Models;
using Api.Repository;
using AutoMapper;
using FluentResults;

namespace Api.Service
{
    public class FilmeService
    {
        private FilmeRepository _Repo;
        private IMapper _Mapp;

        public FilmeService(FilmeRepository repo, IMapper mapp)
        {
            _Repo = repo;
            _Mapp = mapp;
        }

        public ReadFilme CreateFilme(CreateFilme newFilme)
        {
            FilmeModel filme = _Mapp.Map<FilmeModel>(newFilme);
            _Repo.Filmes.Add(filme);
            _Repo.SaveChanges();
            return _Mapp.Map<ReadFilme>(filme);
        }

        public ReadFilme GetFilmeId(int id)
        {
            FilmeModel filme = _Repo.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
                return _Mapp.Map<ReadFilme>(filme);

            return null;
        }

        public List<ReadFilme> RetornaFilme()
        {
            return _Mapp.Map<List<ReadFilme>>(_Repo.Filmes);
        }

        public Result UpdateFilme(int id, UpdateFilme FilmeUpdate)
        {
            FilmeModel filme = _Repo.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não encontrado.");
            }

            _Mapp.Map(FilmeUpdate, filme);
            _Repo.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteFilme(int id)
        {
            FilmeModel filme = _Repo.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _Repo.Remove(filme);
            _Repo.SaveChanges();
            return Result.Ok();
        }
    }
}
