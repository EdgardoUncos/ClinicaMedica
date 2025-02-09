using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Model.DTOs.Create
{
    public class DetalleCitasCreacionDTO
    {
        [Required]
        public int CitaMedicaId { get; set; }
        [Required]
        public int ServicioId { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
}
