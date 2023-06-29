using FluentValidation;
using Library.BLL.DTO;

namespace Library.BLL.Validation
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookDTO>
    {
        public UpdateBookValidator()
        {
            RuleFor(b => b.ISBN)
            .NotEmpty();

            RuleFor(b => b.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(b => b.Genre)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(b => b.Description)
                .MaximumLength(500);

            RuleFor(b => b.Author)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(b => b.BookBorrowedTime)
                .NotEmpty()
                .Must(BeValidDateTime)
                .WithMessage("BookBorrowedTime should be a valid DateTime");

            RuleFor(b => b.BookReturnDeadline)
                .NotEmpty()
                .Must(BeValidDateTime)
                .WithMessage("BookReturnDeadline should be a valid DateTime")
                .GreaterThan(b => b.BookBorrowedTime)
                .WithMessage("BookReturnDeadline should be greater than BookBorrowedTime");
        }
        private bool BeValidDateTime(DateTime dateTime)
        {
            return dateTime != DateTime.MinValue;
        }
    }
}

