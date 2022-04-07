using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Models
{
    public class EnderecoModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Logradouro é um campo obrigatório")]
        public string Logradouro { get; set; }
        
        [Required(ErrorMessage = "Bairro é um campo obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Numero é um campo obrigatório")]
        public int Numero { get; set; }

        [JsonIgnore]
        public virtual CinemaModel Cinema { get; set; }

    }
}
