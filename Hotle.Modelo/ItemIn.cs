using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class ItemIn
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? Valor { get; set; }

    public bool? Aprobacion { get; set; }

    public long CheckInId { get; set; }

    public virtual CheckIn CheckIn { get; set; } = null!;
}
