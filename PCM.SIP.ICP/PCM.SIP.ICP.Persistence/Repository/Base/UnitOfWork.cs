using PCM.SIP.ICP.Aplicacion.Interface;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;

namespace PCM.SIP.ICP.Persistence.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEntidadGrupoRepository EntidadGrupo { get; }
        public IPersonaRepository Persona { get; }
        public IEntidadSectorRepository EntidadSector { get; }

        public UnitOfWork(
            IEntidadGrupoRepository entidadGrupo, 
            IPersonaRepository persona,
            IEntidadSectorRepository entidadSector)
        {
            EntidadGrupo = entidadGrupo;
            Persona = persona;
            EntidadSector = entidadSector;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
