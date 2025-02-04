using ClinicaMedica.Model.DTOs.Basic;

namespace ClinicaMedica.MVC.Models
{
    public class OrdenesVM
    {
        public int HorarioId { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public DateTime Fecha { get; set; }
        public PacientesDTO? Paciente { get; set; }
        public List<PacientesDTO>? pacientes { get; set; }
        public List<HorariosDTO>? Horarios { get; set; }
        public List<MedicosDTO>? Medicos { get; set; }
    }
}
