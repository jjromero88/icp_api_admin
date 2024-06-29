using PCM.SIP.ICP.Aplicacion.Interface;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;

namespace PCM.SIP.ICP.Persistence.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEntidadGrupoRepository EntidadGrupo { get; }
        public IPersonaRepository Persona { get; }
        public IEntidadSectorRepository EntidadSector { get; }
        public IModalidadIntegridadRepository ModalidadIntegridad { get; }
        public IUbigeoRepository Ubigeo { get; }
        public IEntidadRepository Entidad { get; }
        public IDocumentoEstructuraRepository DocumentoEstructura { get; }
        public IDocumentRepository DocumentRepository { get; }
        public IProfesionRepository Profesion { get; }
        public IModalidadContratoRepository ModalidadContrato { get; }
        public IEntidadOficialRepository EntidadOficial { get; }
        public IEntidadCoordinadorRepository EntidadCoordinador { get; }
        public IComponenteRepository Componente { get; }
        public IPreguntaRepository Pregunta {  get; }
        public IAlternativaRepository Alternativa {  get; }

        public UnitOfWork(
            IEntidadGrupoRepository entidadGrupo,
            IPersonaRepository persona,
            IEntidadSectorRepository entidadSector,
            IModalidadIntegridadRepository modalidadIntegridad,
            IUbigeoRepository ubigeo,
            IEntidadRepository entidad,
            IDocumentoEstructuraRepository documentoEstructura,
            IDocumentRepository documentRepository,
            IProfesionRepository profesion,
            IModalidadContratoRepository modalidadContrato,
            IEntidadOficialRepository entidadOficial,
            IEntidadCoordinadorRepository entidadCoordinador,
            IComponenteRepository componente,
            IPreguntaRepository pregunta,
            IAlternativaRepository alternativa)
        {
            EntidadGrupo = entidadGrupo;
            Persona = persona;
            EntidadSector = entidadSector;
            ModalidadIntegridad = modalidadIntegridad;
            Ubigeo = ubigeo;
            Entidad = entidad;
            DocumentoEstructura = documentoEstructura;
            DocumentRepository = documentRepository;
            Profesion = profesion;
            ModalidadContrato = modalidadContrato;
            EntidadOficial = entidadOficial;
            EntidadCoordinador = entidadCoordinador;
            Componente = componente;
            Pregunta = pregunta;
            Alternativa = alternativa;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
