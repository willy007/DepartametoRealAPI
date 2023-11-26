using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class HotelServicioDTO
    {
        public long Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Direccion { get; set; }

        public long? Estado { get; set; }

        public virtual ICollection<ImagenDTO> ImagenHotels { get; set; } = new List<ImagenDTO>();

        public virtual ICollection<ServicioHDTO> ServicioHs { get; set; } = new List<ServicioHDTO>();

        public virtual ICollection<TipoHabitacionDTO> TipoHabitacions { get; set; } = new List<TipoHabitacionDTO>();
    }
}
