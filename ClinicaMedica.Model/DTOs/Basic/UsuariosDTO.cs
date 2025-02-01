using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaMedica.Model.DTOs.Basic
{
    public class UsuariosDTO
    {
        [Required]
        public string NombreUsuario { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        //Aqui se colocan todos los demas datos que tenga el usuario como nombres, direcciones, fechas, edad, estados etc
        [Required]
        public string Rol { get; set; } = string.Empty;

    }
}
