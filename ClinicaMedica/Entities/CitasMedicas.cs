using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.Entities
{
    public class CitasMedicas
    {
        public int CitaMedicaId { get; set; }

        // Claves foráneas (pueden ser null si es necesario)
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }

        public float Descuento { get; set; }
        public float Total { get; set; }

        // Propiedades de navegación
        public Pacientes Paciente { get; set; }
        public Medicos Medico { get; set; }

        // Relación con DetalleCitas
        public ICollection<DetalleCitas> DetalleCitas { get; set; }
    }

}
