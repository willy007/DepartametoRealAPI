using Hotel.DTO;
using Hotel.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicio.Contrato
{
    public interface IReservaServicio
    {
        Task<ReservaDTO> Registra(ReservaDTO reserva);

        Task<ServicioRDTO> Registra(ServicioRDTO servicio);

        Task<DescuentoDTO> Registra(DescuentoDTO descuento);

        Task<ReservaDTO> Registra(PersonaReservaDTO persona);

        Task<List<PersonaDTO>> Persona(int id);

        Task<HabitacionDTO> Habitacion(int id);

        public Task<ReservaDTO> Actualizar(ReservaDTO update);

        public Task<ReservaDTO> Buscar(int id);

    }
}
