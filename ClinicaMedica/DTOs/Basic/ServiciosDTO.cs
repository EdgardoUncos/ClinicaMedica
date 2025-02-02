using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.DTOs.Basic
{
    public class ServiciosDTO
    {
        public int ServicioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }

        public ICollection<DetalleCitasDTO>? DetalleCitas { get; set; }

    }
}
