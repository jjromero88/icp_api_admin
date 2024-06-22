using FluentValidation;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Validator
{
    public class EntidadIdRequestValidator : AbstractValidator<EntidadIdRequest>
    {
        public EntidadIdRequestValidator()
        {
            RuleFor(u => u.SerialKey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el Id de la Entidad");
        }
    }
    public class EntidadInsertRequestValidator : AbstractValidator<EntidadInsertRequest>
    {
        public EntidadInsertRequestValidator()
        {
            RuleFor(u => u.entidadgrupokey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe seleccionar un Grupo");

            RuleFor(u => u.entidadsectorkey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe seleccionar uns Sector");

            RuleFor(x => x.numero_ruc)
            .MaximumLength(11)
            .WithMessage("El RUC debe tener máximo 11 caracteres");

            RuleFor(u => u.nombre)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el Nombre de la entidad");         

            RuleFor(x => x.acronimo)
            .MaximumLength(20)
            .WithMessage("El Acronimo debe tener máximo 20 caracteres");

            RuleFor(x => x.nombre)
            .MaximumLength(150)
            .WithMessage("El nombre debe tener máximo 150 caracteres");

            RuleFor(x => x.numero_ruc)
            .Matches(@"^\d+$")
            .WithMessage("El número RUC solo puede contener dígitos numéricos del 0 al 9");
        }
    }
    public class EntidadUpdateRequestValidator : AbstractValidator<EntidadUpdateRequest>
    {
        public EntidadUpdateRequestValidator()
        {
            RuleFor(u => u.SerialKey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el Id de la Entidad");

            RuleFor(u => u.entidadgrupokey)
           .IsNullOrWhiteSpace()
           .WithMessage("Debe seleccionar un Grupo");

            RuleFor(u => u.entidadsectorkey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe seleccionar uns Sector");

            RuleFor(x => x.numero_ruc)
            .MaximumLength(11)
            .WithMessage("El RUC debe tener máximo 11 caracteres");

            RuleFor(u => u.nombre)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el Nombre de la entidad");

            RuleFor(x => x.codigo)
            .MaximumLength(30)
            .WithMessage("El Codigo debe tener máximo 30 caracteres");

            RuleFor(x => x.acronimo)
            .MaximumLength(20)
            .WithMessage("El Acronimo debe tener máximo 20 caracteres");

            RuleFor(x => x.nombre)
            .MaximumLength(150)
            .WithMessage("El nombre debe tener máximo 150 caracteres");

            RuleFor(x => x.numero_ruc)
            .Matches(@"^\d+$")
            .WithMessage("El número RUC solo puede contener dígitos numéricos del 0 al 9");
        }
    }
}
