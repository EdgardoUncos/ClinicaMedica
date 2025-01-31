using ClinicaMedica.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.DTOs.Basic
{
    public class HorariosDTO
    {
        public int HorarioId { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioFin { get; set; }

        // Propiedades de navegación
        //public ICollection<Turnos> Turnos { get; set; }
    }
}
