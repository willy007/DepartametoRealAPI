using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel.Modelo;
using Hotel.DTO;

namespace Hotel.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            #region Usuario

            CreateMap<Usuario,UsuarioDTO>().ForMember(des => des.IdNavigation , act => act.MapFrom(src => src.IdNavigation));
            CreateMap<RegistroUsaurioDTO,Usuario>();
            CreateMap<SessionDTO,Usuario>();
            CreateMap<PersonaDTO,Persona>();
            CreateMap<Persona,PersonaDTO>();

            #endregion

            #region Imagen

            CreateMap<CrearImagenDTO, ImagenHotel>();
            CreateMap<ImagenDTO, ImagenHotel>();
            CreateMap<ImagenHotel, ImagenDTO>();

            #endregion

            #region Inventario

            CreateMap<InventarioDTO,Inventario>();
            CreateMap<Inventario,InventarioDTO>();

            #endregion

            #region Persona
            CreateMap<PersonaDTO, Persona>();
            CreateMap<Persona, PersonaDTO>();

            CreateMap<PersonaDTO, PersonaReservaDTO>();
            CreateMap<PersonaReservaDTO, PersonaDTO>();

            #endregion

            #region Hotel

            CreateMap<HotelDTO, Modelo.Hotel>();
            CreateMap<Modelo.Hotel ,HotelDTO>();
            CreateMap<Modelo.Hotel, HotelServicioDTO>().ForMember(des => des.ServicioHs , act => act.MapFrom(src => src.ServicioHs));

            #endregion

            #region EstadoReserva

            CreateMap<EstadoR, EstadoRDTO>();
            CreateMap<EstadoRDTO,EstadoR >();

            #endregion

            #region ServicioReserva

            CreateMap<ServicioR, ServicioRDTO>();
            CreateMap<ServicioRDTO ,ServicioR>();

            #endregion

            #region Reserva

            CreateMap<Reserva, ReservaDTO>();
            CreateMap<ReservaDTO ,Reserva>();

            #endregion

            #region Descuento

            CreateMap<Descuento, DescuentoDTO>();
            CreateMap<DescuentoDTO ,Descuento>();

            #endregion

            #region Habitacion

            CreateMap<Habitacion, HabitacionDTO>();
            CreateMap<HabitacionDTO ,Habitacion>();

            #endregion

            #region TipoHabitacion

            CreateMap<TipoHabitacion, TipoHabitacionDTO>();
            CreateMap<TipoHabitacionDTO , TipoHabitacion>();

            #endregion

            #region EstadoH

            CreateMap<EstadoH, EstadoHDTO>();

            #endregion

            #region ServicioHotel

            CreateMap<ServicioH, ServicioHDTO>();
            CreateMap<ServicioHDTO, ServicioH>();

            #endregion

            #region Encargado

            CreateMap<EncargadoDTO, Encargado>();
            CreateMap<Encargado, EncargadoDTO>();

            #endregion

            #region Cliente

            CreateMap<ClienteDTO, Cliente>();
            CreateMap<Cliente , ClienteDTO>();

            #endregion

        }

    }
}
