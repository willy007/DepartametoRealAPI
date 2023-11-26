using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class Inventario
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Valor { get; set; }

    public long HotelId { get; set; }

    public long? HabitacionId { get; set; }

    public virtual Habitacion? Habitacion { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
