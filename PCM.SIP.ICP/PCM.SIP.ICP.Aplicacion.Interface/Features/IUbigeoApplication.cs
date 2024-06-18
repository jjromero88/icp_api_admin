using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Aplicacion.Interface.Features
{
    public interface IUbigeoApplication
    {
        Task<PcmResponse> GetListDepartamento();
        Task<PcmResponse> GetListProvincia(Request<UbigeoDto> request);
        Task<PcmResponse> GetListDistrito(Request<UbigeoDto> request);
    }
}
