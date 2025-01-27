using ClinicaMedica.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.DTOs.Basic
{
    public class EspecialidadesDTO
    {
        public int EspecialidadId { get; set; }
        public string Detalle { get; set; }

        // Propiedad de navegacion para la relacion uno-a-muchos
        //public List<MedicosDTO> Medicos { get; set; }
    }
}
