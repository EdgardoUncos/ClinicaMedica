using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Entities
{
    public class Servicios
    {
        [Key]
        public int ServicioId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "El nombre del servicio no debe exceder los 100 caracteres.")]
        public string Nombre { get; set;}
        [MaxLength(300, ErrorMessage = "La descripción del servicio no debe exceder los 300 caracteres.")]
        public string Descripcion { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        public  float Precio { get; set; }
    }
}
