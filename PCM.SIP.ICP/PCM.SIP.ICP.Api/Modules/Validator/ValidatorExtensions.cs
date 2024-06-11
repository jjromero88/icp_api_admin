using FluentValidation;
using PCM.SIP.ICP.Aplicacion.Dto;
using PCM.SIP.ICP.Aplicacion.Validator;

namespace PCM.SIP.ICP.Api.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<EntidadGrupoIdRequest>, EntidadGrupoIdRequestValidator>();
            services.AddTransient<IValidator<EntidadGrupoInsertRequest>, EntidadGrupoInsertRequestValidator>();
            services.AddTransient<IValidator<EntidadGrupoUpdateRequest>, EntidadGrupoUpdateRequestValidator>();
            services.AddTransient<EntidadGrupoValidationManager>();

            return services;
        }
    }
}
