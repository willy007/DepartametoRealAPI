using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class EstadoRDTO
    {
        public long Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public virtual ICollection<ReservaDTO> Reservas { get; set; } = new List<ReservaDTO>();
    }
}
