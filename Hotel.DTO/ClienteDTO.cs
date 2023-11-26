using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class ClienteDTO
    {

        public long Id { get; set; }

        public long ReservaId { get; set; }

        public long PersonaId { get; set; }

        public virtual PersonaDTO Persona { get; set; } = null!;

        public virtual ReservaDTO Reserva { get; set; } = null!;

    }
}
