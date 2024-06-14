using Microsoft.Extensions.DependencyInjection;
using PCM.SIP.ICP.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.Infraestructure.Services;

namespace PCM.SIP.ICP.Infraestructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddSingleton<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
