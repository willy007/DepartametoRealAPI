using AutoMapper;
using Hotel.Modelo;
using Hotel.Repositorio.Contrato;
using Hotel.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotel.DTO;

namespace Hotel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly HotelContext _ctxdb;
        private readonly IMapper _mapper;
        private readonly IGenericoRepositorio<Cliente> _genericoRepo;

        public ClienteController(HotelContext ctxdb, IMapper mapper, IGenericoRepositorio<Cliente> genericoRepo)
        {
            _ctxdb = ctxdb;
            _mapper = mapper;
            _genericoRepo = genericoRepo;
        }


        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ClienteDTO clienteBody) {

            var response = new ResponseDTO<ClienteDTO>();

            response.EsCorrecto = false;

            try {

                var clienteMapper = _mapper.Map<Cliente>(clienteBody);
                var newCliente = await _genericoRepo.Create(clienteMapper);
                response.EsCorrecto = true;
                response.Resultado = _mapper.Map<ClienteDTO>(newCliente);

            }catch(Exception ex) { 
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }
    }
}
