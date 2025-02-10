using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicaMedica.Model.DTOs.Basic
{
    public class CitasMedicasDTO
    {
        [JsonPropertyName("citaMedicaId")]
        public int CitaMedicaId { get; set; }

        //Claves foraneas
        [JsonPropertyName("pacienteId")]
        public int PacienteId { get; set; }
        [JsonPropertyName("medicoId")]
        public int MedicoId { get; set; }
        [JsonPropertyName("descuento")]
        public float Descuento { get; set; }
        public float Total { get; set; }
        [JsonPropertyName("paciente")]
        public PacientesDTO? Paciente { get; set; }
        [JsonPropertyName("medico")]
        public MedicosDTO? Medico { get; set; }

        // Relación con DetalleCitas
        [JsonPropertyName("detalleCitas")]
        public List<DetalleCitasDTO>? DetalleCitas { get; set; }
    }
}
