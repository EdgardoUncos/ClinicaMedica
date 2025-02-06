namespace ClinicaMedica.DTOs.Create
{
    public class TurnosCreacionDTO
    {
        public int HorarioId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Asistencia { get; set; } = false;

        public string Estado { get; set; } = "Disponible";
    }
}
