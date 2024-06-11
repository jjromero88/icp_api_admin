using PCM.SIP.ICP.Transversal.Common;
using PCM.SIP.ICP.Transversal.Logging;

namespace PCM.SIP.ICP.Api.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}
