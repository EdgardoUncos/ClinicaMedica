using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Entities
{
    public class Especialidades
    {
        [Key]
        public int EspecialidadId { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "El detalle de la especialidad no debe exceder los 300 caracteres.")]
        public string Detalle { get; set; }

        // Propiedad de navegacion para la relacion uno-a-muchos
        public ICollection<Medicos> Medicos { get; set; }
    }
}
