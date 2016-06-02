namespace SolutionsAI.DataInterface.Commands.Base
{
    public interface ICanExecuteRequest<in TRequest, TResult>
    {
        CommandResult<TResult> ExecuteRequest(TRequest request);
    }
}
