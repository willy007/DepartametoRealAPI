using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class CrearImagenDTO
    {
        [Required(ErrorMessage = "Ingrese imagen")]
        public byte[] Img { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese si es primario")]
        public bool IsPrimario { get; set; }
        [Required(ErrorMessage = "Ingrese el Hotel a que pretenece la Imagen")]
        public long HotelId { get; set; }
    }
}
