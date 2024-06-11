using FluentValidation;
using PCM.SIP.ICP.Aplicacion.Dto;

namespace PCM.SIP.ICP.Aplicacion.Validator
{
    public class EntidadGrupoIdRequestValidator : AbstractValidator<EntidadGrupoIdRequest>
    {
        public EntidadGrupoIdRequestValidator()
        {
            RuleFor(u => u.SerialKey)
                .IsNullOrWhiteSpace()
                  .WithMessage("Debe ingresar el Id del EntidadGrupo");
        }
    }
    public class EntidadGrupoInsertRequestValidator : AbstractValidator<EntidadGrupoInsertRequest>
    {
        public EntidadGrupoInsertRequestValidator()
        {
            RuleFor(u => u.codigo)
                .IsNullOrWhiteSpace()
                .WithMessage("Debe ingresar un codigo");

            RuleFor(u => u.abreviatura)
                .IsNullOrWhiteSpace()
                .WithMessage("Debe ingresar una abreviatura");

            RuleFor(u => u.descripcion)
                .IsNullOrWhiteSpace()
                .WithMessage("Debe ingresar una descripcion");

            RuleFor(x => x.codigo)
                .MaximumLength(10)
                .WithMessage("El codigo debe tener máximo 10 caracteres");

            RuleFor(x => x.abreviatura)
               .MaximumLength(20)
               .WithMessage("La abreviatura debe tener máximo 20 caracteres");

            RuleFor(x => x.descripcion)
                .MaximumLength(50)
                .WithMessage("La descripcion debe tener máximo 50 caracteres");
        }
    }
    public class EntidadGrupoUpdateRequestValidator : AbstractValidator<EntidadGrupoUpdateRequest>
    {
        public EntidadGrupoUpdateRequestValidator()
        {
            RuleFor(u => u.SerialKey)
                .IsNullOrWhiteSpace()
                  .WithMessage("Debe ingresar el Id del Tipo de documento");

            RuleFor(u => u.codigo)
                .IsNullOrWhiteSpace()
                .WithMessage("Debe ingresar un codigo");

            RuleFor(u => u.abreviatura)
                .IsNullOrWhiteSpace()
                .WithMessage("Debe ingresar una abreviatura");

            RuleFor(u => u.descripcion)
                .IsNullOrWhiteSpace()
                .WithMessage("Debe ingresar una descripcion");

            RuleFor(x => x.codigo)
                .MaximumLength(10)
                .WithMessage("El codigo debe tener máximo 10 caracteres");

            RuleFor(x => x.abreviatura)
               .MaximumLength(20)
               .WithMessage("La abreviatura debe tener máximo 20 caracteres");

            RuleFor(x => x.descripcion)
                .MaximumLength(50)
                .WithMessage("La descripcion debe tener máximo 50 caracteres");
        }
    }
}
