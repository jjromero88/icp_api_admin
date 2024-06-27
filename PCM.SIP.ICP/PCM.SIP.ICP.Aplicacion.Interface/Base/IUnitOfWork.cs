using PCM.SIP.ICP.Aplicacion.Interface.Persistence;

namespace PCM.SIP.ICP.Aplicacion.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IEntidadGrupoRepository EntidadGrupo { get; }
        IEntidadSectorRepository EntidadSector { get; }
        IPersonaRepository Persona { get; }
        IModalidadIntegridadRepository ModalidadIntegridad { get; }
        IUbigeoRepository Ubigeo { get; }
        IEntidadRepository Entidad { get; }
        IDocumentoEstructuraRepository DocumentoEstructura { get; }
        IDocumentRepository DocumentRepository { get; }
        IProfesionRepository Profesion { get; }
        IModalidadContratoRepository ModalidadContrato { get; }
        IEntidadOficialRepository EntidadOficial { get; }
        IEntidadCoordinadorRepository EntidadCoordinador { get; }
    }
}
