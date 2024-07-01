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
            services.AddScoped<IProfesionApplication, ProfesionApplication>();
            services.AddScoped<IModalidadContratoApplication, ModalidadContratoApplication>();
            services.AddScoped<IEntidadOficialApplication, EntidadOficialApplication>();
            services.AddScoped<IEntidadCoordinadorApplication, EntidadCoordinadorApplication>();
            services.AddScoped<IComponenteApplication, ComponenteApplication>();
            services.AddScoped<IPreguntaApplication, PreguntaApplication>();
            services.AddScoped<IAlternativaApplication, AlternativaApplication>();
            services.AddScoped<IEtapaApplication, EtapaApplication>();
            services.AddScoped<IDocumentService, DocumentService>();
            
            return services;
        }
    }
}
