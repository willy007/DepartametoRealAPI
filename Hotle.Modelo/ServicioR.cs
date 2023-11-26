using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class ServicioR
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Encargado { get; set; }

    public int? Valor { get; set; }

    public long? ReservaId { get; set; }

    public virtual Reserva? Reserva { get; set; }
}
