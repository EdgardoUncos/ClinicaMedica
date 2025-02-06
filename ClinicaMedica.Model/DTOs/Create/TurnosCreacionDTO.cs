using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaMedica.Model.DTOs.Create
{
    public class TurnosCreacionDTO
    {
        public int HorarioId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Asistencia { get; set; } = false;

        public string Estado { get; set; } = "Disponible";
    }
}
