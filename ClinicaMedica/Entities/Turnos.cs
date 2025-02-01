using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.Entities
{
    public class Turnos
    {
        [Key]
        public int TurnoId { get; set; }

        public int HorarioId { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        public bool Asistencia { get; set; }

        // Propiedades de navegación (sin [ForeignKey])
        public Horarios Horario { get; set; }
        public Medicos Medico { get; set; }
        public Pacientes Paciente { get; set; }
    }
}
