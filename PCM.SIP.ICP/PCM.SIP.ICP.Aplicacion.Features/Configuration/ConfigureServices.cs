using Microsoft.Extensions.DependencyInjection;

namespace PCM.SIP.ICP.Aplicacion.Features
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEntidadGrupoApplication, EntidadGrupoApplication>();

            return services;
        }
    }
}
