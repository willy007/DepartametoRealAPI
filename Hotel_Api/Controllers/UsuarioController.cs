using Hotel.DTO;
using Hotel.Servicio.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpGet("Listar/{rol:alpha}")]
        public async Task<IActionResult> Listar(string rol) { 
            var response = new ResponseDTO<List<UsuarioDTO>>();

            try {
                response.EsCorrecto = true;
                response.Resultado = await _usuario.GetUsuarios(rol);

            } catch (Exception ex) {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;            
            }

            return Ok(response);

        }

        [HttpGet("Buscar/{id:int}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _usuario.GetUsuario(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] RegistroUsaurioDTO nuevo)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _usuario.Crear(nuevo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);

        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] RegistroUsaurioDTO nuevo)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _usuario.Editar(nuevo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] SessionDTO login)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _usuario.Login(login);
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
