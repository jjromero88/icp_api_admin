using FluentValidation.Results;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Validator
{
    public class EntidadValidationManager
    {
        private readonly EntidadIdRequestValidator _entidadIdRequestValidator;
        private readonly EntidadInsertRequestValidator _entidadInsertRequestValidator;
        private readonly EntidadUpdateRequestValidator _entidadUpdateRequestValidator;
        private readonly GeneralidadesUpdateRequestValidator _generalidadesUpdateRequestValidator;

        public EntidadValidationManager()
        {
            _entidadIdRequestValidator = new EntidadIdRequestValidator();
            _entidadInsertRequestValidator = new EntidadInsertRequestValidator();
            _entidadUpdateRequestValidator = new EntidadUpdateRequestValidator();
            _generalidadesUpdateRequestValidator = new GeneralidadesUpdateRequestValidator();
        }

        public ValidationResult Validate(EntidadIdRequest entidad)
        {
            return _entidadIdRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(EntidadInsertRequest entidad)
        {
            return _entidadInsertRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(EntidadUpdateRequest entidad)
        {
            return _entidadUpdateRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(GeneralidadesUpdateRequest entidad)
        {
            return _generalidadesUpdateRequestValidator.Validate(entidad);
        }
    }
}
