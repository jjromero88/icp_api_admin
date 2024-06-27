using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Aplicacion.Interface.Features
{
    public interface IEntidadCoordinadorApplication
    {
        Task<PcmResponse> Delete(Request<EntidadCoordinadorDto> request);
        Task<PcmResponse> GetById(Request<EntidadCoordinadorDto> request);
        Task<PcmResponse> GetList(Request<EntidadCoordinadorDto> request);
        Task<PcmResponse> Insert(Request<EntidadCoordinadorDto> request);
        Task<PcmResponse> Update(Request<EntidadCoordinadorDto> request);
    }
}
