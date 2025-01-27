using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Entities
{
    public class MediosPago
    {
        [Key]
        public int MedioPagoId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El nombre del medio de pago no debe exceder los 100 caracteres.")]
        public string Nombre { get; set; }
        // Opcional: Campo para habilitar/deshabilitar el medio de pago
        public bool EstaActivo { get; set; } = true;

        //Propiedad de navegacion
        public ICollection<Pagos> Pagos { get; set; }
    }
}
