using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Model.DTOs.Create
{ 
    public class ServiciosCreacionDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public float Precio { get; set; }
    }
}
