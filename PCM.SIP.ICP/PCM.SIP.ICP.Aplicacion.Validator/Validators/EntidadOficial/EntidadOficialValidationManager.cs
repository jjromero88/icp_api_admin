using FluentValidation.Results;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Validator
{
    public class EntidadOficialValidationManager
    {
        private readonly EntidadOficialIdRequestValidator _entidadOficialIdRequestValidator;
        private readonly EntidadOficialInsertRequestValidator _entidadOficialInsertRequestValidator;
        private readonly EntidadOficialUpdateRequestValidator _entidadOficialUpdateRequestValidator;

        public EntidadOficialValidationManager()
        {
            _entidadOficialIdRequestValidator = new EntidadOficialIdRequestValidator();
            _entidadOficialInsertRequestValidator = new EntidadOficialInsertRequestValidator();
            _entidadOficialUpdateRequestValidator = new EntidadOficialUpdateRequestValidator();
        }

        public ValidationResult Validate(EntidadOficialIdRequest entidad)
        {
            return _entidadOficialIdRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(EntidadOficialInsertRequest entidad)
        {
            return _entidadOficialInsertRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(EntidadOficialUpdateRequest entidad)
        {
            return _entidadOficialUpdateRequestValidator.Validate(entidad);
        }
    }
}
