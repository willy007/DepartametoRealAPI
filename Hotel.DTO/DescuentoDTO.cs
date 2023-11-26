using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class DescuentoDTO
    {
        public long Id { get; set; }

        public string Descripcion { get; set; } = null!;

        public int Valor { get; set; }

        public int? Porcentaje { get; set; }

        public long ReservaId { get; set; }
    }
}
