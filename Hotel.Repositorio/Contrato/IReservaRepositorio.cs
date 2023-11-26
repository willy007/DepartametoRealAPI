using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Modelo;

namespace Hotel.Repositorio.Contrato
{
    public interface IReservaRepositorio : IGenericoRepositorio<Reserva>
    {

        Task<Reserva> Registra(Reserva reserva);

        Task<ServicioR> Registra(int id, ServicioR servicio);

        Task<Descuento> Registra(int id, Descuento descuento);

        Task<Reserva> Registra(int id, Persona persona);

        Task<List<Persona>> Persona(int id);
        
        Task<Habitacion> Habitacion(int id);
    }
}
