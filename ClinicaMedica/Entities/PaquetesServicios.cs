namespace ClinicaMedica.Entities
{
    public class PaquetesServicios
    {
        public int PaqueteId { get; set; }
        public int ServicioId { get; set; }

        public  Paquetes Paquete { get; set; }
        public Servicios Servicio { get; set; }
    }
}
