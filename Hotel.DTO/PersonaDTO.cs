using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class PersonaDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage ="El dato de identificacion es Hobligatorio")]
        public string? Identificador { get; set; }

        [Required(ErrorMessage = "Ingrese el Nombre")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese el Apellido")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "ingrese un correo")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "ingrese un Numero Telefonico")]
        public string? Telefono { get; set; }

    }
}
