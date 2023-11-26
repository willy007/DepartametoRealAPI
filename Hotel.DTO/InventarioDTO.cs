using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class InventarioDTO
    {

        public long Id { get; set; }

        public string Nombre { get; set; } = null!;

        public int Valor { get; set; }

        public long HotelId { get; set; }

        public long? HabitacionId { get; set; }

    }
}
