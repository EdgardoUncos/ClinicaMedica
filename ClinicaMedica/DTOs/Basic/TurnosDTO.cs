using ClinicaMedica.Entities;

namespace ClinicaMedica.DTOs.Basic
{
    public class TurnosDTO
    {
        public int TurnoId { get; set; }
        public int HorarioId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Asistencia { get; set; } = false;
        public HorariosDTO? Horario { get; set; }
        public MedicosDTO? Medico { get; set; }
    }
}
