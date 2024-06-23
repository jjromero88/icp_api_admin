using PCM.SIP.ICP.Aplicacion.Interface;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;

namespace PCM.SIP.ICP.Persistence.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEntidadGrupoRepository EntidadGrupo { get; }
        public IPersonaRepository Persona { get; }
        public IEntidadSectorRepository EntidadSector { get; }
        public IModalidadIntegridadRepository ModalidadIntegridad {  get; }
        public IUbigeoRepository Ubigeo { get; }
        public IEntidadRepository Entidad { get; }
        public IDocumentoEstructuraRepository DocumentoEstructura { get; }

        public UnitOfWork(
            IEntidadGrupoRepository entidadGrupo, 
            IPersonaRepository persona,
            IEntidadSectorRepository entidadSector,
            IModalidadIntegridadRepository modalidadIntegridad,
            IUbigeoRepository ubigeo,
            IEntidadRepository entidad,
            IDocumentoEstructuraRepository documentoEstructura)
        {
            EntidadGrupo = entidadGrupo;
            Persona = persona;
            EntidadSector = entidadSector;
            ModalidadIntegridad = modalidadIntegridad;
            Ubigeo = ubigeo;
            Entidad = entidad;
            DocumentoEstructura = documentoEstructura;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
