using ClinicaMedica.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.DTOs.Create
{
    public class CitasMedicasCreacionDTO
    {
        [Required]
        public int PacienteId { get; set; }
        [Required]
        public int MedicoId { get; set; }

        public float Descuento { get; set; }
        public float Total { get; set; }

        // Relación con DetalleCitas
        public List<DetalleCitasCreacionDTO> DetalleCitas { get; set; }

    }
}
