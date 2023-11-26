using Hotel.DTO;
using Hotel.Modelo;
using Hotel.Servicio.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersona _persona;

        public PersonaController(IPersona persona)
        {
            _persona = persona;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] PersonaDTO presona) {
            var response = new ResponseDTO<PersonaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _persona.Crear(presona);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);

        }

        [HttpGet("Buscar/identificador:alpha")]
        public async Task<IActionResult> Buscar(string identificador)
        {
            var response = new ResponseDTO<PersonaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _persona.Buscar(identificador);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);

        }

        [HttpGet("BuscarId/id:int")]
        public async Task<IActionResult> BuscarId(int id)
        {
            var response = new ResponseDTO<PersonaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _persona.Buscar(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);

        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] PersonaDTO presona)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _persona.Actualizar(presona);
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
