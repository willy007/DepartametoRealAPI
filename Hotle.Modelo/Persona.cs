using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class Persona
{
    public long Id { get; set; }

    public string? Identificador { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual Usuario? Usuario { get; set; }
}
