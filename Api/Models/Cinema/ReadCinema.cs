using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Models
{
    public class ReadCinema
    {
        public string Nome { get; set; }

        public virtual EnderecoModel Endereco { get; set; }
        [JsonIgnore]
        public virtual GerenteModel Gerente { get; set; }
    }
}
