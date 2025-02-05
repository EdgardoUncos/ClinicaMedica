using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.Entities
{
    public class Turnos
    {
        public int TurnoId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Asistencia { get; set; }
        public string Estado { get; set; } = "Disponible";
        public int? PacienteId { get; set; } // Clave foránea nullable
        public int HorarioId { get; set; }
        public int MedicoId { get; set; }

        // Propiedades de navegación (sin [ForeignKey])
        public Horarios Horario { get; set; }
        public Medicos Medico { get; set; }
        public Pacientes Paciente { get; set; }

    }

}
