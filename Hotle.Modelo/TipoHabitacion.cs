using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class TipoHabitacion
{
    public long Id { get; set; }

    public int CantidadPersonas { get; set; }

    public int ValorDia { get; set; }

    public long HotelId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();

    public virtual Hotel Hotel { get; set; } = null!;
}
