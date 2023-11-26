using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Hotel.Modelo;

namespace Hotel.Repositorio;

public partial class HotelContext : DbContext
{
    public HotelContext()
    {
    }

    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CheckIn> CheckIns { get; set; }

    public virtual DbSet<CheckOut> CheckOuts { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Descuento> Descuentos { get; set; }

    public virtual DbSet<Encargado> Encargados { get; set; }

    public virtual DbSet<EstadoH> EstadoHs { get; set; }

    public virtual DbSet<EstadoR> EstadoRs { get; set; }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<Hotel.Modelo.Hotel> Hotels { get; set; }

    public virtual DbSet<ImagenHotel> ImagenHotels { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<ItemIn> ItemIns { get; set; }

    public virtual DbSet<ItemOut> ItemOuts { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<ServicioH> ServicioHs { get; set; }

    public virtual DbSet<ServicioR> ServicioRs { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ }
    //=> optionsBuilder.UseNpgsql("Host=localhost;Database=Hotel;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheckIn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CheckIn_pkey");

            entity.ToTable("CheckIn", "Reserva");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Realzado).HasDefaultValueSql("false");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.CheckIn)
                .HasForeignKey<CheckIn>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CheckIc_Reserva");
        });

        modelBuilder.Entity<CheckOut>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CheckOut_pkey");

            entity.ToTable("CheckOut", "Reserva");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Realzado).HasDefaultValueSql("false");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.CheckOut)
                .HasForeignKey<CheckOut>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CheckOut_Reserva");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Cliente_pkey");

            entity.ToTable("Cliente", "Reserva");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Persona).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Persona");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Reserva");
        });

        modelBuilder.Entity<Descuento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Descuento_pkey");

            entity.ToTable("Descuento", "Reserva");

            entity.Property(e => e.Descripcion).HasMaxLength(255);

            entity.HasOne(d => d.Reserva).WithMany(p => p.Descuentos)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Descuento_Reserva");
        });

        modelBuilder.Entity<Encargado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Encargado_pkey");

            entity.ToTable("Encargado", "Persona");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Encargados)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Encargado_Hotel");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Encargados)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Encargado_Usuario");
        });

        modelBuilder.Entity<EstadoH>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("EstadoH_pkey");

            entity.ToTable("EstadoH", "Hotel");

            entity.Property(e => e.Estado).HasMaxLength(50);
        });

        modelBuilder.Entity<EstadoR>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("EstadoR_pkey");

            entity.ToTable("EstadoR", "Reserva");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Habitacion_pkey");

            entity.ToTable("Habitacion", "Hotel");

            entity.HasIndex(e => e.Numero, "UN_Numero").IsUnique();

            entity.Property(e => e.Numero).HasMaxLength(50);

            entity.HasOne(d => d.Estado).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Habitacion_Estado");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Habitacon_Hotel");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.Tipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Habitacion_TipoHabitacion");
        });

        modelBuilder.Entity<Hotel.Modelo.Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Hotel_pkey");

            entity.ToTable("Hotel", "Hotel");

            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(200);

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.Estado)
                .HasConstraintName("FK_Hotel_EstadoHotel");
        });

        modelBuilder.Entity<ImagenHotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Imagen_Hotel_pkey");

            entity.ToTable("Imagen_Hotel", "Hotel");

            entity.HasOne(d => d.Hotel).WithMany(p => p.ImagenHotels)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Imagen_Hotel");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Inventario_pkey");

            entity.ToTable("Inventario", "Hotel");

            entity.Property(e => e.Nombre).HasMaxLength(200);

            entity.HasOne(d => d.Habitacion).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.HabitacionId)
                .HasConstraintName("FK_Inventario_Habitacion");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Hotel");
        });

        modelBuilder.Entity<ItemIn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ItemIn_pkey");

            entity.ToTable("ItemIn", "Reserva");

            entity.Property(e => e.Aprobacion).HasDefaultValueSql("true");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NA'::character varying");
            entity.Property(e => e.Valor).HasDefaultValueSql("0");

            entity.HasOne(d => d.CheckIn).WithMany(p => p.ItemIns)
                .HasForeignKey(d => d.CheckInId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_CheckIn");
        });

        modelBuilder.Entity<ItemOut>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ItemOut_pkey");

            entity.ToTable("ItemOut", "Reserva");

            entity.Property(e => e.Aprobacion).HasDefaultValueSql("true");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NA'::character varying");
            entity.Property(e => e.Valor).HasDefaultValueSql("0");

            entity.HasOne(d => d.Checkout).WithMany(p => p.ItemOuts)
                .HasForeignKey(d => d.CheckoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_CheckOut");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Persona_pkey");

            entity.ToTable("Persona", "Persona");

            entity.Property(e => e.Apellido).HasMaxLength(200);
            entity.Property(e => e.Correo).HasMaxLength(255);
            entity.Property(e => e.Identificador).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Telefono).HasMaxLength(100);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Reserva_pkey");

            entity.ToTable("Reserva", "Reserva");

            entity.Property(e => e.Valor).HasDefaultValueSql("0");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Estado");

            entity.HasOne(d => d.Habitacion).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.HabitacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Habitacion");

            entity.HasOne(d => d.Persona).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Persona");
        });

        modelBuilder.Entity<ServicioH>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ServicioH_pkey");

            entity.ToTable("ServicioH", "Hotel");

            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.PorDia).HasColumnName("PorDIa");

            entity.HasOne(d => d.HotelNavigation).WithMany(p => p.ServicioHs)
                .HasForeignKey(d => d.Hotel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servicio_Hotel");
        });

        modelBuilder.Entity<ServicioR>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ServicioR_pkey");

            entity.ToTable("ServicioR", "Reserva");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Encargado).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.Reserva).WithMany(p => p.ServicioRs)
                .HasForeignKey(d => d.ReservaId)
                .HasConstraintName("FK_Servicio_Reserva");
        });

        modelBuilder.Entity<TipoHabitacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TipoHabitacion_pkey");

            entity.ToTable("TipoHabitacion", "Hotel");

            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.Hotel).WithMany(p => p.TipoHabitacions)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TipoHabitacion_Hotel_FK");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Usuario_pkey");

            entity.ToTable("Usuario", "Persona");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Contrasena).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Tipo)
                .HasMaxLength(25)
                .HasDefaultValueSql("'Usuario'::character varying");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Persona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
