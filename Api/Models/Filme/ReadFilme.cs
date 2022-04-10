using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class ReadFilme
    {
        public int Id { get; set; } 
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }

        public DateTime HoraConsulta = DateTime.Now;
    }
}

