using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class HotelDTO
    {

        public long Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Direccion { get; set; }

        public int? Descuento { get; set; }

        public long? Estado { get; set; }

        public string? Descripcion { get; set; }
    }
}
