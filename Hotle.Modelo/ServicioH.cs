using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class ServicioH
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Valor { get; set; }

    public long Hotel { get; set; }

    public string? Desscripcion { get; set; }

    public bool? PorDia { get; set; }

    public virtual Hotel HotelNavigation { get; set; } = null!;
}
