using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Aplicacion.Interface.Persistence
{
    public interface IEntidadRepository : IGenericRepository<Entidad>
    {
        Response UpdateGeneralidades(Entidad entidad);
        Response<List<dynamic>> GetListGeneralidades(Entidad entidad);
    }
}
