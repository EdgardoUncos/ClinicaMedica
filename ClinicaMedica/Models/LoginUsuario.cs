using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Models
{
    public class LoginUsuario
    {
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Password { get; set; }

        
    }
}
