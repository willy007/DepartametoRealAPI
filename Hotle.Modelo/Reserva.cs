using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class Reserva
{
    public long Id { get; set; }

    public DateOnly? InicioDia { get; set; }

    public DateOnly? TerminoDia { get; set; }

    public int? Valor { get; set; }

    public long Estado { get; set; }

    public long PersonaId { get; set; }

    public long HabitacionId { get; set; }

    public virtual CheckIn? CheckIn { get; set; }

    public virtual CheckOut? CheckOut { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Descuento> Descuentos { get; set; } = new List<Descuento>();

    public virtual EstadoR EstadoNavigation { get; set; } = null!;

    public virtual Habitacion Habitacion { get; set; } = null!;

    public virtual Persona Persona { get; set; } = null!;

    public virtual ICollection<ServicioR> ServicioRs { get; set; } = new List<ServicioR>();
}
