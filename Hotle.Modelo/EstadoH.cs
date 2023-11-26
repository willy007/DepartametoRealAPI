using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class EstadoH
{
    public long Id { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
