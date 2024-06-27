﻿using AutoMapper;
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

            CreateMap<EntidadGrupo, EntidadGrupoEntidadResponse>().ReverseMap()
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
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
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
            .ForMember(destination => destination.entidad, source => source.MapFrom(src => src.entidad))
            .ForMember(destination => destination.usuario, source => source.MapFrom(src => src.usuario));

            CreateMap<PersonaDto, PersonaIdRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey));

            CreateMap<PersonaDto, PersonaInsertRequest>().ReverseMap()
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
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
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
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
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellido_paterno, source => source.MapFrom(src => src.apellido_paterno))
            .ForMember(destination => destination.apellido_materno, source => source.MapFrom(src => src.apellido_materno))
            .ForMember(destination => destination.numdocumento, source => source.MapFrom(src => src.numdocumento))
            .ForMember(destination => destination.email, source => source.MapFrom(src => src.email))
            .ForMember(destination => destination.telefono_movil, source => source.MapFrom(src => src.telefono_movil))
            .ForMember(destination => destination.entidad, source => source.MapFrom(src => src.entidad))
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

            CreateMap<EntidadSector, EntidadSectorEntidadResponse>().ReverseMap()
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

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

            CreateMap<ModalidadIntegridad, ModalidadIntegridadEntidadResponse>().ReverseMap()
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

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

            #region DocumentoEstructura

            CreateMap<DocumentoEstructura, DocumentoEstructuraDto>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<DocumentoEstructura, DocumentoEstructuraEntidadResponse>().ReverseMap()
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<DocumentoEstructura, DocumentoEstructuraDto>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<DocumentoEstructuraDto, DocumentoEstructuraResponse>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<DocumentoEstructuraDto, DocumentoEstructuraFilterRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            #endregion

            #region Ubigeo

            CreateMap<Ubigeo, UbigeoDto>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.departamento_inei, source => source.MapFrom(src => src.departamento_inei))
            .ForMember(destination => destination.provincia_inei, source => source.MapFrom(src => src.provincia_inei))
            .ForMember(destination => destination.departamento, source => source.MapFrom(src => src.departamento))
            .ForMember(destination => destination.provincia, source => source.MapFrom(src => src.provincia))
            .ForMember(destination => destination.distrito, source => source.MapFrom(src => src.distrito));

            CreateMap<Ubigeo, UbigeoEntidadResponse>().ReverseMap()
            .ForMember(destination => destination.departamento_inei, source => source.MapFrom(src => src.departamento_inei))
            .ForMember(destination => destination.provincia_inei, source => source.MapFrom(src => src.provincia_inei))
            .ForMember(destination => destination.departamento, source => source.MapFrom(src => src.departamento))
            .ForMember(destination => destination.provincia, source => source.MapFrom(src => src.provincia))
            .ForMember(destination => destination.distrito, source => source.MapFrom(src => src.distrito));

            CreateMap<UbigeoDto, ProvinciaFilterRequest>().ReverseMap()
            .ForMember(destination => destination.departamento_inei, source => source.MapFrom(src => src.departamento_inei));

            CreateMap<UbigeoDto, DistritoFilterRequest>().ReverseMap()
            .ForMember(destination => destination.provincia_inei, source => source.MapFrom(src => src.provincia_inei));

            CreateMap<UbigeoDto, DepartamentoResponse>().ReverseMap()
            .ForMember(destination => destination.departamento_inei, source => source.MapFrom(src => src.departamento_inei))
            .ForMember(destination => destination.departamento, source => source.MapFrom(src => src.departamento));

            CreateMap<UbigeoDto, ProvinciaResponse>().ReverseMap()
            .ForMember(destination => destination.departamento_inei, source => source.MapFrom(src => src.departamento_inei))
            .ForMember(destination => destination.provincia_inei, source => source.MapFrom(src => src.provincia_inei))
            .ForMember(destination => destination.provincia, source => source.MapFrom(src => src.provincia));

            CreateMap<UbigeoDto, DistritoResponse>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.distrito, source => source.MapFrom(src => src.distrito));

            #endregion

            #region Entidad

            CreateMap<Entidad, EntidadDto>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadgrupokey, source => source.MapFrom(src => src.entidadgrupokey))
            .ForMember(destination => destination.entidadsectorkey, source => source.MapFrom(src => src.entidadsectorkey))
            .ForMember(destination => destination.ubigeokey, source => source.MapFrom(src => src.ubigeokey))
            .ForMember(destination => destination.documentoestructurakey, source => source.MapFrom(src => src.documentoestructurakey))
            .ForMember(destination => destination.modalidadintegridadkey, source => source.MapFrom(src => src.modalidadintegridadkey))
            .ForMember(destination => destination.numero_ruc, source => source.MapFrom(src => src.numero_ruc))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.acronimo, source => source.MapFrom(src => src.acronimo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre))
            .ForMember(destination => destination.generalidades, source => source.MapFrom(src => src.generalidades))
            .ForMember(destination => destination.documentoestructura_doc, source => source.MapFrom(src => src.documentoestructura_doc))
            .ForMember(destination => destination.modalidadintegridad_doc, source => source.MapFrom(src => src.modalidadintegridad_doc))
            .ForMember(destination => destination.modalidadintegridad_anterior, source => source.MapFrom(src => src.modalidadintegridad_anterior))
            .ForMember(destination => destination.documentointegridad_desc, source => source.MapFrom(src => src.documentointegridad_desc))
            .ForMember(destination => destination.documentointegridad_doc, source => source.MapFrom(src => src.documentointegridad_doc))
            .ForMember(destination => destination.num_servidores, source => source.MapFrom(src => src.num_servidores))
            .ForMember(destination => destination.ubigeo, source => source.MapFrom(src => src.ubigeo))
            .ForMember(destination => destination.modalidadintegridad, source => source.MapFrom(src => src.modalidadintegridad))
            .ForMember(destination => destination.documentoestructura, source => source.MapFrom(src => src.documentoestructura))
            .ForMember(destination => destination.entidadsector, source => source.MapFrom(src => src.entidadsector))
            .ForMember(destination => destination.entidadgrupo, source => source.MapFrom(src => src.entidadgrupo))
            .ForMember(destination => destination.documento_estructura, source => source.MapFrom(src => src.documento_estructura))
            .ForMember(destination => destination.documento_modalidadintegridad, source => source.MapFrom(src => src.documento_modalidadintegridad))
            .ForMember(destination => destination.documento_integridad, source => source.MapFrom(src => src.documento_integridad));

            CreateMap<EntidadDto, EntidadIdRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey));

            CreateMap<EntidadDto, EntidadInsertRequest>().ReverseMap()
            .ForMember(destination => destination.entidadgrupokey, source => source.MapFrom(src => src.entidadgrupokey))
            .ForMember(destination => destination.entidadsectorkey, source => source.MapFrom(src => src.entidadsectorkey))
            .ForMember(destination => destination.numero_ruc, source => source.MapFrom(src => src.numero_ruc))
            .ForMember(destination => destination.acronimo, source => source.MapFrom(src => src.acronimo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre));

            CreateMap<EntidadDto, EntidadUpdateRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadgrupokey, source => source.MapFrom(src => src.entidadgrupokey))
            .ForMember(destination => destination.entidadsectorkey, source => source.MapFrom(src => src.entidadsectorkey))
            .ForMember(destination => destination.numero_ruc, source => source.MapFrom(src => src.numero_ruc))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.acronimo, source => source.MapFrom(src => src.acronimo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre));

            CreateMap<EntidadDto, GeneralidadesUpdateRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.ubigeokey, source => source.MapFrom(src => src.ubigeokey))
            .ForMember(destination => destination.documentoestructurakey, source => source.MapFrom(src => src.documentoestructurakey))
            .ForMember(destination => destination.modalidadintegridadkey, source => source.MapFrom(src => src.modalidadintegridadkey))
            .ForMember(destination => destination.modalidadintegridad_anterior, source => source.MapFrom(src => src.modalidadintegridad_anterior))
            .ForMember(destination => destination.documentointegridad_desc, source => source.MapFrom(src => src.documentointegridad_desc))
            .ForMember(destination => destination.num_servidores, source => source.MapFrom(src => src.num_servidores))
            .ForMember(destination => destination.documento_estructura, source => source.MapFrom(src => src.documento_estructura))
            .ForMember(destination => destination.documento_integridad, source => source.MapFrom(src => src.documento_integridad))
            .ForMember(destination => destination.documento_modalidadintegridad, source => source.MapFrom(src => src.documento_modalidadintegridad));

            CreateMap<EntidadDto, EntidadFilterRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadgrupokey, source => source.MapFrom(src => src.entidadgrupokey))
            .ForMember(destination => destination.entidadsectorkey, source => source.MapFrom(src => src.entidadsectorkey))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            CreateMap<EntidadDto, GeneralidadesFilterRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadgrupokey, source => source.MapFrom(src => src.entidadgrupokey))
            .ForMember(destination => destination.entidadsectorkey, source => source.MapFrom(src => src.entidadsectorkey))
            .ForMember(destination => destination.ubigeokey, source => source.MapFrom(src => src.ubigeokey))
            .ForMember(destination => destination.modalidadintegridadkey, source => source.MapFrom(src => src.modalidadintegridadkey))
            .ForMember(destination => destination.documentoestructurakey, source => source.MapFrom(src => src.documentoestructurakey))
            .ForMember(destination => destination.generalidades, source => source.MapFrom(src => src.generalidades))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            CreateMap<EntidadDto, EntidadResponse>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadgrupokey, source => source.MapFrom(src => src.entidadgrupokey))
            .ForMember(destination => destination.entidadsectorkey, source => source.MapFrom(src => src.entidadsectorkey))
            .ForMember(destination => destination.numero_ruc, source => source.MapFrom(src => src.numero_ruc))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.acronimo, source => source.MapFrom(src => src.acronimo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre))
            .ForMember(destination => destination.entidadsector, source => source.MapFrom(src => src.entidadsector))
            .ForMember(destination => destination.entidadgrupo, source => source.MapFrom(src => src.entidadgrupo));

            CreateMap<EntidadDto, GeneralidadesResponse>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadgrupokey, source => source.MapFrom(src => src.entidadgrupokey))
            .ForMember(destination => destination.entidadsectorkey, source => source.MapFrom(src => src.entidadsectorkey))
            .ForMember(destination => destination.ubigeokey, source => source.MapFrom(src => src.ubigeokey))
            .ForMember(destination => destination.documentoestructurakey, source => source.MapFrom(src => src.documentoestructurakey))
            .ForMember(destination => destination.modalidadintegridadkey, source => source.MapFrom(src => src.modalidadintegridadkey))
            .ForMember(destination => destination.numero_ruc, source => source.MapFrom(src => src.numero_ruc))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.acronimo, source => source.MapFrom(src => src.acronimo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre))
            .ForMember(destination => destination.generalidades, source => source.MapFrom(src => src.generalidades))
            .ForMember(destination => destination.modalidadintegridad_anterior, source => source.MapFrom(src => src.modalidadintegridad_anterior))
            .ForMember(destination => destination.documentointegridad_desc, source => source.MapFrom(src => src.documentointegridad_desc))
            .ForMember(destination => destination.num_servidores, source => source.MapFrom(src => src.num_servidores))
            .ForMember(destination => destination.ubigeo, source => source.MapFrom(src => src.ubigeo))
            .ForMember(destination => destination.modalidadintegridad, source => source.MapFrom(src => src.modalidadintegridad))
            .ForMember(destination => destination.documentoestructura, source => source.MapFrom(src => src.documentoestructura))
            .ForMember(destination => destination.entidadsector, source => source.MapFrom(src => src.entidadsector))
            .ForMember(destination => destination.entidadgrupo, source => source.MapFrom(src => src.entidadgrupo))
            .ForMember(destination => destination.documento_estructura, source => source.MapFrom(src => src.documento_estructura))
            .ForMember(destination => destination.documento_modalidadintegridad, source => source.MapFrom(src => src.documento_modalidadintegridad))
            .ForMember(destination => destination.documento_integridad, source => source.MapFrom(src => src.documento_integridad));

            CreateMap<EntidadDto, EntidadPersonaResponse>().ReverseMap()
            .ForMember(destination => destination.numero_ruc, source => source.MapFrom(src => src.numero_ruc))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.acronimo, source => source.MapFrom(src => src.acronimo))
            .ForMember(destination => destination.nombre, source => source.MapFrom(src => src.nombre));

            #endregion

            #region Document

            CreateMap<Document, DocumentDto>().ReverseMap()
            .ForMember(destination => destination.category, source => source.MapFrom(src => src.category))
            .ForMember(destination => destination.filename, source => source.MapFrom(src => src.filename))
            .ForMember(destination => destination.extension, source => source.MapFrom(src => src.extension))
            .ForMember(destination => destination.size, source => source.MapFrom(src => src.size));

            CreateMap<DocumentDto, DocumentResponse>().ReverseMap()
            .ForMember(destination => destination.category, source => source.MapFrom(src => src.category))
            .ForMember(destination => destination.filename, source => source.MapFrom(src => src.filename))
            .ForMember(destination => destination.extension, source => source.MapFrom(src => src.extension))
            .ForMember(destination => destination.size, source => source.MapFrom(src => src.size));

            CreateMap<DocumentDto, DocumentInsertRequest>().ReverseMap()
           .ForMember(destination => destination.filename, source => source.MapFrom(src => src.filename))
           .ForMember(destination => destination.base64content, source => source.MapFrom(src => src.base64content));

            #endregion

            #region Profesion

            CreateMap<Profesion, ProfesionDto>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<ProfesionDto, ProfesionFilterRequest>().ReverseMap()
           .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
           .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            CreateMap<ProfesionDto, ProfesionResponse>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            #endregion

            #region ModalidadContrato

            CreateMap<ModalidadContrato, ModalidadContratoDto>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            CreateMap<ModalidadContratoDto, ModalidadContratoFilterRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            CreateMap<ModalidadContratoDto, ModalidadContratoResponse>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.codigo, source => source.MapFrom(src => src.codigo))
            .ForMember(destination => destination.abreviatura, source => source.MapFrom(src => src.abreviatura))
            .ForMember(destination => destination.descripcion, source => source.MapFrom(src => src.descripcion));

            #endregion

            #region EntidadOficial

            CreateMap<EntidadOficial, EntidadOficialDto>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.designacion_doc, source => source.MapFrom(src => src.designacion_doc))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.profesion, source => source.MapFrom(src => src.profesion))
            .ForMember(destination => destination.modalidadcontrato, source => source.MapFrom(src => src.modalidadcontrato))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion));

            CreateMap<EntidadOficialDto, EntidadOficialIdRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey));

            CreateMap<EntidadOficialDto, EntidadOficialInsertRequest>().ReverseMap()
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion));

            CreateMap<EntidadOficialDto, EntidadOficialUpdateRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion));

            CreateMap<EntidadOficialDto, EntidadOficialFilterRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            CreateMap<EntidadOficialDto, EntidadOficialResponse>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))            
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion))
            .ForMember(destination => destination.profesion, source => source.MapFrom(src => src.profesion))
            .ForMember(destination => destination.modalidadcontrato, source => source.MapFrom(src => src.modalidadcontrato));

            #endregion

            #region EntidadCoordinador

            CreateMap<EntidadCoordinador, EntidadCoordinadorDto>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.designacion_doc, source => source.MapFrom(src => src.designacion_doc))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.profesion, source => source.MapFrom(src => src.profesion))
            .ForMember(destination => destination.modalidadcontrato, source => source.MapFrom(src => src.modalidadcontrato))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion));

            CreateMap<EntidadCoordinadorDto, EntidadCoordinadorIdRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey));

            CreateMap<EntidadCoordinadorDto, EntidadCoordinadorInsertRequest>().ReverseMap()
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion));

            CreateMap<EntidadCoordinadorDto, EntidadCoordinadorUpdateRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual));

            CreateMap<EntidadCoordinadorDto, EntidadCoordinadorFilterRequest>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.filtro, source => source.MapFrom(src => src.filtro));

            CreateMap<EntidadCoordinadorDto, EntidadCoordinadorResponse>().ReverseMap()
            .ForMember(destination => destination.SerialKey, source => source.MapFrom(src => src.SerialKey))
            .ForMember(destination => destination.entidadkey, source => source.MapFrom(src => src.entidadkey))
            .ForMember(destination => destination.modalidadkey, source => source.MapFrom(src => src.modalidadkey))
            .ForMember(destination => destination.profesionkey, source => source.MapFrom(src => src.profesionkey))
            .ForMember(destination => destination.nombres, source => source.MapFrom(src => src.nombres))
            .ForMember(destination => destination.apellidos, source => source.MapFrom(src => src.apellidos))
            .ForMember(destination => destination.numero_celular, source => source.MapFrom(src => src.numero_celular))
            .ForMember(destination => destination.correo_institucional, source => source.MapFrom(src => src.correo_institucional))
            .ForMember(destination => destination.fecha_inicio, source => source.MapFrom(src => src.fecha_inicio))
            .ForMember(destination => destination.fecha_fin, source => source.MapFrom(src => src.fecha_fin))            
            .ForMember(destination => destination.actual, source => source.MapFrom(src => src.actual))
            .ForMember(destination => destination.documento_designacion, source => source.MapFrom(src => src.documento_designacion))
            .ForMember(destination => destination.profesion, source => source.MapFrom(src => src.profesion))
            .ForMember(destination => destination.modalidadcontrato, source => source.MapFrom(src => src.modalidadcontrato));

            #endregion
        }
    }
}
