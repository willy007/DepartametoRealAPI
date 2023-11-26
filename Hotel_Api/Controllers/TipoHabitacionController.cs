using AutoMapper;
using Hotel.DTO;
using Hotel.Modelo;
using Hotel.Repositorio;
using Hotel.Repositorio.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoHabitacionController : ControllerBase
    {
        private readonly HotelContext _ctxdb;
        private readonly IMapper _mapper;
        private readonly IGenericoRepositorio<TipoHabitacion> _genericoRepo;

        public TipoHabitacionController(HotelContext ctxdb, IMapper mapper, IGenericoRepositorio<TipoHabitacion> genericoRepo)
        {
            _ctxdb = ctxdb;
            _mapper = mapper;
            _genericoRepo = genericoRepo;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar() {

            var response = new ResponseDTO<List<TipoHabitacionDTO>>();
            try {

                var listaTiposHavitaciones = await _ctxdb.Set<TipoHabitacion>().ToListAsync();
                response.EsCorrecto = true;
                response.Resultado = _mapper.Map<List<TipoHabitacionDTO>>(listaTiposHavitaciones);
                

            }catch(Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("ListarDisponible/id:int")]
        public async Task<IActionResult> ListarDisponible(int id)
        {

            var response = new ResponseDTO<List<TipoHabitacionDTO>>();
            try
            {

                var listaTiposHavitaciones = await _ctxdb.Set<TipoHabitacion>().Where(x => x.HotelId == id && x.Habitacions.Select(y => y.EstadoId == 1).Count() > 0).ToListAsync();
                response.EsCorrecto = true;
                response.Resultado = _mapper.Map<List<TipoHabitacionDTO>>(listaTiposHavitaciones);


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

            var response = new ResponseDTO<TipoHabitacionDTO>();
            try
            {

                var listaTiposHavitaciones = await _ctxdb.Set<TipoHabitacion>().Where(x =>  x.Habitacions.Select(y => y.EstadoId == 1).Count() > 0 && x.Id == id).ToListAsync();
                response.EsCorrecto = true;
                response.Resultado = _mapper.Map<TipoHabitacionDTO>(listaTiposHavitaciones.First());


            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] TipoHabitacionDTO tipoHabitacion) {

            var response = new ResponseDTO<TipoHabitacionDTO>();
            try
            {
                var tipoHabitacionMapp = _mapper.Map<TipoHabitacion>(tipoHabitacion);
                var hotel = await _ctxdb.Set<Hotel.Modelo.Hotel>().Where(x => x.Id == tipoHabitacion.HotelId).FirstAsync();
                tipoHabitacionMapp.Hotel = hotel;
                var listaTiposHavitaciones = await _genericoRepo.Create(tipoHabitacionMapp);
                response.EsCorrecto = true;
                response.Resultado = _mapper.Map<TipoHabitacionDTO>(listaTiposHavitaciones);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

        [HttpDelete("Eliminar/id:int")]
        public async Task<IActionResult> Eliminar(int id) {

            var response = new ResponseDTO<bool>();
            try
            {
                var busquedaTiposHabitaciones = await _ctxdb.Set<TipoHabitacion>().Where(x => x.Id == id).FirstAsync();

                if (busquedaTiposHabitaciones == null) { 
                    throw new TaskCanceledException("No existe el Tipo de Habitacion");  
                }
                var rowsHabitacoin = busquedaTiposHabitaciones.Habitacions.Count();

                if (rowsHabitacoin != 0) {
                    throw new TaskCanceledException("El Tipo de Habitacion Tiene HAbitaciones asignadas");
                }

                var listaTiposHavitaciones = await _genericoRepo.Delete(busquedaTiposHabitaciones);
                response.EsCorrecto = true;
                response.Resultado = listaTiposHavitaciones;

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] TipoHabitacionDTO tipoHabitacion) {
            var response = new ResponseDTO<bool>();
            try
            {
                var tipoHabitacionMapp = _mapper.Map<TipoHabitacion>(tipoHabitacion);
                var resultTiposHavitaciones = await _genericoRepo.Update(tipoHabitacionMapp);
                response.EsCorrecto = true;
                response.Resultado = resultTiposHavitaciones;

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
