using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Interface.Features
{
    public interface IEntidadGrupoApplication
    {
        PcmResponse Insert(Request<EntidadGrupoDto> request);
        PcmResponse Update(Request<EntidadGrupoDto> request);
        PcmResponse Delete(Request<EntidadGrupoDto> request);
        PcmResponse GetById(Request<EntidadGrupoDto> request);
        PcmResponse GetList(Request<EntidadGrupoDto> request);
    }
}
