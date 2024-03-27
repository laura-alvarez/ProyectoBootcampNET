using FluentValidation;
using TaskManager.Application.Models.Users;

namespace TaskManager.Application.Validations
{
    public class StateValidation : AbstractValidator<StateRequestModel>
    {
        public StateValidation() {
            RuleFor(x => x.State)
               .NotEmpty().WithMessage("Ingresa el nombre de la categoría").WithErrorCode("1")
               .NotNull().WithMessage("El nombre de la categoría es obligatorio").WithErrorCode("1")
               .MaximumLength(50).WithMessage("El nombre de categoría puede tener un máximo de 50 caracteres").WithErrorCode("1");
        }    
    }
}
