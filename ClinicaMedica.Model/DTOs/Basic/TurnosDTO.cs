using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaMedica.Model.DTOs.Basic
{
    public class TurnosDTO
    {
        public int TurnoId { get; set; }
        public int HorarioId { get; set; }
        public int MedicoId { get; set; }
        public DateOnly Fecha { get; set; }
        public bool Asistencia { get; set; } = false;
        public HorariosDTO? Horario { get; set; }
        public MedicosDTO? Medico { get; set; }
    }
}
