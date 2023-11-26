using AutoMapper;
using Hotel.Modelo;
using Hotel.Repositorio.Contrato;
using Hotel.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotel.DTO;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly HotelContext _ctxdb;
        private readonly IMapper _mapper;
        private readonly IGenericoRepositorio<Habitacion> _genericoRepo;

        public HabitacionController(HotelContext ctxdb, IMapper mapper, IGenericoRepositorio<Habitacion> genericoRepo)
        {
            _ctxdb = ctxdb;
            _mapper = mapper;
            _genericoRepo = genericoRepo;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar() {
            var response = new ResponseDTO<List<HabitacionDTO>>();

            response.EsCorrecto = false;

            try
            {
                var busquedaServicio = _genericoRepo.GetAll();
                var listaServicio = await busquedaServicio.ToListAsync();
                var serviciosMapp = _mapper.Map<List<HabitacionDTO>>(listaServicio);
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


        [HttpGet("Listar/id:int")]
        public async Task<IActionResult> Listar(int id)
        {
            var response = new ResponseDTO<List<HabitacionDTO>>();

            response.EsCorrecto = false;

            try
            {
                var busquedaServicio = _genericoRepo.GetAll(x=> x.Hotel.Id == id);
                var listaServicio = await busquedaServicio.ToListAsync();
                var serviciosMapp = _mapper.Map<List<HabitacionDTO>>(listaServicio);
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

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] HabitacionDTO newHabitacion )
        {
            var response = new ResponseDTO<HabitacionDTO>();
            try
            {
                var HabitacionMapp = _mapper.Map<Habitacion>(newHabitacion);
                //var hotel = await _ctxdb.Set<Hotel.Modelo.Hotel>().Where(x => x.Id == newHabitacion.HotelId).FirstAsync();
                //HabitacionMapp.Hotel = hotel;
                var nuevaHavitaciones = await _genericoRepo.Create(HabitacionMapp);
                response.EsCorrecto = true;
                response.Resultado = _mapper.Map<HabitacionDTO>(nuevaHavitaciones);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] HabitacionDTO newHabitacion)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                var HabitacionMapp = _mapper.Map<Habitacion>(newHabitacion);
                var nuevaHavitaciones = await _genericoRepo.Update(HabitacionMapp);
                response.EsCorrecto = true;
                response.Resultado = nuevaHavitaciones;

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
