using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class Habitacion
{
    public long Id { get; set; }

    public string Numero { get; set; } = null!;

    public long HotelId { get; set; }

    public long EstadoId { get; set; }

    public long Tipo { get; set; }

    public virtual EstadoH Estado { get; set; } = null!;

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual TipoHabitacion TipoNavigation { get; set; } = null!;
}
