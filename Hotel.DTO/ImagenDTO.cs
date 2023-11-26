using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTO
{
    public class ImagenDTO
    {
        public long Id { get; set; }

        public byte[] Img { get; set; } = null!;

        public bool IsPrimario { get; set; }

        public long HotelId { get; set; }
    }
}
