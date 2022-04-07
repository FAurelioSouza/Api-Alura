using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Models
{
    public class FilmeModel
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        [Required(ErrorMessage = "O Titulo é obrigatório.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O Diretor é obrigatório.")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage ="O gênero deve ter bo máximo 30 caracteres.")]
        public string Genero { get; set; }

        [Range(40, 240, ErrorMessage = "A duração deve ter entre 40 a 240 minutos.")]
        public int Duracao { get; set; }
        [JsonIgnore]
        public virtual List<SessaoModel> Sessoes { get; set; }
    }
}

