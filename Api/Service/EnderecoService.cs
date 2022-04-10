using Api.Models;
using Api.Repository;
using AutoMapper;
using FluentResults;

namespace Api.Service
{
    public class EnderecoService
    {
        private FilmeRepository _Repo;
        private IMapper _Mapp;

        public EnderecoService(FilmeRepository repo, IMapper mapp)
        {
            _Repo = repo;
            _Mapp = mapp;
        }

        public ReadEndereco CreateEndereco(CreateEndereco Endereco)
        {
            EnderecoModel endereco = _Mapp.Map<EnderecoModel>(Endereco);
            _Repo.Enderecos.Add(endereco);
            _Repo.SaveChanges();
            return _Mapp.Map<ReadEndereco>(endereco);

        }

        public List<ReadEndereco> ReturnEndereco()
        {
            return _Mapp.Map<List<ReadEndereco>>(_Repo.Enderecos);
        }

        public ReadEndereco ReturnEnderecoId(int id)
        {
            EnderecoModel endereco = _Repo.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null) return _Mapp.Map<ReadEndereco>(endereco);
            return null;

        }

        public Result UpdateEndereco(int id, UpdateEndereco Endereco)
        {
            EnderecoModel endereco = _Repo.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não encontrado");
            }
            _Mapp.Map(Endereco, endereco);
            _Repo.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteEndereco(int id)
        {
            EnderecoModel endereco = _Repo.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não encontrado");
            }
            _Repo.Remove(endereco);
            _Repo.SaveChanges();
            return Result.Ok();
        }
    }
}
