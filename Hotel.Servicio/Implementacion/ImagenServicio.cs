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
    public class ImagenServicio : IImagen
    {
        private readonly IGenericoRepositorio<ImagenHotel> _ctxRepo;
        private readonly IMapper _mapper;

        public ImagenServicio(IGenericoRepositorio<ImagenHotel> ctxRepo, IMapper mapper)
        {
            _ctxRepo = ctxRepo;
            _mapper = mapper;
        }

        public async Task<ImagenDTO> Crear(CrearImagenDTO imagen)
        {
            try {
                var imagenClase = _mapper.Map<ImagenHotel>(imagen);
                var imagenState = await _ctxRepo.Create(imagenClase);

                return _mapper.Map<ImagenDTO>(imagenState);

            }catch(Exception )
            {
                throw ;
            }
        }

        public async Task<List<ImagenDTO>> imagenHotel(int id)
        {
            try {

                var imagen = _ctxRepo.GetAll(x => x.HotelId == id);
                var iamgelist = await imagen.ToListAsync();

                return _mapper.Map<List<ImagenDTO>>(iamgelist);

            }catch(Exception ) {
                throw ;
            }

        }

        public async Task<bool> Modificar(ImagenDTO imagen)
        {
            try {

                var imagenClase = _mapper.Map<ImagenHotel>(imagen);
                var imgModificado = await _ctxRepo.Update(imagenClase);

                return imgModificado;
                
            }catch(Exception ) { 
                throw  ; 
            }
        }
    }
}
