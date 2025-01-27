using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica.Entities
{
    public class Pagos
    {
        [Key]
        public int PagoId { get; set; }

        [Required]
        public int MedioPagoId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]  // Puedes ajustar la precisión y escala según necesites
        public decimal Monto { get; set; }

        // Propiedad de Navegacion Opcional, relacion 1 a 1 con la tabla MediosPago
        [ForeignKey(nameof(MedioPagoId))]
        public MediosPago Pago { get; set; }
    }
}
