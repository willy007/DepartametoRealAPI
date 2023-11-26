using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class Cliente
{
    public long Id { get; set; }

    public long ReservaId { get; set; }

    public long PersonaId { get; set; }

    public virtual Persona Persona { get; set; } = null!;

    public virtual Reserva Reserva { get; set; } = null!;
}
