using Hotel.Modelo;
using Hotel.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repositorio.Implementaciones
{
    public class ReservaRepositorio : GenericoRepositorio<Reserva>, IReservaRepositorio
    {

        private readonly HotelContext _dbCtx;

        public ReservaRepositorio(HotelContext dbCtx):base(dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public async Task<Reserva> Registra(Reserva reserva)
        {
            try
            {
                reserva.Id = 0;
                reserva.Estado = 1;
                _dbCtx.Set<Reserva>().Add(reserva);
                await _dbCtx.SaveChangesAsync();
                return reserva;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ServicioR> Registra(int id, ServicioR servicio)
        {
            
            servicio.Descripcion = "no especificado";

            using (var transaction = _dbCtx.Database.BeginTransaction()) {

                try
                {
                    var verificacionServicio = await _dbCtx.Set<ServicioR>().Where(x => x.ReservaId == servicio.ReservaId && x.Nombre == servicio.Nombre).FirstAsync();
                    if (verificacionServicio != null)
                    {
                        throw new TaskCanceledException("Servicio ya esta agregado");
                    }
                    var verificacionReserva = await _dbCtx.Set<Reserva>().Where(x => x.Id == id).FirstAsync();
                    if (verificacionReserva == null)
                    {
                        throw new TaskCanceledException("La Reserva no existe");
                    }

                    servicio.ReservaId = id;
                    _dbCtx.Set<ServicioR>().Add(servicio);
                    await _dbCtx.SaveChangesAsync();
                    return servicio;
                }
                catch (Exception) {

                    throw;
                }

            }

        }

        public async Task<Descuento> Registra(int id, Descuento descuento)
        {
            try {
                var verificacionReserva = await _dbCtx.Set<Reserva>().Where(x => x.Id == id).FirstAsync();
                if (verificacionReserva == null)
                {
                    throw new TaskCanceledException("La Reserva no existe");
                }

                descuento.ReservaId = id;
                _dbCtx.Set<Descuento>().Add(descuento);
                await _dbCtx.SaveChangesAsync();

                return descuento;

            }
            catch (Exception) { throw; }    
        }

        public async Task<Reserva> Registra(int id, Persona persona)
        {
            using (var transaction = _dbCtx.Database.BeginTransaction())
            {

                try
                {
                    Cliente cliente = new Cliente();

                    var verificacionPersona = await _dbCtx.Set<Persona>().Where(x => x.Identificador == persona.Identificador && x.Usuario == null).FirstAsync();
                    if (verificacionPersona != null)
                    {
                        if (verificacionPersona.Usuario != null)
                        {
                            _dbCtx.Set<Persona>().Add(persona);
                            await _dbCtx.SaveChangesAsync();
                        }
                        else 
                        {
                            persona = verificacionPersona;
                        }

                    }

                    var verificacionCliente = await _dbCtx.Set<Cliente>().Where(x => x.ReservaId == id).ToListAsync();
                    var verificacionReserva = await _dbCtx.Set<Reserva>().Where(x => x.Id == id).FirstAsync();

                    if (verificacionReserva == null)
                    {
                        throw new TaskCanceledException("La Reserva no existe");
                    }else if (verificacionReserva.Habitacion.TipoNavigation.CantidadPersonas <= verificacionCliente.Count)
                    {
                        throw new TaskCanceledException("cantidad de personas para la habitacion fue excedido");
                    }

                    cliente.ReservaId = id;
                    cliente.PersonaId = persona.Id;
                    _dbCtx.Set<Cliente>().Add(cliente);
                    await _dbCtx.SaveChangesAsync();

                    transaction.Commit();

                    return verificacionReserva;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }

            }
        }

        public async Task<List<Persona>> Persona(int id) {
            
            try {
                List<Persona> listapersona = new List<Persona>();
                var verificacionCliente = await _dbCtx.Set<Cliente>().Where(x => x.ReservaId == id).ToListAsync();

                var verificacionReserva = await _dbCtx.Set<Reserva>().Where(x => x.Id == id).FirstAsync();
                if (verificacionReserva == null)
                {
                    throw new TaskCanceledException("La Reserva no existe");
                }

                foreach (Cliente c in verificacionCliente) { 
                    listapersona.Add(c.Persona);
                }

                return listapersona;

            }
            catch (Exception) { 
                throw; 
            }
        }

        public async Task<Habitacion> Habitacion(int id)
        {
            try {

                var verificacionReserva = await _dbCtx.Set<Reserva>().Where(x => x.Id == id).FirstAsync();
                if (verificacionReserva == null)
                {
                    throw new TaskCanceledException("La Reserva no existe");
                }

                return verificacionReserva.Habitacion;

            }
            catch (Exception) {
                throw;
            }    

        }
    }
}
