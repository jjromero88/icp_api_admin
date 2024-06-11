﻿using Microsoft.Extensions.DependencyInjection;
using PCM.SIP.ICP.Aplicacion.Interface;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.Persistence.Context;
using PCM.SIP.ICP.Persistence.Repository;
using PCM.SIP.ICP.Persistence.Repository.Base;

namespace PCM.SIP.ICP.Persistence.Configuration
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IEntidadGrupoRepository, EntidadGrupoRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
