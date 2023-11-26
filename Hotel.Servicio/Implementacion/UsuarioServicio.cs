using AutoMapper;
using Hotel.DTO;
using Hotel.Modelo;
using Hotel.Repositorio;
using Hotel.Repositorio.Contrato;
using Hotel.Servicio.Contrato;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicio.Implementacion
{
    public class UsuarioServicio : IUsuario
    {
        private readonly IGenericoRepositorio<Usuario> _repo ;
        private readonly IMapper _mapper;
        private readonly HotelContext _ctxdb;

        public UsuarioServicio(IGenericoRepositorio<Usuario> repo, IMapper mapper, HotelContext ctxdb)
        {
            _repo = repo;
            _mapper = mapper;
            _ctxdb = ctxdb;
        }

        public async Task<UsuarioDTO> Crear(RegistroUsaurioDTO registor)
        {
            using (var transaction = _ctxdb.Database.BeginTransaction()) { 

                try
                {
                    var transformUser = _mapper.Map<Usuario>(registor);
                    transformUser.Id = transformUser.IdNavigation.Id;
                    transformUser.IdNavigation = new Persona();

                    transaction.CreateSavepoint("BeforeCreateUser");


                    var busquedaP =  _ctxdb.Set<Persona>().Where(x => x.Identificador == registor.IdNavigation.Identificador && x.Usuario != null ).Count();
                    if (busquedaP > 0) {
                        throw new TaskCanceledException("La person ya existe");
                    }

                    _ctxdb.Set<Usuario>().Add(transformUser);
                    await _ctxdb.SaveChangesAsync();

                    var p = transformUser.IdNavigation;

                    p.Id = transformUser.Id;
                    p.Identificador = registor.IdNavigation.Identificador;
                    p.Nombre = registor.IdNavigation.Nombre;
                    p.Apellido = registor.IdNavigation.Apellido;
                    p.Correo = registor.IdNavigation.Correo;
                    p.Telefono = registor.IdNavigation.Telefono;


                    _ctxdb.Set<Persona>().Update(p);
                    await _ctxdb.SaveChangesAsync();

                    transaction.Commit();

                    return _mapper.Map<UsuarioDTO>(transformUser);
                }
                catch (Exception ) {
                    transaction.RollbackToSavepoint("BeforeCreateUser"); 
                    throw ;
                }
            }
        }

        public async Task<bool> Editar(RegistroUsaurioDTO user)
        {
            using (var transaction = _ctxdb.Database.BeginTransaction())
            {
                try {

                    var transformUser = _mapper.Map<Usuario>(user);

                    var busquedaUsuario = _repo.GetAll(x => x.Id == user.IdNavigation.Id);
                    var usuarioEncontrado = await busquedaUsuario.FirstOrDefaultAsync();

                    if (usuarioEncontrado == null) { 
                        throw new TaskCanceledException("El usuario no existe");
                    }

                    transaction.CreateSavepoint("BeforeCreateUser");

                    transformUser.Id = usuarioEncontrado.Id;

                    if (transformUser.Contrasena == "") {
                        transformUser.Contrasena = usuarioEncontrado.Contrasena;
                    }

                    _ctxdb.Set<Usuario>().Update(transformUser);
                    await _ctxdb.SaveChangesAsync();

                    var p = transformUser.IdNavigation;

                    p.Id = transformUser.Id;
                    p.Identificador = user.IdNavigation.Identificador;
                    p.Nombre = user.IdNavigation.Nombre;
                    p.Apellido = user.IdNavigation.Apellido;
                    p.Correo = user.IdNavigation.Correo;
                    p.Telefono = user.IdNavigation.Telefono;

                    _ctxdb.Set<Persona>().Update(p);
                    await _ctxdb.SaveChangesAsync();

                    transaction.Commit();

                    return true;

                }
                catch (Exception ) {
                    transaction.RollbackToSavepoint("BeforeCreateUser");
                    throw;
                }

            }
        }

        public async Task<UsuarioDTO> GetUsuario(int Id)
        {
            try {

                var busquedaUsuario = _repo.GetAll(x => x.Id == Id);
                var usuarioEncontrado = await busquedaUsuario.FirstOrDefaultAsync();

                if (usuarioEncontrado == null)
                {
                    throw new TaskCanceledException("Usuario No encontrado");
                }
                else {
                    return _mapper.Map<UsuarioDTO>(usuarioEncontrado);
                }

            }catch(Exception ) {
                throw ;
            }

        }

        public async Task<List<UsuarioDTO>> GetUsuarios(string Tipo)
        {
            try
            {
                var usuarios = _repo.GetAll(x => x.Tipo == Tipo);
                var listaUsuarios = await usuarios.ToListAsync();
                for (int i = 0; i < listaUsuarios.Count(); i++) {
                    listaUsuarios[i].IdNavigation = _ctxdb.Set<Persona>().Where(x => x.Id == listaUsuarios[i].Id).First();
                }

                if (listaUsuarios.Count == 0) {
                    throw new TaskCanceledException($"No existen Usuarios tipo {Tipo}");
                }

                return _mapper.Map<List<UsuarioDTO>>(listaUsuarios);

            }
            catch (Exception ) {
                throw ;
            }

        }

        public async Task<UsuarioDTO> Login(SessionDTO sesion)
        {
            try { 

                var busqueda = _repo.GetAll(x => x.Nombre == sesion.Nombre && x.Contrasena == sesion.Contrasena);
                var usuario = await busqueda.FirstOrDefaultAsync();


                if (usuario == null)
                {
                    throw new TaskCanceledException("Usuario o contraseña incorrectos");
                }
                else {
                    return _mapper.Map<UsuarioDTO>(usuario);
                }

            }catch (Exception ) {

                throw ;

            }


        }
    }
}
