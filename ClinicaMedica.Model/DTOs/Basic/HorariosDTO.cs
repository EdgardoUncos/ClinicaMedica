using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaMedica.Model.DTOs.Basic
{
    public class HorariosDTO
    {
        public int HorarioId { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioFin { get; set; }

        public bool Habilitado { get; set; }    

    }
}
