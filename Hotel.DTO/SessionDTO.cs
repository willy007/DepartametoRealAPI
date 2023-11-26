using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class SessionDTO
    {
        [Required(ErrorMessage = "Ingrese el Nombre de Usuario")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Contraseña")]
        public string Contrasena { get; set; } = null!;

    }
}
