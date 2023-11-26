using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.DTO;

namespace Hotel.Servicio.Contrato
{
    public interface IImagen
    {

        Task<ImagenDTO> Crear(CrearImagenDTO imagen);

        Task<List<ImagenDTO>> imagenHotel(int id);

        Task<bool> Modificar(ImagenDTO imagen);
    }
}
