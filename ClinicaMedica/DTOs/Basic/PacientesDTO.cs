using ClinicaMedica.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.DTOs.Basic
{
    public class PacientesDTO
    {
        public int PacienteId { get; set; }
        public int PersonaId { get; set; }
        public bool ObraSocial { get; set; }
        public PersonasDTO Persona { get; set; }
    }
}
