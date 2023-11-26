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
    public class InventarioServicio : IInventario
    {
        private readonly IGenericoRepositorio<Modelo.Inventario> _ctxRepo;
        private readonly IMapper _mapper;

        public InventarioServicio(IGenericoRepositorio<Modelo.Inventario> ctxRepo, IMapper mapper)
        {
            _ctxRepo = ctxRepo;
            _mapper = mapper;
        }

        public async Task<InventarioDTO> Crear(InventarioDTO nuevo)
        {

            try {

                var inventarioMapp = _mapper.Map<Modelo.Inventario>(nuevo);
                var inventarioNuevo = await _ctxRepo.Create(inventarioMapp);

                return _mapper.Map<InventarioDTO>(inventarioNuevo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> Editar(InventarioDTO nuevo)
        {
            try
            {
                var inventarioMapp = _mapper.Map<Modelo.Inventario>(nuevo);
                var inventarioNuevo = await _ctxRepo.Update(inventarioMapp);

                return inventarioNuevo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Eliminar(InventarioDTO nuevo)
        {
            try
            {
                var inventarioMapp = _mapper.Map<Modelo.Inventario>(nuevo);
                var estado = await _ctxRepo.Delete(inventarioMapp);

                return estado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<InventarioDTO>> TraerHotel(int id)
        {
            try
            {
                var listaInventario = _ctxRepo.GetAll(x => x.HotelId == id);
                var inventarios = await listaInventario.ToListAsync();

                return _mapper.Map<List<InventarioDTO>>(inventarios);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
