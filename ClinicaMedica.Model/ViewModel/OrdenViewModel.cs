using ClinicaMedica.Model.DTOs.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaMedica.Model.ViewModel
{
    public class OrdenViewModel
    {
        public int HorarioId { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public DateTime Fecha { get; set; }
        public PacientesDTO? Paciente { get; set; }
        public List<PacientesDTO>? Pacientes { get; set; } = new List<PacientesDTO>();
        public List<HorariosDTO>? Horarios { get; set; } = new List<HorariosDTO>();
        public List<MedicosDTO>? Medicos { get; set; } = new List<MedicosDTO>();
        public List<ServiciosDTO>? Servicios { get; set; } = new List<ServiciosDTO>(); // ← Asegurar inicialización
    }
}

