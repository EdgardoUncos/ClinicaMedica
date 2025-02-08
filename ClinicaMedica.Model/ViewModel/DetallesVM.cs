using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaMedica.Model.ViewModel
{
    public class DetallesVM
    {
        public  int CitaMedicaId { get; set; } // opcional para cuando se muestra una orden creada

        public int ServicioId { get; set; }

        public string NombreServicio { get; set; }

        public int Cantidad { get; set; }
        public float Precio { get; set; }

        public float Total { get; set; }
    }
}
