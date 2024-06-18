using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Aplicacion.Interface.Features
{
    public interface IEntidadApplication
    {
        Task<PcmResponse> Delete(Request<EntidadDto> request);
        Task<PcmResponse> GetById(Request<EntidadDto> request);
        Task<PcmResponse> GetList(Request<EntidadDto> request);
        Task<PcmResponse> Insert(Request<EntidadDto> request);
        Task<PcmResponse> Update(Request<EntidadDto> request);
    }
}
