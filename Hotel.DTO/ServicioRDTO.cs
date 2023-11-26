using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class ServicioRDTO
    {
        public long Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int? Valor { get; set; }

        public long? ReservaId { get; set; }
    }
}
