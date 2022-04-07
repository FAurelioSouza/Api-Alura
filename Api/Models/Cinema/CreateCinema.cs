using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class CreateCinema
    {
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
