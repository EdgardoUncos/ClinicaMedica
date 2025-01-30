using System.ComponentModel.DataAnnotations;


namespace ClinicaMedica.Model.DTOs.Create
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
