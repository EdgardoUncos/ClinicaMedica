using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.DTOs.Create
{
    public class HorariosCreacionDTO
    {
        [Required]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$", ErrorMessage = "El formato debe ser hh:mm:ss")]
        public TimeSpan HorarioInicio { get; set; }
        [Required]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$", ErrorMessage = "El formato debe ser hh:mm:ss")]
        public TimeSpan HorarioFin { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (HorarioInicio >= HorarioFin)
        //    {
        //        yield return new ValidationResult("El horario de inicio debe ser anterior al horario de fin.", new[] { nameof(HorarioInicio), nameof(HorarioFin) });
        //    }
        //}
    }
}
