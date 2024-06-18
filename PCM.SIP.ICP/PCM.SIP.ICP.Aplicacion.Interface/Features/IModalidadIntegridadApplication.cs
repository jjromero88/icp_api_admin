﻿using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Aplicacion.Interface.Features
{
    public interface IModalidadIntegridadApplication
    {
        Task<PcmResponse> GetList(Request<ModalidadIntegridadDto> request);
    }
}
