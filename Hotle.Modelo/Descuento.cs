using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class Descuento
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Valor { get; set; }

    public int? Porcentaje { get; set; }

    public long ReservaId { get; set; }

    public virtual Reserva Reserva { get; set; } = null!;
}
