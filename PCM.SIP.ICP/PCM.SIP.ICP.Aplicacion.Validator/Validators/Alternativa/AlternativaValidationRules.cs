using FluentValidation;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Validator
{
    public class AlternativaInsertRequestValidator : AbstractValidator<AlternativaInsertRequest>
    {
        public AlternativaInsertRequestValidator()
        {
            RuleFor(x => x.alternativa)
            .NotEmpty().WithMessage("La alternativa es obligatoria.")
            .MaximumLength(5).WithMessage("La alternativa debe tener como máximo 5 caracteres.");

            RuleFor(x => x.descripcion)
            .NotEmpty().WithMessage("La descripción es obligatoria.")
            .MaximumLength(200).WithMessage("La descripción debe tener como máximo 200 caracteres.");

            RuleFor(x => x.valor)
            .NotNull().WithMessage("El valor es obligatorio.")
            .GreaterThanOrEqualTo(0).WithMessage("El valor debe ser mayor que 0.")
            .LessThanOrEqualTo(1).WithMessage("El valor debe ser menor que 1.")
            .Must(CustomValidators.BeValidDecimal).WithMessage("El valor ICP debe ser un valor decimal.");

            RuleFor(x => x.numero_orden)
            .NotNull().WithMessage("El número de orden es obligatorio.")
            .GreaterThan(0).WithMessage("El número de orden debe ser mayor que 0.")
            .LessThan(999).WithMessage("El número de orden debe ser menor que 999.")
            .Must(CustomValidators.BeValidInteger).WithMessage("El número de orden debe ser un valor entero.");
        }
    }

    public class AlternativaUpdateRequestValidator : AbstractValidator<AlternativaUpdateRequest>
    {
        public AlternativaUpdateRequestValidator()
        {
            RuleFor(x => x.alternativa)
            .NotEmpty().WithMessage("La alternativa es obligatoria.")
            .MaximumLength(5).WithMessage("La alternativa debe tener como máximo 5 caracteres.");

            RuleFor(x => x.descripcion)
            .NotEmpty().WithMessage("La descripción es obligatoria.")
            .MaximumLength(200).WithMessage("La descripción debe tener como máximo 200 caracteres.");

            RuleFor(x => x.valor)
            .NotNull().WithMessage("El valor es obligatorio.")
            .GreaterThanOrEqualTo(0).WithMessage("El valor debe ser mayor que 0.")
            .LessThanOrEqualTo(1).WithMessage("El valor debe ser menor que 1.")
            .Must(CustomValidators.BeValidDecimal).WithMessage("El valor ICP debe ser un valor decimal.");

            RuleFor(x => x.numero_orden)
            .NotNull().WithMessage("El número de orden es obligatorio.")
            .GreaterThan(0).WithMessage("El número de orden debe ser mayor que 0.")
            .LessThan(999).WithMessage("El número de orden debe ser menor que 999.")
            .Must(CustomValidators.BeValidInteger).WithMessage("El número de orden debe ser un valor entero.");
        }
    }
}
