using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.Entities
{
    public class CitasMedicas
    {
        [Key]
        public int CitaMedicaId { get; set; }

        //Claves foraneas
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }

        public float Descuento { get; set; }
        public float Total { get; set; }

        [ForeignKey(nameof(PacienteId))]
        public Pacientes Paciente {  get; set; }
        [ForeignKey(nameof(MedicoId))]
        public Medicos Medicos { get; set; }

        // Relación con DetalleCitas
        public ICollection<DetalleCitas> DetalleCitas { get; set; }

    }
}
