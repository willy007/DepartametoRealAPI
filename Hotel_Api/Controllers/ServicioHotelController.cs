using AutoMapper;
using Hotel.Modelo;
using Hotel.Repositorio.Contrato;
using Hotel.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotel.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hotel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioHotelController : ControllerBase
    {

        private readonly HotelContext _ctxdb;
        private readonly IMapper _mapper;
        private readonly IGenericoRepositorio<ServicioH> _genericoRepo;

        public ServicioHotelController(HotelContext ctxdb, IMapper mapper, IGenericoRepositorio<ServicioH> genericoRepo)
        {
            _ctxdb = ctxdb;
            _mapper = mapper;
            _genericoRepo = genericoRepo;
        }


        [HttpGet("Listar")]
        public async Task<IActionResult> Listar() {
            var response = new ResponseDTO<List<ServicioHDTO>>();

            response.EsCorrecto = false;

            try {
                var busquedaServicio = _genericoRepo.GetAll();
                var listaServicio = await busquedaServicio.ToListAsync();
                var serviciosMapp = _mapper.Map<List<ServicioHDTO>>(listaServicio);
                response.Resultado = serviciosMapp;
                response.EsCorrecto = true;

            }catch(Exception ex) {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("ListarHotel/id:int")]
        public async Task<IActionResult> ListarHotel(int id)
        {
            var response = new ResponseDTO<List<ServicioHDTO>>();

            response.EsCorrecto = false;

            try
            {
                var busquedaServicio = _genericoRepo.GetAll(x => x.Hotel == id);
                var listaServicio = await busquedaServicio.ToListAsync();
                var serviciosMapp = _mapper.Map<List<ServicioHDTO>>(listaServicio);
                response.Resultado = serviciosMapp;
                response.EsCorrecto = true;

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] ServicioHDTO newServicio) {
            var response = new ResponseDTO<ServicioHDTO>();

            try
            {
                var convert = _mapper.Map<ServicioH>(newServicio);
                var crearServicio = await _genericoRepo.Create(convert);
                var serviciosMapp = _mapper.Map<ServicioHDTO>(crearServicio);
                response.Resultado = serviciosMapp;
                response.EsCorrecto = true;

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] ServicioHDTO newServicio)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                var convert = _mapper.Map<ServicioH>(newServicio);
                convert.HotelNavigation = await _ctxdb.Set<Hotel.Modelo.Hotel>().Where(x => x.Id == newServicio.Hotel).FirstAsync();
                var crearServicio = await _genericoRepo.Update(convert);
                response.Resultado = crearServicio;
                response.EsCorrecto = true;

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpDelete("Eliminar/id:int")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                var buscar = await _genericoRepo.GetAll(x => x.Id == id).FirstAsync() ?? throw new TaskCanceledException("No existe el servicio");
                var statusServicio = await _genericoRepo.Delete(buscar);
                response.Resultado = statusServicio;
                response.EsCorrecto = true;

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

    }

}
