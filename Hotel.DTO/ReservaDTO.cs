using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class ReservaDTO
    {
        public long Id { get; set; }

        public DateOnly? InicioDia { get; set; }

        public DateOnly? TerminoDia { get; set; }

        public int? Valor { get; set; }

        public long Estado { get; set; }

        public long PersonaId { get; set; }

        public long HabitacionId { get; set; }
    }
}
