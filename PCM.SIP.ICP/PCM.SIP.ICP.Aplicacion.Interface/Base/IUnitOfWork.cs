﻿using PCM.SIP.ICP.Aplicacion.Interface.Persistence;

namespace PCM.SIP.ICP.Aplicacion.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IEntidadGrupoRepository EntidadGrupo { get; }
        IPersonaRepository Persona { get; }
    }
}
