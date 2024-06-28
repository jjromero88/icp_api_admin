using FluentValidation.Results;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Validator
{
    public class PreguntaValidationManager
    {
        private readonly PreguntaIdRequestValidator _preguntaIdRequestValidator;
        private readonly PreguntaInsertRequestValidator _preguntaInsertRequestValidator;
        private readonly PreguntaUpdateRequestValidator _preguntaUpdateRequestValidator;

        public PreguntaValidationManager()
        {
            _preguntaIdRequestValidator = new PreguntaIdRequestValidator();
            _preguntaInsertRequestValidator = new PreguntaInsertRequestValidator();
            _preguntaUpdateRequestValidator = new PreguntaUpdateRequestValidator();
        }

        public ValidationResult Validate(PreguntaIdRequest entidad)
        {
            return _preguntaIdRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(PreguntaInsertRequest entidad)
        {
            return _preguntaInsertRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(PreguntaUpdateRequest entidad)
        {
            return _preguntaUpdateRequestValidator.Validate(entidad);
        }
    }
}
