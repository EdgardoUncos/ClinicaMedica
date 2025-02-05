using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.Entities
{
    public class Medicos
    {
        public int MedicoId { get; set; }
        public int PersonaId { get; set; }
        public int EspecialidadId { get; set; }
        public float Sueldo { get; set; }

        // Propiedades de navegación
        public Personas Persona { get; set; }
        public Especialidades Especialidad { get; set; }
        public ICollection<Turnos> Turnos { get; set; }
        public ICollection<CitasMedicas> CitasMedicas { get; set; }
    }
}
