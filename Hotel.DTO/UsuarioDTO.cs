using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class UsuarioDTO
    {
        public long Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Tipo { get; set; }

        public virtual PersonaDTO IdNavigation { get; set; } = null!;
    }
}
