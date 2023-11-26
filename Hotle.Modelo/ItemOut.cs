using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class ItemOut
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? Valor { get; set; }

    public bool? Aprobacion { get; set; }

    public long CheckoutId { get; set; }

    public virtual CheckOut Checkout { get; set; } = null!;
}
