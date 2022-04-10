using Api.Models;
using Api.Repository;
using AutoMapper;
using FluentResults;

namespace Api.Service
{
    public class GerenteService
    {
        private FilmeRepository _Repo;
        private IMapper _Mapp;

        public GerenteService(FilmeRepository repo, IMapper mapp)
        {
            _Repo = repo;
            _Mapp = mapp;
        }

        public ReadGerente CreateGerente(CreateGerente newGerente)
        {
            GerenteModel gerente = _Mapp.Map<GerenteModel>(newGerente);
            _Repo.Gerentes.Add(gerente);
            _Repo.SaveChanges();
            return _Mapp.Map<ReadGerente>(gerente);
        }

        public List<ReadGerente> retornaGerente()
        {
            return _Mapp.Map<List<ReadGerente>>(_Repo.Gerentes);
        }

        public ReadGerente GetGerenteId(int id)
        {
            GerenteModel gerente = _Repo.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerente returnGerente = _Mapp.Map<ReadGerente>(gerente);
                return returnGerente;
            }
            return null;
        }

        public Result UpdateGerente(int id, UpdateGerente gerenteUpdate)
        {
            GerenteModel gerentes = _Repo.Gerentes.FirstOrDefault(gerentes => gerentes.Id == id);
            if (gerentes == null) return Result.Fail("Gerente não encontrado.");

            _Mapp.Map(gerenteUpdate, gerentes);
            _Repo.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteGerente(int id)
        {
            GerenteModel gerente = _Repo.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return Result.Fail("Gerente não encoontrado.");
            }
            _Repo.Remove(gerente);
            _Repo.SaveChanges();
            return Result.Ok();
        }
    }
}
