using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaMedica.Model.DTOs.Create
{
    public class HorariosCreacionDTO : IValidatableObject
    {
        [Required]
        public TimeSpan HorarioInicio { get; set; }
        [Required]
        public TimeSpan HorarioFin { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HorarioInicio >= HorarioFin)
            {
                yield return new ValidationResult("El horario de inicio debe ser anterior al horario de fin.", new[] { nameof(HorarioInicio), nameof(HorarioFin) });
            }
        }
    }
}
