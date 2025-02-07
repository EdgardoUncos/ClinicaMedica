namespace ClinicaMedica.Entities
{
    public class Paquetes
    {
        public int PaqueteId { get; set; }
        public int Nombre { get; set; }
        public float Precio { get; set; }

        public ICollection<PaquetesServicios> PaquetesServicios { get; set; }
    }
}
