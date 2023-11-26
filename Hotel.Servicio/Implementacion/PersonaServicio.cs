using AutoMapper;
using Hotel.DTO;
using Hotel.Modelo;
using Hotel.Repositorio.Contrato;
using Hotel.Servicio.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicio.Implementacion
{
    public class PersonaServicio : IPersona
    {

        private readonly IGenericoRepositorio<Persona> _ctxRepo;
        private readonly IMapper _mapper;

        public PersonaServicio(IGenericoRepositorio<Persona> repo, IMapper mapper)
        {
            _ctxRepo = repo;
            _mapper = mapper;
        }

        public async Task<bool> Actualizar(PersonaDTO update)
        {
            try
            {
                var mapPersona = _mapper.Map<Persona>(update);
                var personaActualizada = await _ctxRepo.Update(mapPersona);

                return personaActualizada;

            }
            catch (Exception )
            {
                throw ;
            }
        }

        public async Task<PersonaDTO> Buscar(int id)
        {
            try
            {
                var ListaPersonaBuscada = _ctxRepo.GetAll(x => x.Id == id);
                var PersonaBuscada = await ListaPersonaBuscada.FirstAsync();

                return _mapper.Map<PersonaDTO>(PersonaBuscada);
            }
            catch (Exception )
            {
                throw ;
            }
        }

        public async Task<PersonaDTO> Buscar(string identificador)
        {
            try
            {
                var ListaPersonaBuscada = _ctxRepo.GetAll(x => x.Identificador == identificador);
                var PersonaBuscada = await ListaPersonaBuscada.FirstAsync();

                return _mapper.Map<PersonaDTO>(PersonaBuscada);
            }
            catch (Exception )
            {
                throw ;
            }
        }

        public async Task<PersonaDTO> Crear(PersonaDTO nuevo)
        {
            try 
            {
                var PersonaCreada = new Hotel.Modelo.Persona();
                var mapPersona = _mapper.Map<Persona>(nuevo);
                var siExistePersonaList =  _ctxRepo.GetAll(x => x.Identificador == mapPersona.Identificador && x.Usuario == null);
                var validacion = siExistePersonaList.Any();
                if (!validacion)
                {
                    PersonaCreada = await _ctxRepo.Create(mapPersona);
                }
                else {
                    var siExistePersona = await siExistePersonaList.FirstAsync();
                    await _ctxRepo.Update(siExistePersona);
                    PersonaCreada = siExistePersona;
                }

                return _mapper.Map<PersonaDTO>(PersonaCreada);

            }
            catch (Exception ){
                throw ;
            }
        }

       
    }
}
