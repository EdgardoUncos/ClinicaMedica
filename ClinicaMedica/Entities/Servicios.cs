using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Entities
{
    public class Servicios
    {
        public int ServicioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }

        public ICollection<DetalleCitas> DetalleCitas { get; set; }
        public ICollection<PaquetesServicios> PaquetesServicios { get; set; }
    }
    
}
