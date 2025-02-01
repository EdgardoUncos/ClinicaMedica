using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.DTOs.Create
{
    public class UsuarioDTO
    {
        [Required]
        public string NombreUsuario { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        //Aqui se colocan todos los demas datos que tenga el usuario como nombres, direcciones, fechas, edad, estados etc
        [Required]
        public string Rol { get; set; } = string.Empty;
        
    }
}
