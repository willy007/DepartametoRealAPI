using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class HabitacionDTO
    {

        public long Id { get; set; }

        public string Numero { get; set; } = null!;

        public long EstadoId { get; set; }

        public long HotelId { get; set; }

        public long Tipo { get; set; }
    }
}
