using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Model.DTOs.Create
{
    // Datos necesarios para la creacion de una especialidad.
    // Quitamos de EspecialidadesDTO todo lo que no se necesita para un post
    public class EspecialidadesCreacionDTO
    {
        [Required]
        [MaxLength(300, ErrorMessage = "El detalle de la especialidad no debe exceder los 300 caracteres.")]
        public string Detalle { get; set; }
    }
}
