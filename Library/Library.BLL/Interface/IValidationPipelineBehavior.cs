
namespace Library.BLL.Interface
{
    public interface IValidationPipelineBehavior<TRequest, TResult>
    {
        Task<TResult> Process(TRequest request, Func<Task<TResult>> next);
    }


}
