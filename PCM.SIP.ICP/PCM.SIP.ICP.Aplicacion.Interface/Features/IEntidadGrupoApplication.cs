using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Interface.Features
{
    public interface IEntidadGrupoApplication
    {
        Task<PcmResponse> Delete(Request<EntidadGrupoDto> request);
        Task<PcmResponse> GetById(Request<EntidadGrupoDto> request);
        Task<PcmResponse> GetList(Request<EntidadGrupoDto> request);
        Task<PcmResponse> Insert(Request<EntidadGrupoDto> request);
        Task<PcmResponse> Update(Request<EntidadGrupoDto> request);
    }
}
