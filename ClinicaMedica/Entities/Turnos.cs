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

        // Propiedades de navegacion
        [ForeignKey(nameof(HorarioId))]
        public Horarios Horario { get; set; }

        [ForeignKey(nameof(MedicoId))]
        public Medicos Medico { get; set; }

        [ForeignKey(nameof(PacienteId))]
        public Pacientes Paciente { get; set; }
    }
}
