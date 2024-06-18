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

            services.AddTransient<IValidator<PersonaIdRequest>, PersonaIdRequestValidator>();
            services.AddTransient<IValidator<PersonaInsertRequest>, PersonaInsertRequestValidator>();
            services.AddTransient<IValidator<PersonaUpdateRequest>, PersonaUpdateRequestValidator>();
            services.AddTransient<PersonaValidationManager>();

            services.AddTransient<IValidator<EntidadIdRequest>, EntidadIdRequestValidator>();
            services.AddTransient<IValidator<EntidadInsertRequest>, EntidadInsertRequestValidator>();
            services.AddTransient<IValidator<EntidadUpdateRequest>, EntidadUpdateRequestValidator>();
            services.AddTransient<EntidadValidationManager>();

            return services;
        }
    }
}
