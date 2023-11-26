using AutoMapper;
using Hotel.DTO;
using Hotel.Modelo;
using Hotel.Repositorio;
using Hotel.Repositorio.Contrato;
using Hotel.Servicio.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncargadoHotelController : ControllerBase
    {

        private readonly IGenericoRepositorio<Encargado> _genericoRepo;
        private readonly HotelContext _ctxdb;
        private readonly IMapper _mapper;

        public EncargadoHotelController(IGenericoRepositorio<Encargado> genericoRepo, HotelContext ctxdb, IMapper mapper)
        {
            _genericoRepo = genericoRepo;
            _ctxdb = ctxdb;
            _mapper = mapper;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] EncargadoDTO encargado)
        {
            var response = new ResponseDTO<EncargadoDTO>();

            response.EsCorrecto = false;

            try { 

                var map = _mapper.Map<Encargado>(encargado);

                var validarExitencia = await _genericoRepo.GetAll(x => x.UsuarioId == encargado.UsuarioId).ToListAsync(); ;

                if (validarExitencia.Count > 0)
                {
                    throw new TaskCanceledException("Ya tiene asignado el hotel");
                }

                var create = await _genericoRepo.Create(map);
                
                var encargadoMa = _mapper.Map<EncargadoDTO>(create);

                response.Resultado = encargadoMa;
                response.EsCorrecto = true;
                
            }catch (Exception ex) {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] EncargadoDTO encargado) 
        {
            var response = new ResponseDTO<EncargadoDTO>();

            response.EsCorrecto = false;

            try
            {

                var map = _mapper.Map<Encargado>(encargado);

                var validarExitencia = await _genericoRepo.GetAll(x => x.UsuarioId == encargado.UsuarioId).ToListAsync(); ;

                foreach (var en in validarExitencia) {
                    var estado = await _genericoRepo.Delete(en);
                    if (!estado) { 
                        throw new TaskCanceledException("Error al actualizar el encargado (1)");
                    }
                }

                var create = await _genericoRepo.Create(map);

                var encargadoMa = _mapper.Map<EncargadoDTO>(create);

                response.Resultado = encargadoMa;
                response.EsCorrecto = true;

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }
        


        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] EncargadoDTO encargado)
        {
            
            var response = new ResponseDTO<bool>();

            response.EsCorrecto = false;

            try
            {

                var map = _mapper.Map<Encargado>(encargado);

                var validarExitencia = await _genericoRepo.GetAll(x => x.UsuarioId == encargado.UsuarioId).ToListAsync(); ;

                foreach (var en in validarExitencia)
                {
                    var estado = await _genericoRepo.Delete(en);
                    if (!estado)
                    {
                        throw new TaskCanceledException("Error al Eliminar datos de encargado (1)");
                    }
                }

                response.Resultado = true;
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
