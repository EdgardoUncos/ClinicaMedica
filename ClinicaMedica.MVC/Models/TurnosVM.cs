using ClinicaMedica.Model.DTOs.Basic;

namespace ClinicaMedica.MVC.Models
{
    public class TurnosVM
    {
        public int HorarioId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Fecha { get; set; }
        public HorariosDTO? Horario { get; set; }
        public MedicosDTO? Medico { get; set; }
    }
}
