using Microsoft.Extensions.DependencyInjection;
using PCM.SIP.ICP.Aplicacion.Interface;
using PCM.SIP.ICP.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.Persistence.Context;
using PCM.SIP.ICP.Persistence.Repository;
using PCM.SIP.ICP.Persistence.Repository.Base;

namespace PCM.SIP.ICP.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IEntidadGrupoRepository, EntidadGrupoRepository>();
            services.AddScoped<IEntidadSectorRepository, EntidadSectorRepository>();
            services.AddScoped<IModalidadIntegridadRepository, ModalidadIntegridadRepository>();
            services.AddScoped<IUbigeoRepository, UbigeoRepository>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IEntidadRepository, EntidadRepository>();
            services.AddScoped<IDocumentoEstructuraRepository, DocumentoEstructuraRepository>();

            services.AddScoped<IDocumentRepository, DocumentRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
