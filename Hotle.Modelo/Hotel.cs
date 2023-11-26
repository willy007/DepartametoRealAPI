using System;
using System.Collections.Generic;

namespace Hotel.Modelo;

public partial class Hotel
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public int? Descuento { get; set; }

    public long? Estado { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Encargado> Encargados { get; set; } = new List<Encargado>();

    public virtual EstadoH? EstadoNavigation { get; set; }

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();

    public virtual ICollection<ImagenHotel> ImagenHotels { get; set; } = new List<ImagenHotel>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<ServicioH> ServicioHs { get; set; } = new List<ServicioH>();

    public virtual ICollection<TipoHabitacion> TipoHabitacions { get; set; } = new List<TipoHabitacion>();
}
