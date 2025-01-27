using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Entities
{
    public class Personas
    {
        [Key] 
        public int PersonaId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El nombre no debe exceder los 50 caracteres.")]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El apellido no debe exceder los 50 caracteres.")]
        public string Apellido { get; set; }
        [Required]
        [Range(1, 99999999, ErrorMessage = "El DNI debe ser un número válido entre 1 y 99,999,999.")]
        public int Dni { get; set; }
        [MaxLength(20, ErrorMessage = "El número de teléfono no debe exceder los 20 caracteres.")]
        [RegularExpression(@"^\+?[0-9\s]*$", ErrorMessage = "El número de teléfono solo puede contener números y espacios, con un prefijo opcional '+'.")]
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
