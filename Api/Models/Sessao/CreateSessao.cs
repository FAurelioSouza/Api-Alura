using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class CreateSessao
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }

    }
}
