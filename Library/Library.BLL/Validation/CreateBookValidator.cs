using FluentValidation;
using Library.BLL.DTO;
using System.Globalization;

namespace Library.BLL.Validation
{
    public class CreateBookValidator : AbstractValidator<CreateBookDTO>
    {
        public CreateBookValidator()
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
        private static bool BeValidDateTime(DateTime dateTime)
        {
            var timeString = dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            return DateTime.TryParseExact(timeString, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
            //return dateTime != DateTime.MinValue;
        }
    }
}
