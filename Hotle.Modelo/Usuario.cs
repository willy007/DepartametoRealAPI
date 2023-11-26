using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class Usuario
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string? Tipo { get; set; }

    public virtual ICollection<Encargado> Encargados { get; set; } = new List<Encargado>();

    public virtual Persona IdNavigation { get; set; } = null!;
}
