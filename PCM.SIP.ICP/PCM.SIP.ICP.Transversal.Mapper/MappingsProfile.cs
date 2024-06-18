using AutoMapper;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Transversal.Contracts.Seguridad.Request;
using PCM.SIP.ICP.Transversal.Contracts.Seguridad.Response;

namespace PCM.SIP.ICP.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            #region EntidadGrupo

            CreateMap<EntidadGrupo, EntidadGrupoDto>().ReverseMap()
                .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
                .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
                .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
                .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<EntidadGrupoDto, EntidadGrupoIdRequest>().ReverseMap()
                .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey));

            CreateMap<EntidadGrupoDto, EntidadGrupoInsertRequest>().ReverseMap()
                .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
                .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<EntidadGrupoDto, EntidadGrupoUpdateRequest>().ReverseMap()
                .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
                .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
                .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<EntidadGrupoDto, EntidadGrupoFilterRequest>().ReverseMap()
                .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
                .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            CreateMap<EntidadGrupoDto, EntidadGrupoResponse>().ReverseMap()
                .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
                .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
                .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
                .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            #endregion

            #region Persona

            CreateMap<Persona, PersonaDto>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellido_paterno, source => source.MapFrom(src => src.apellido_paterno))
            .ForMember(destination => destination.apellido_materno, source => source.MapFrom(src => src.apellido_materno))
            .ForMember(destination => destination.numdocumento, source => source.MapFrom(src => src.numdocumento))
            .ForMember(destination => destination.email, source => source.MapFrom(src => src.email))
            .ForMember(destination => destination.telefono_movil, source => source.MapFrom(src => src.telefono_movil))
            .ForMember(destination => destination.username, source => source.MapFrom(src => src.username))
            .ForMember(destination => destination.password, source => source.MapFrom(src => src.password))
            .ForMember(destination => destination.interno, source => source.MapFrom(src => src.interno))
            .ForMember(destination => destination.habilitado, source => source.MapFrom(src => src.habilitado))
            .ForMember(destination => destination.perfileskey, source => source.MapFrom(src => src.perfileskey))
            .ForMember(destination => destination.usuario, source => source.MapFrom(src => src.usuario));

            CreateMap<PersonaDto, PersonaIdRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey));

            CreateMap<PersonaDto, PersonaInsertRequest>().ReverseMap()
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellido_paterno, source => source.MapFrom(src => src.apellido_paterno))
            .ForMember(destination => destination.apellido_materno, source => source.MapFrom(src => src.apellido_materno))
            .ForMember(destination => destination.numdocumento, source => source.MapFrom(src => src.numdocumento))
            .ForMember(destination => destination.email, source => source.MapFrom(src => src.email))
            .ForMember(destination => destination.telefono_movil, source => source.MapFrom(src => src.telefono_movil))
            .ForMember(destination => destination.interno, source => source.MapFrom(src => src.interno))
            .ForMember(destination => destination.habilitado, source => source.MapFrom(src => src.habilitado))
            .ForMember(destination => destination.perfileskey, source => source.MapFrom(src => src.perfileskey));

            CreateMap<PersonaDto, PersonaUpdateRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellido_paterno, source => source.MapFrom(src => src.apellido_paterno))
            .ForMember(destination => destination.apellido_materno, source => source.MapFrom(src => src.apellido_materno))
            .ForMember(destination => destination.numdocumento, source => source.MapFrom(src => src.numdocumento))
            .ForMember(destination => destination.email, source => source.MapFrom(src => src.email))
            .ForMember(destination => destination.telefono_movil, source => source.MapFrom(src => src.telefono_movil))
            .ForMember(destination => destination.perfileskey, source => source.MapFrom(src => src.perfileskey))
            .ForMember(destination => destination.username, source => source.MapFrom(src => src.username))
            .ForMember(destination => destination.password, source => source.MapFrom(src => src.password))
            .ForMember(destination => destination.interno, source => source.MapFrom(src => src.interno))
            .ForMember(destination => destination.habilitado, source => source.MapFrom(src => src.habilitado));

            CreateMap<PersonaDto, PersonaFilterRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            CreateMap<PersonaDto, PersonaResponse>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellido_paterno, source => source.MapFrom(src => src.apellido_paterno))
            .ForMember(destination => destination.apellido_materno, source => source.MapFrom(src => src.apellido_materno))
            .ForMember(destination => destination.numdocumento, source => source.MapFrom(src => src.numdocumento))
            .ForMember(destination => destination.email, source => source.MapFrom(src => src.email))
            .ForMember(destination => destination.telefono_movil, source => source.MapFrom(src => src.telefono_movil))
            .ForMember(destination => destination.usuario, source => source.MapFrom(src => src.usuario));

            #endregion

            #region Usuario

            CreateMap<PersonaDto, InsertUsuarioRequest>()
            .ForMember(destination => destination.personakey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.perfileskey, source => source.MapFrom(src => src.perfileskey))
            .ForMember(dest => dest.nombre_completo, opt => opt.MapFrom(src => $"{src.nombres} {src.apellido_paterno} {src.apellido_materno}"))
            .ForMember(destination => destination.username, source => source.MapFrom(src => src.numdocumento))
            .ForMember(destination => destination.password, source => source.MapFrom(src => src.numdocumento))
            .ForMember(destination => destination.interno, source => source.MapFrom(src => src.interno))
            .ForMember(destination => destination.numdocumento, source => source.MapFrom(src => src.numdocumento))
            .ReverseMap();

            CreateMap<PersonaDto, InsertUsuarioRequest>()
           .ForMember(destination => destination.perfileskey, source => source.MapFrom(src => src.perfileskey))
           .ForMember(dest => dest.nombre_completo, opt => opt.MapFrom(src => $"{src.nombres} {src.apellido_paterno} {src.apellido_materno}"))           
           .ForMember(destination => destination.username, source => source.MapFrom(src => src.numdocumento))
           .ForMember(destination => destination.password, source => source.MapFrom(src => src.numdocumento))
           .ForMember(destination => destination.interno, source => source.MapFrom(src => src.interno))
           .ForMember(destination => destination.habilitado, source => source.MapFrom(src => src.habilitado))
           .ForMember(destination => destination.numdocumento, source => source.MapFrom(src => src.numdocumento))
           .ReverseMap();

            CreateMap<PersonaDto, UpdateUsuarioRequest>()
            .ForMember(dest => dest.nombre_completo, opt => opt.MapFrom(src => $"{src.nombres} {src.apellido_paterno} {src.apellido_materno}"))
            .ForMember(destination => destination.perfileskey, source => source.MapFrom(src => src.perfileskey))
            .ForMember(destination => destination.username, source => source.MapFrom(src => src.username))
            .ForMember(destination => destination.password, source => source.MapFrom(src => src.password))
            .ForMember(destination => destination.interno, source => source.MapFrom(src => src.interno))
            .ForMember(destination => destination.habilitado, source => source.MapFrom(src => src.habilitado))
            .ForMember(destination => destination.numdocumento, source => source.MapFrom(src => src.numdocumento))
            .ReverseMap();

            CreateMap<Usuario, UsuarioResponse>().ReverseMap()
            .ForMember(destination => destination.username, source => source.MapFrom(src => src.username))
            .ForMember(destination => destination.password, source => source.MapFrom(src => src.password))
            .ForMember(destination => destination.interno, source => source.MapFrom(src => src.interno))
            .ForMember(destination => destination.habilitado, source => source.MapFrom(src => src.habilitado))            
            .ForMember(destination => destination.lista_perfiles, source => source.MapFrom(src => src.lista_perfiles));

            CreateMap<Usuario, UsuarioDto>().ReverseMap()
           .ForMember(destination => destination.username, source => source.MapFrom(src => src.username))
           .ForMember(destination => destination.password, source => source.MapFrom(src => src.password))
           .ForMember(destination => destination.interno, source => source.MapFrom(src => src.interno))
           .ForMember(destination => destination.habilitado, source => source.MapFrom(src => src.habilitado))
           .ForMember(destination => destination.lista_perfiles, source => source.MapFrom(src => src.lista_perfiles));

            #endregion

            #region Perfil

            CreateMap<Perfil, PerfilUsuarioResponse>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura));

            CreateMap<Perfil, PerfilDto>().ReverseMap()
            .ForMember(destination => destination.serialKey, source => source.MapFrom(src => src.serialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura));

            #endregion

            #region TipoSector

            CreateMap<TipoSector, TipoSectorDto>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<TipoSectorDto, TipoSectorResponse>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            #endregion

            #region EntidadSector

            CreateMap<EntidadSector, EntidadSectorDto>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.tiposectorkey, source => source.MapFrom(src => src.tiposectorkey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion))
            .ForMember(destination => destination.tiposector, source => source.MapFrom(src => src.tiposector));

            CreateMap<EntidadSectorDto, EntidadSectorResponse>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.tiposectorkey, source => source.MapFrom(src => src.tiposectorkey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion))
            .ForMember(destination => destination.tiposector, source => source.MapFrom(src => src.tiposector));

            CreateMap<EntidadSectorDto, EntidadSectorFilterRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            #endregion

            #region ModalidadIntegridad

            CreateMap<ModalidadIntegridad, ModalidadIntegridadDto>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<ModalidadIntegridadDto, ModalidadIntegridadResponse>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<ModalidadIntegridadDto, ModalidadIntegridadFilterRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            #endregion

        }
    }
}
