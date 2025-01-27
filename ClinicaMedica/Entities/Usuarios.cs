using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.Entities
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; } // Usar byte[] para almacenar el hash

        [Required]
        public byte[] PasswordSalt { get; set; } // Usar byte[] para almacenar el salt

        [Required]
        public DateTime FechaCreacion { get; set; }

        // Rol o nivel de acceso
        [Required]
        [MaxLength(20)]
        public string Rol { get; set; } // Ejemplo: "Admin", "Usuario", "Medico", etc.
    }
}
