using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class ServicioHDTO
    {
        public long Id { get; set; }

        public string Nombre { get; set; } = null!;

        public int Valor { get; set; }

        public long Hotel { get; set; }

        public string? Desscripcion { get; set; }

        public bool? PorDia { get; set; }
    }
}
