using FluentValidation;
using TaskManager.Application.Models.Users;

namespace TaskManager.Application.Validations
{
    public class UserValidation : AbstractValidator<UserRequestModel>
    {
        public UserValidation() {
            RuleFor(x=> x.Name)
                .NotEmpty().WithMessage("El nombre no puede estar vacío")
                .NotNull().WithMessage("El nombre es un campo obligatorio")
                .MaximumLength(50).WithMessage("El nombre no puede tener una longitud superior a 50")
                .Matches(@"^[A-Za-z\s]+$").WithMessage("El nombre solo puede contener letras y espacios");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido no puede estar vacío")
                .NotNull().WithMessage("El apellido es un campo obligatorio")
                .MaximumLength(100).WithMessage("El apellido no puede tener una longitud superior a 100")
                .Matches(@"^[A-Za-z\s]+$").WithMessage("El apellido solo puede contener letras y espacios");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email no puede estar vacío")
                .NotNull().WithMessage("El email es un campo obligatorio")
                .EmailAddress().WithMessage("Introduzca un email valido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El password no puede estar vacío")
                .NotNull().WithMessage("El password es un campo obligatorio")
                .MaximumLength(16).WithMessage("El password debe tener una longitud máxima de 16 caracteres")
                .MinimumLength(4).WithMessage("El password debe tener una longitud mínima de 4 caracteres");

        }
    }
}
