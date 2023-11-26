using Hotel.DTO;
using Hotel.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicio.Contrato
{
    public interface IPersona
    {
        public Task<PersonaDTO> Crear(PersonaDTO nuevo);

        public Task<bool> Actualizar(PersonaDTO update);

        public Task<PersonaDTO> Buscar(int id);

        public Task<PersonaDTO> Buscar(string identificador);
    }
}
