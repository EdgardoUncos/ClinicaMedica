using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Entities
{
    public class Especialidades
    {
        public int EspecialidadId { get; set; }
        public string Detalle { get; set; }

        // Propiedad de navegacion para la relacion uno-a-muchos
        public ICollection<Medicos> Medicos { get; set; }
    }
}
