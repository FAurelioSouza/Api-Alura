using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Models
{
    public class GerenteModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual List<CinemaModel> Cinemas{ get; set; }
        public int CinemaId { get; set; }
    }
}
