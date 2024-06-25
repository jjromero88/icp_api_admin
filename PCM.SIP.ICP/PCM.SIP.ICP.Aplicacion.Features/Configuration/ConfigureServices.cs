using Microsoft.Extensions.DependencyInjection;
using PCM.SIP.ICP.Aplicacion.Interface.Features;

namespace PCM.SIP.ICP.Aplicacion.Features
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEntidadGrupoApplication, EntidadGrupoApplication>();
            services.AddScoped<IEntidadSectorApplication, EntidadSectorApplication>();
            services.AddScoped<IModalidadIntegridadApplication, ModalidadIntegridadApplication>();
            services.AddScoped<IUbigeoApplication, UbigeoApplication>();
            services.AddScoped<IPersonaApplication, PersonaApplication>();
            services.AddScoped<IEntidadApplication, EntidadApplication>();
            services.AddScoped<IDocumentoEstructuraApplication, DocumentoEstructuraApplication>();

            services.AddScoped<IDocumentService, DocumentService>();


            return services;
        }
    }
}
