using FluentValidation;
using Library.BLL.DTO;

namespace Library.BLL.Validation
{
    public class RegisterUserValidator : AbstractValidator<UserDTO>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .MaximumLength(64);
            
            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(64);

        }
    }
}
