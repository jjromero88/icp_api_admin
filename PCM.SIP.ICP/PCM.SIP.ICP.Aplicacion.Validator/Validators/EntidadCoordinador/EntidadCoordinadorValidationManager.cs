using FluentValidation.Results;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Validator
{
    public class EntidadCoordinadorValidationManager
    {
        private readonly EntidadCoordinadorIdRequestValidator _EntidadCoordinadorIdRequestValidator;
        private readonly EntidadCoordinadorInsertRequestValidator _EntidadCoordinadorInsertRequestValidator;
        private readonly EntidadCoordinadorUpdateRequestValidator _EntidadCoordinadorUpdateRequestValidator;

        public EntidadCoordinadorValidationManager()
        {
            _EntidadCoordinadorIdRequestValidator = new EntidadCoordinadorIdRequestValidator();
            _EntidadCoordinadorInsertRequestValidator = new EntidadCoordinadorInsertRequestValidator();
            _EntidadCoordinadorUpdateRequestValidator = new EntidadCoordinadorUpdateRequestValidator();
        }

        public ValidationResult Validate(EntidadCoordinadorIdRequest entidad)
        {
            return _EntidadCoordinadorIdRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(EntidadCoordinadorInsertRequest entidad)
        {
            return _EntidadCoordinadorInsertRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(EntidadCoordinadorUpdateRequest entidad)
        {
            return _EntidadCoordinadorUpdateRequestValidator.Validate(entidad);
        }
    }
}
