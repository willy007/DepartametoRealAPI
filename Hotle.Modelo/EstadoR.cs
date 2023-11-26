using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class EstadoR
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
