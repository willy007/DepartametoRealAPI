using AutoMapper;
using Hotel.DTO;
using Hotel.Modelo;
using Hotel.Repositorio.Contrato;
using Hotel.Servicio.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicio.Implementacion
{
    public class HotelServicio : IHotelServicio
    {
        private readonly IGenericoRepositorio<Modelo.Hotel> _ctxRepo;
        private readonly IMapper _mapper;

        public HotelServicio(IGenericoRepositorio<Modelo.Hotel> ctxRepo, IMapper mapper)
        {
            _ctxRepo = ctxRepo;
            _mapper = mapper;
        }

        public async Task<HotelDTO> Buscar(int id)
        {
            try {
                long idl = (long)id;
                var listaHotel = _ctxRepo.GetAll(x => x.Id == idl );
                var hotel  = await listaHotel.FirstOrDefaultAsync();

                return _mapper.Map<HotelDTO>(hotel);
            
            }catch(Exception ) {
                throw;
            }  
        }

        public async Task<HotelDTO> Crear(HotelDTO nuevo)
        {
            try
            {
                var mapHotel = _mapper.Map<Modelo.Hotel>(nuevo);
                var hotel = await _ctxRepo.Create(mapHotel);
                return _mapper.Map<HotelDTO>(hotel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Editar(HotelDTO nuevo)
        {
            try
            {
                var mapHotel = _mapper.Map<Modelo.Hotel>(nuevo);
                var result = await _ctxRepo.Update(mapHotel);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var busqueda = _ctxRepo.GetAll(x => x.Id == id);
                var hotel = await busqueda.FirstOrDefaultAsync();
                if (hotel == null) {
                    throw new TaskCanceledException("Hotel no encontrado");
                }
                hotel.Estado = 2;

                return await _ctxRepo.Update(hotel);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<HotelDTO>> Listar()
        {
            try
            {
                var hoteles = _ctxRepo.GetAll();
                var listaHoteles = await hoteles.ToListAsync();
                var result = _mapper.Map<List<HotelDTO>>(listaHoteles);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
