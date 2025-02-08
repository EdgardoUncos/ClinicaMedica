using ClinicaMedica.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.DTOs.Basic
{
    public class MedicosDTO
    {
        // Datos de la tabla Medicos
        public int MedicoId { get; set; }
        public int PersonaId { get; set; }
        public int EspecialidadId { get; set; }
        public float Sueldo { get; set; }

        // Propiedades de navegacion
        public PersonasDTO Persona { get; set; }
        public EspecialidadesDTO? Especialidades { get; set; }
    }
}
