using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class TipoHabitacionDTO
    {
        public long Id { get; set; }

        public int CantidadPersonas { get; set; }

        public int ValorDia { get; set; }

        public long HotelId { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }
    }
}
