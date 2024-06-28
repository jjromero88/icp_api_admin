using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Aplicacion.Interface.Features
{
    public interface IPreguntaApplication
    {
        Task<PcmResponse> Delete(Request<PreguntaDto> request);
        Task<PcmResponse> GetById(Request<PreguntaDto> request);
        Task<PcmResponse> GetList(Request<PreguntaDto> request);
        Task<PcmResponse> Insert(Request<PreguntaDto> request);
        Task<PcmResponse> Update(Request<PreguntaDto> request);
    }
}
