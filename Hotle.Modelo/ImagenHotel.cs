using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class ImagenHotel
{
    public long Id { get; set; }

    public byte[] Img { get; set; } = null!;

    public bool IsPrimario { get; set; }

    public long HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
