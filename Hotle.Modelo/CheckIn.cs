using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class CheckIn
{
    public long Id { get; set; }

    public bool? Realzado { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual Reserva IdNavigation { get; set; } = null!;

    public virtual ICollection<ItemIn> ItemIns { get; set; } = new List<ItemIn>();
}
