namespace ClinicaMedica.Entities
{
    public class DetalleCitas
    {
        public int CitaMedicaId { get; set; }
        public int ServicioId { get; set; }

        public int Cantidad { get; set; }

        // Propiedades de navegación
        public CitasMedicas CitaMedica { get; set; }
        public Servicios Servicio { get; set; }
    }
}
