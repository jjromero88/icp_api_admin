using PCM.SIP.ICP.Domain.Entities;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Aplicacion.Interface.Persistence
{
    public interface IUbigeoRepository
    {
        Response<List<dynamic>> GetListDepartamentos();
        Response<List<dynamic>> GetListProvincias(Ubigeo entidad);
        Response<List<dynamic>> GetListDistritos(Ubigeo entidad);
    }
}
