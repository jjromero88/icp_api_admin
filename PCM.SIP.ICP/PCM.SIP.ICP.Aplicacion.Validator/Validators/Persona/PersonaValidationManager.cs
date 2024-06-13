using FluentValidation.Results;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Validator
{
    public class PersonaValidationManager
    {
        private readonly PersonaIdRequestValidator _PersonaIdRequestValidator;
        private readonly PersonaInsertRequestValidator _PersonaInsertRequestValidator;
        private readonly PersonaUpdateRequestValidator _PersonaUpdateRequestValidator;

        public PersonaValidationManager()
        {
            _PersonaIdRequestValidator = new PersonaIdRequestValidator();
            _PersonaInsertRequestValidator = new PersonaInsertRequestValidator();
            _PersonaUpdateRequestValidator = new PersonaUpdateRequestValidator();
        }

        public ValidationResult Validate(PersonaIdRequest entidad)
        {
            return _PersonaIdRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(PersonaInsertRequest entidad)
        {
            return _PersonaInsertRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(PersonaUpdateRequest entidad)
        {
            return _PersonaUpdateRequestValidator.Validate(entidad);
        }
    }
}
