using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Aplicacion.Interface.Features
{
    public interface IEntidadOficialApplication
    {
        Task<PcmResponse> Delete(Request<EntidadOficialDto> request);
        Task<PcmResponse> GetById(Request<EntidadOficialDto> request);
        Task<PcmResponse> GetList(Request<EntidadOficialDto> request);
        Task<PcmResponse> Insert(Request<EntidadOficialDto> request);
        Task<PcmResponse> Update(Request<EntidadOficialDto> request);
    }
}
