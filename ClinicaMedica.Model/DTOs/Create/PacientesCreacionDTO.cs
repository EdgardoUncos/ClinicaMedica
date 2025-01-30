
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.Model.DTOs.Create
{
    public class PacientesCreacionDTO
    {
        public int PersonaId { get; set; }
        public bool ObraSocial { get; set; }
        [Required]
        public PersonasCreacionDTO Persona { get; set; }
    }
}
