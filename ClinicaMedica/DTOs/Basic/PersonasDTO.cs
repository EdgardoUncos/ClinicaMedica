using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.DTOs.Basic
{
    public class PersonasDTO
    {
        // Datos de la tabla
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
