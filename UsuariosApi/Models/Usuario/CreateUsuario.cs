using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Models.Usuario
{
    public class CreateUsuario
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }

    }
}
