using FluentValidation.Results;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Validator
{
    public class EntidadGrupoValidationManager
    {
        private readonly EntidadGrupoIdRequestValidator _EntidadGrupoIdRequestValidator;
        private readonly EntidadGrupoInsertRequestValidator _EntidadGrupoInsertRequestValidator;
        private readonly EntidadGrupoUpdateRequestValidator _EntidadGrupoUpdateRequestValidator;

        public EntidadGrupoValidationManager()
        {
            _EntidadGrupoIdRequestValidator = new EntidadGrupoIdRequestValidator();
            _EntidadGrupoInsertRequestValidator = new EntidadGrupoInsertRequestValidator();
            _EntidadGrupoUpdateRequestValidator = new EntidadGrupoUpdateRequestValidator();
        }

        public ValidationResult Validate(EntidadGrupoIdRequest entidad)
        {
            return _EntidadGrupoIdRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(EntidadGrupoInsertRequest entidad)
        {
            return _EntidadGrupoInsertRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(EntidadGrupoUpdateRequest entidad)
        {
            return _EntidadGrupoUpdateRequestValidator.Validate(entidad);
        }
    }
}
