﻿using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Transversal.Common.Generics;
using PCM.SIP.ICP.Transversal.Common;

namespace PCM.SIP.ICP.Aplicacion.Interface.Features
{
    public interface IModalidadContratoApplication
    {
        Task<PcmResponse> GetList(Request<ModalidadContratoDto> request);
    }
}
