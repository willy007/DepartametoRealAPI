using AutoMapper;
using Hotel.DTO;
using Hotel.Modelo;
using Hotel.Repositorio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicio.Contrato
{
    public interface IUsuario
    {

        Task<List<UsuarioDTO>> GetUsuarios(string Tipo );

        Task<UsuarioDTO> GetUsuario(int Id);

        Task<UsuarioDTO> Login(SessionDTO sesion);

        Task<UsuarioDTO> Crear(RegistroUsaurioDTO registor);

        Task<bool> Editar(RegistroUsaurioDTO user);
    }
}
