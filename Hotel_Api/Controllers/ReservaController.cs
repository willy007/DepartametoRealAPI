using Hotel.DTO;
using Hotel.Modelo;
using Hotel.Servicio.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaServicio _reserva;

        public ReservaController(IReservaServicio reserva)
        {
            _reserva = reserva;
        }

        [HttpGet("Buscar/{id:int}")]
        public async Task<IActionResult> Buscar(int id) {
            var response = new ResponseDTO<ReservaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _reserva.Buscar(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpGet("Habitacion/{id:int}")]
        public async Task<IActionResult> Habitacion(int id)
        {
            var response = new ResponseDTO<HabitacionDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _reserva.Habitacion(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("Persona/{id:int}")]
        public async Task<IActionResult> Persona(int id)
        {
            var response = new ResponseDTO<List<PersonaDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _reserva.Persona(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ReservaDTO nuevo)
        {
            var response = new ResponseDTO<ReservaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _reserva.Registra(nuevo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("RegistraPersona")]
        public async Task<IActionResult> RegistraPersona([FromBody] PersonaReservaDTO nuevo)
        {
            var response = new ResponseDTO<ReservaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _reserva.Registra(nuevo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

        [HttpPost("AgregarDescuento")]
        public async Task<IActionResult> AgregarDescuento([FromBody] DescuentoDTO nuevo)
        {
            var response = new ResponseDTO<DescuentoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _reserva.Registra(nuevo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

        [HttpPost("AgregarServicio")]
        public async Task<IActionResult> AgregarServicio([FromBody] ServicioRDTO nuevo)
        {
            var response = new ResponseDTO<ServicioRDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _reserva.Registra(nuevo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

        [HttpPut("ActualizarReserva")]
        public async Task<IActionResult> ActualizarReserva([FromBody] ReservaDTO nuevo)
        {
            var response = new ResponseDTO<ReservaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _reserva.Actualizar(nuevo);
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
