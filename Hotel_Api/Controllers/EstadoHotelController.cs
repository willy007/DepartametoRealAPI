using AutoMapper;
using Hotel.DTO;
using Hotel.Modelo;
using Hotel.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoHotelController : ControllerBase
    {

        private readonly HotelContext _ctxdb;
        private readonly IMapper _mapper;

        public EstadoHotelController(HotelContext ctxdb, IMapper mapper)
        {
            _ctxdb = ctxdb;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var response = new ResponseDTO<List<EstadoHDTO>>();

            try
            {

                var hotel = _ctxdb.Set<EstadoH>();
                var listaHoteles = await hotel.ToListAsync();
                response.EsCorrecto = true;
                response.Resultado = _mapper.Map<List<EstadoHDTO>>(listaHoteles);

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
