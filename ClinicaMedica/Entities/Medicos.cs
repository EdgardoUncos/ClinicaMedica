using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.Entities
{
    public class Medicos
    {
        [Key]
        public int MedicoId { get; set; }
        [Required]
        public int PersonaId { get; set; }
        [Required]
        public int EspecialidadId { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El sueldo debe ser un valor positivo.")]
        public float Sueldo { get; set;}

        // Propiedades de navegacion
        [ForeignKey(nameof(PersonaId))]
        public Personas Persona { get; set; }
        [ForeignKey(nameof(EspecialidadId))]
        public Especialidades Especialidades { get; set; }

        public ICollection<Turnos> Turnos { get; set; }
    }
}
