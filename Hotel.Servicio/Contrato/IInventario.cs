using Hotel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicio.Contrato
{
    public interface IInventario
    {
        public Task<InventarioDTO> Crear(InventarioDTO nuevo);

        public Task<bool> Editar(InventarioDTO nuevo);

        public Task<bool> Eliminar(InventarioDTO nuevo);

        public Task<List<InventarioDTO>> TraerHotel(int id);
    }
}
