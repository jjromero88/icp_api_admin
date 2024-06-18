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
            services.AddScoped<IPersonaApplication, PersonaApplication>();

            return services;
        }
    }
}
