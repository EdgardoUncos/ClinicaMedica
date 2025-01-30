

namespace ClinicaMedica.Model.DTOs.Basic
{
    public class PacientesDTO
    {
        public int PacienteId { get; set; }
        public int PersonaId { get; set; }
        public bool ObraSocial { get; set; }
        public PersonasDTO Persona { get; set; }
    }
}
