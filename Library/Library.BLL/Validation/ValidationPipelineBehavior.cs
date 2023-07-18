using FluentValidation;
using Library.BLL.DTO;
using Library.BLL.Interface;

namespace Library.BLL.Validation
{
    public class ValidationPipelineBehavior<TRequest, TResult> : IValidationPipelineBehavior<TRequest, TResult>
    {
        public async Task<TResult> Process(TRequest request, Func<Task<TResult>> next)
        {
            var validator = GetValidator<TRequest>();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new ValidationException("The entry is incorrect");
            }

            return await next();
        }

        private IValidator<TRequest> GetValidator<TRequest>()
        {
            if (typeof(TRequest) == typeof(UpdateBookDTO))
            {
                return new UpdateBookValidator() as IValidator<TRequest>;
            }
            else if (typeof(TRequest) == typeof(CreateBookDTO))
            {
                return new CreateBookValidator() as IValidator<TRequest>;
            }

            throw new InvalidOperationException("No validator found for the given request type.");
        }
    }
}
