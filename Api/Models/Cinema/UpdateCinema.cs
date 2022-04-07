using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class UpdateCinema
    {
        public string Nome { get; set; }
        public virtual EnderecoModel Endereco { get; set; }
        public int EnderecoId { get; set; }
    }
}
