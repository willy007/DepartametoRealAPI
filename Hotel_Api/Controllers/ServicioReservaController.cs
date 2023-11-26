using AutoMapper;
using Hotel.DTO;
using Hotel.Modelo;
using Hotel.Repositorio.Contrato;
using Hotel.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioReservaController : ControllerBase
    {
        private readonly HotelContext _ctxdb;
        private readonly IMapper _mapper;
        private readonly IGenericoRepositorio<ServicioR> _genericoRepo;

        public ServicioReservaController(HotelContext ctxdb, IMapper mapper, IGenericoRepositorio<ServicioR> genericoRepo)
        {
            _ctxdb = ctxdb;
            _mapper = mapper;
            _genericoRepo = genericoRepo;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ServicioRDTO servicio)
        {
            var response = new ResponseDTO<ServicioRDTO>();
            response.EsCorrecto = false;

            try
            {
                var mapServicio = _mapper.Map<ServicioR>(servicio);
                var repoServicio = await _genericoRepo.Create(mapServicio);
                response.EsCorrecto = true;
                response.Resultado = _mapper.Map<ServicioRDTO>(repoServicio);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Obtener/id:int")]
        public async Task<IActionResult> Obtener(int id)
        {
            var response = new ResponseDTO<List<ServicioRDTO>>();
            response.EsCorrecto = false;

            try
            {
                var listaServicio = new List<ServicioR>();
                var buscarServicios = _genericoRepo.GetAll(x => x.Reserva!.Id == id);
                if (buscarServicios.Any())
                {
                    listaServicio = await buscarServicios.ToListAsync();
                }
                response.EsCorrecto = true;
                response.Resultado = _mapper.Map<List<ServicioRDTO>>(listaServicio);

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
