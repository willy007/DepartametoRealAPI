using AutoMapper;
using Hotel.DTO;
using Hotel.Modelo;
using Hotel.Repositorio;
using Hotel.Servicio.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelServicio _hotel;
        private readonly HotelContext _ctxdb;
        private readonly IMapper _mapper;

        public HotelController(IHotelServicio hotel, HotelContext ctxdb, IMapper mapper)
        {
            _hotel = hotel;
            _ctxdb = ctxdb;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var response = new ResponseDTO<List<HotelDTO>>();

            try
            {
                var hotel = _ctxdb.Set<Hotel.Modelo.Hotel>().Where(x => x.Estado != 3);
                var listaHoteles = await hotel.ToListAsync();
                response.EsCorrecto = true;
                response.Resultado = _mapper.Map<List<HotelDTO>>(listaHoteles);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);

        }

        [HttpGet("ListarHotel")]
        public async Task<IActionResult> ListarHotel()
        {
            var response = new ResponseDTO<List<HotelServicioDTO>>();

            try
            {
                var hotel = _ctxdb.Set<Hotel.Modelo.Hotel>().Where(x => x.Estado == 1 && x.Habitacions.Select(y => y.EstadoId == 1).Count() > 0);
                var listaHoteles = await hotel.ToListAsync();
                response.EsCorrecto = true;
                response.Resultado = _mapper.Map<List<HotelServicioDTO>>(listaHoteles);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);

        }

        [HttpGet("Buscar/id:int")]
        public async Task<IActionResult> Buscar(int id)
        {
            var response = new ResponseDTO<HotelDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _hotel.Buscar(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);

        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] HotelDTO holel)
        {
            var response = new ResponseDTO<HotelDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _hotel.Crear(holel);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);

        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] HotelDTO holel)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _hotel.Editar(holel);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);

        }

        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _hotel.Eliminar(id);
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
