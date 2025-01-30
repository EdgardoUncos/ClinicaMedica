using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.Entities
{
    public class Horarios : IValidatableObject
    {
        [Key]
        public int HorarioId { get; set; }
        [Column(TypeName = "time")]
        public  TimeSpan HorarioInicio { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan HorarioFin { get; set; }

        // Propiedades de navegación
        public ICollection<Turnos> Turnos { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HorarioInicio >= HorarioFin)
            {
                yield return new ValidationResult("El horario de inicio debe ser anterior al horario de fin.", new[] { nameof(HorarioInicio), nameof(HorarioFin) });
            }
        }
    }
}
