using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Transversal.Common;
using PCM.SIP.ICP.Transversal.Common.Generics;

namespace PCM.SIP.ICP.Aplicacion.Features
{
    public interface IEntidadGrupoApplication
    {
        PcmResponse Delete(Request<EntidadGrupoDto> request);
        PcmResponse GetById(Request<EntidadGrupoDto> request);
        PcmResponse GetList(Request<EntidadGrupoDto> request);
        PcmResponse Insert(Request<EntidadGrupoDto> request);
        PcmResponse Update(Request<EntidadGrupoDto> request);
    }
}