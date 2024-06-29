using FluentValidation;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Validator
{
    public class PreguntaIdRequestValidator : AbstractValidator<PreguntaIdRequest>
    {
        public PreguntaIdRequestValidator()
        {
            RuleFor(u => u.SerialKey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el Id de la Pregunta");
        }
    }
    public class PreguntaInsertRequestValidator : AbstractValidator<PreguntaInsertRequest>
    {
        public PreguntaInsertRequestValidator()
        {
            RuleFor(u => u.componentekey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe seleccionar un componente");

            RuleFor(x => x.numero)
            .NotNull().WithMessage("Debe ingresar el número de la pregunta")
            .GreaterThan(0).WithMessage("El número de pregunta debe ser un número mayor que cero")
            .LessThanOrEqualTo(9999).WithMessage("El número de pregunta debe no puede ser mayor que 9999");

            RuleFor(x => x.numero)
            .Must(CustomValidators.BeValidInteger)
            .WithMessage("El Número de servidores debe ser un número entero.");

            RuleFor(u => u.descripcion)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar la descripción de la pregunta");

            RuleFor(x => x.calculo_icp)
            .NotNull()
            .WithMessage("Debe indicar si esta pregunta está implicada para el cálculo del ICP");

            RuleFor(x => x.habilitado)
            .NotNull()
            .WithMessage("Debe indicar si esta pregunta se encuentra habilitada o deshabilitada");

            RuleFor(x => x.descripcion)
            .MaximumLength(250)
            .WithMessage("La pregunta debe tener un máximo 250 caracteres");

            RuleFor(x => x.lista_alternativas)
            .Must(lista => lista != null && lista.Any())
            .WithMessage("Debe incluir al menos una alternativa para la pregunta.");

            RuleForEach(x => x.lista_alternativas)
            .SetValidator(new AlternativaInsertRequestValidator())
            .WithMessage("Las alternativas deben cumplir con las reglas de validación.");
        }
    }
    public class PreguntaUpdateRequestValidator : AbstractValidator<PreguntaUpdateRequest>
    {
        public PreguntaUpdateRequestValidator()
        {
            RuleFor(u => u.SerialKey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el Id de la Pregunta");

            RuleFor(u => u.componentekey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe seleccionar un componente");

            RuleFor(x => x.numero)
            .NotNull().WithMessage("Debe ingresar el número de la pregunta")
            .GreaterThan(0).WithMessage("El número de pregunta debe ser un número mayor que cero")
            .LessThanOrEqualTo(9999).WithMessage("El número de pregunta debe no puede ser mayor que 9999");

            RuleFor(x => x.numero)
            .Must(CustomValidators.BeValidInteger)
            .WithMessage("El Número de servidores debe ser un número entero.");

            RuleFor(u => u.descripcion)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar la descripción de la pregunta");

            RuleFor(x => x.calculo_icp)
            .NotNull()
            .WithMessage("Debe indicar si esta pregunta está implicada para el cálculo del ICP");

            RuleFor(x => x.habilitado)
            .NotNull()
            .WithMessage("Debe indicar si esta pregunta se encuentra habilitada o deshabilitada");

            RuleFor(x => x.descripcion)
            .MaximumLength(250)
            .WithMessage("La pregunta debe tener un máximo 250 caracteres");

            RuleFor(x => x.lista_alternativas)
            .Must(lista => lista != null && lista.Any())
            .WithMessage("Debe incluir al menos una alternativa para la pregunta.");

            RuleForEach(x => x.lista_alternativas)
            .SetValidator(new AlternativaUpdateRequestValidator())
            .WithMessage("Las alternativas deben cumplir con las reglas de validación.");
        }
    }
}
