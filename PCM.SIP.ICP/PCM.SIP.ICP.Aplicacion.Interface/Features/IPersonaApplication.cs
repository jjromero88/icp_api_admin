using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Aplicacion.Interface.Features
{
    public interface IPersonaApplication
    {
        Task<PcmResponse> Delete(Request<PersonaDto> request);
        Task<PcmResponse> GetById(Request<PersonaDto> request);
        Task<PcmResponse> GetList(Request<PersonaDto> request);
        Task<PcmResponse> Insert(Request<PersonaDto> request);
        Task<PcmResponse> Update(Request<PersonaDto> request);
    }
}
