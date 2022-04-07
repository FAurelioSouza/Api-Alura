using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class ReadGerente
    {
        public int Id { get; set; }   
        public string Nome { get; set; }
        public List<ReadCinema> Cinemas { get; set; }
    }
}
