

namespace ClinicaMedica.Model.DTOs.Create
{
    // Datos necesarios para la creacion de una especialidad.
    // Quitamos de EspecialidadesDTO todo lo que no se necesita para un post
    public class MedicosCreacionDTO
    {
        public int EspecialidadId { get; set; }
        public float Sueldo { get; set; }

        // Necesitamos una persona para crear al medico. Herencia
        public PersonasCreacionDTO Persona { get; set; }
        
    }
}
