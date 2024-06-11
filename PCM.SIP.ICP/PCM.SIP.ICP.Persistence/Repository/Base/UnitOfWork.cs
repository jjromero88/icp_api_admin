using PCM.SIP.ICP.Aplicacion.Interface;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;

namespace PCM.SIP.ICP.Persistence.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEntidadGrupoRepository EntidadGrupo { get; }

        public UnitOfWork(
            IEntidadGrupoRepository entidadGrupo)
        {
            EntidadGrupo = entidadGrupo;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
