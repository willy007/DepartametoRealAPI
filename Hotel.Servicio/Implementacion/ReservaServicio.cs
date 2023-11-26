using AutoMapper;
using Hotel.DTO;
using Hotel.Modelo;
using Hotel.Repositorio.Contrato;
using Hotel.Servicio.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicio.Implementacion
{
    public class ReservaServicio : IReservaServicio
    {

        private readonly IReservaRepositorio _ctxRepo;
        private readonly IMapper _mapper;

        public ReservaServicio(IReservaRepositorio ctxRepo, IMapper mapper)
        {
            _ctxRepo = ctxRepo;
            _mapper = mapper;
        }

        public async Task<ReservaDTO> Actualizar(ReservaDTO update)
        {
            try 
            {
                var mapReserva = _mapper.Map<Reserva>(update);
                var reserva = await _ctxRepo.Update(mapReserva);

                return _mapper.Map<ReservaDTO>(reserva);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ReservaDTO> Buscar(int id)
        {
            try
            {
                var reserva = await _ctxRepo.GetAll(x => x.Id == id).FirstAsync();
                if (reserva == null) { 
                    throw new TaskCanceledException("No existe la reserva");
                }

                return _mapper.Map<ReservaDTO>(reserva);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HabitacionDTO> Habitacion(int id)
        {
            try
            {
                var habitacion = await _ctxRepo.Habitacion(id);
                return _mapper.Map<HabitacionDTO>(habitacion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PersonaDTO>> Persona(int id)
        {
            try
            {
                var listaPersona = await _ctxRepo.Persona(id);
                return _mapper.Map<List<PersonaDTO>>(listaPersona); 

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ReservaDTO> Registra(ReservaDTO reserva)
        {
            try
            {
                var r = _mapper.Map<Reserva>(reserva);
                r = await _ctxRepo.Registra(r);
                return _mapper.Map<ReservaDTO>(r);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServicioRDTO> Registra( ServicioRDTO servicio)
        {
            try
            {
                
                var servicioMap = _mapper.Map<ServicioR>(servicio);
                if (servicioMap.ReservaId == null) {
                    throw new TaskCanceledException("No agrego la reserva");
                }
                int reservaId = (int) servicioMap.ReservaId!;
                servicioMap = await _ctxRepo.Registra(reservaId, servicioMap);

                return _mapper.Map<ServicioRDTO>(servicioMap);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DescuentoDTO> Registra(DescuentoDTO descuento)
        {
            try
            {
                var descuentoMap = _mapper.Map<Descuento>(descuento);
                int reservaId = (int)descuentoMap.ReservaId;
                descuentoMap = await _ctxRepo.Registra(reservaId, descuentoMap);
                return _mapper.Map<DescuentoDTO>(descuentoMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ReservaDTO> Registra(PersonaReservaDTO persona)
        {
            try
            {
                var personaDtoMap = _mapper.Map<PersonaDTO>(persona);
                var personamap = _mapper.Map<Persona>(personaDtoMap); 
                var reserva = await _ctxRepo.Registra(persona.ReservaId, personamap);
                return _mapper.Map<ReservaDTO>(reserva);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
