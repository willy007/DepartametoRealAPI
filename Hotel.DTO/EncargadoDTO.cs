using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class EncargadoDTO
    {
        public long Id { get; set; }

        public long UsuarioId { get; set; }

        public long HotelId { get; set; }
    }
}
