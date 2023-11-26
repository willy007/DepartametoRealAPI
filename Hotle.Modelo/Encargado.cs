using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class Encargado
{
    public long Id { get; set; }

    public long UsuarioId { get; set; }

    public long HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
