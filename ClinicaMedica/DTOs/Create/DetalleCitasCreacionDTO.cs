using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.DTOs.Create
{
    public class DetalleCitasCreacionDTO
    {
        [Required]
        public int CitaMedicaId { get; set; }
        [Required]
        public int ServicioId { get; set; }
    }
}
