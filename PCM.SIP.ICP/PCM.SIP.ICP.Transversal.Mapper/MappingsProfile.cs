using AutoMapper;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Domain.Entities;

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
        }
    }
}
