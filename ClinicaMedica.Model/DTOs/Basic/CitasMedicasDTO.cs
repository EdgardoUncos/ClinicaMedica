using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.Model.DTOs.Basic
{
    public class CitasMedicasDTO
    {
        public int CitaMedicaId { get; set; }

        //Claves foraneas
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }

        public float Descuento { get; set; }
        public float Total { get; set; }

        public PacientesDTO? Paciente { get; set; }
        public MedicosDTO? Medicos { get; set; }

        // Relación con DetalleCitas
        public List<DetalleCitasDTO>? DetalleCitas { get; set; }
    }
}
