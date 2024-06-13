using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Aplicacion.Interface.Persistence
{
    public interface IPersonaRepository
    {
        Response Insert(Persona entidad, out string id);
        Response Update(Persona entidad);
        Response Delete(Persona entidad);
        Response<dynamic> GetById(Persona entidad);
        Response<List<dynamic>> GetList(Persona entidad);
    }
}
