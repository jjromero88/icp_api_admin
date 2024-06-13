using FluentValidation;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Validator
{
    public class PersonaIdRequestValidator : AbstractValidator<PersonaIdRequest>
    {
        public PersonaIdRequestValidator()
        {
            RuleFor(u => u.SerialKey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el Id de la persona");
        }
    }
    public class PersonaInsertRequestValidator : AbstractValidator<PersonaInsertRequest>
    {
        public PersonaInsertRequestValidator()
        {
            RuleFor(u => u.nombres)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar los nombres");

            RuleFor(u => u.apellido_paterno)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el apellido paterno");

            RuleFor(u => u.numdocumento)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el número de documento");

            RuleFor(u => u.email)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el correo electrónico");

            RuleFor(u => u.email)
            .EmailAddress()
            .WithMessage("Debe ingresar un formato valido para el correo electroncio");

            RuleFor(x => x.nombres)
            .MaximumLength(80)
            .WithMessage("Los nombres debe tener máximo 80 caracteres");

            RuleFor(x => x.nombres)
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
            .WithMessage("El nombre solo puede contener letras y espacios");

            RuleFor(x => x.apellido_paterno)
            .MaximumLength(80)
            .WithMessage("El apellido paterno debe tener máximo 80 caracteres");

            RuleFor(x => x.apellido_paterno)
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
            .WithMessage("El nombre solo puede contener letras y espacios");

            RuleFor(x => x.apellido_materno)
            .MaximumLength(80)
            .WithMessage("El apellido materno debe tener máximo 80 caracteres");

            RuleFor(x => x.apellido_materno)
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
            .WithMessage("El nombre solo puede contener letras y espacios");

            RuleFor(x => x.numdocumento)
            .MaximumLength(20)
            .WithMessage("La número de documento debe tener máximo 20 caracteres");

            RuleFor(x => x.numdocumento)
            .NotEmpty()
            .WithMessage("Debe ingresar el número de documento")
            .Matches(@"^[a-zA-Z0-9-]+$")
            .WithMessage("El número de documento solo puede contener letras, números y guiones");

            RuleFor(x => x.email)
            .MaximumLength(50)
            .WithMessage("El email debe tener máximo 50 caracteres");

            RuleFor(x => x.telefono_movil)
            .MaximumLength(20)
            .WithMessage("El télefono móvil debe tener máximo 20 caracteres");
        }
    }
    public class PersonaUpdateRequestValidator : AbstractValidator<PersonaUpdateRequest>
    {
        public PersonaUpdateRequestValidator()
        {
            RuleFor(u => u.SerialKey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el Id de la persona");

            RuleFor(u => u.nombres)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar los nombres");

            RuleFor(u => u.apellido_paterno)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el apellido paterno");

            RuleFor(u => u.numdocumento)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el número de documento");

            RuleFor(u => u.email)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el correo electrónico");

            RuleFor(u => u.email)
            .EmailAddress()
            .WithMessage("Debe ingresar un formato valido para el correo electroncio");

            RuleFor(x => x.nombres)
            .MaximumLength(80)
            .WithMessage("Los nombres debe tener máximo 80 caracteres");

            RuleFor(x => x.nombres)
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
            .WithMessage("El nombre solo puede contener letras y espacios");

            RuleFor(x => x.apellido_paterno)
            .MaximumLength(80)
            .WithMessage("El apellido paterno debe tener máximo 80 caracteres");

            RuleFor(x => x.apellido_paterno)
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
            .WithMessage("El nombre solo puede contener letras y espacios");

            RuleFor(x => x.apellido_materno)
            .MaximumLength(80)
            .WithMessage("El apellido materno debe tener máximo 80 caracteres");

            RuleFor(x => x.apellido_materno)
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
            .WithMessage("El nombre solo puede contener letras y espacios");

            RuleFor(x => x.numdocumento)
            .MaximumLength(20)
            .WithMessage("La número de documento debe tener máximo 20 caracteres");

            RuleFor(x => x.numdocumento)
            .NotEmpty()
            .WithMessage("Debe ingresar el número de documento")
            .Matches(@"^[a-zA-Z0-9-]+$")
            .WithMessage("El número de documento solo puede contener letras, números y guiones");

            RuleFor(x => x.email)
            .MaximumLength(50)
            .WithMessage("El email debe tener máximo 50 caracteres");

            RuleFor(x => x.telefono_movil)
            .MaximumLength(20)
            .WithMessage("El télefono móvil debe tener máximo 20 caracteres");
        }
    }
}
