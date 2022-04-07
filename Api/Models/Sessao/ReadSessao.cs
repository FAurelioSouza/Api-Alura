using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class ReadSessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual CinemaModel Cinema { get; set; }
        public virtual FilmeModel Filme { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }

    }
}
