using Hotel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicio.Contrato
{
    public interface IHotelServicio
    {
        public Task<HotelDTO> Crear(HotelDTO nuevo);

        public Task<bool> Editar(HotelDTO nuevo);

        public Task<bool> Eliminar(int id);

        public Task<HotelDTO> Buscar(int id);

        public Task<List<HotelDTO>> Listar();

    }
}
