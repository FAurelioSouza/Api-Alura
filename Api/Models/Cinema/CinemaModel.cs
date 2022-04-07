using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Models
{
    public class CinemaModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do cinema é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Id do endereço é obrigatório")]
        public int EnderecoId { get; set; }
        [JsonIgnore]
        public virtual EnderecoModel Endereco { get; set; }

        [JsonIgnore]
        public virtual GerenteModel Gerente { get; set; }

        [Required(ErrorMessage = "Id do Gerente é obrigatório")]
        public int GerenteId { get; set; }

        [JsonIgnore]
        public virtual List<SessaoModel> Sessoes { get; set; }
    }
}
