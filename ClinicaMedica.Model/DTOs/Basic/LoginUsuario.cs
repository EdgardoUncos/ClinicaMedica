using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaMedica.Model.DTOs.Basic
{
    public class LoginUsuario
    {
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
