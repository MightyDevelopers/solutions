using System;
using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Errors;

namespace SolutionsAI.DataInterface.Commands.Base
{
    public abstract class BaseCommand<TEntity, TResult>
    {
        protected readonly IRepository<TEntity> Repository;
        
        protected BaseCommand(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        protected abstract string Name { get; }
        protected CommandState State { get; set; }
        protected CommandResult<TResult> Result { get; set; }

        public abstract void Execute();
        
        public CommandResult<TResult> GetResult()
        {
            Execute();
            return Result;
        }

        protected void HandleExecute(Func<TResult> getResult)
        {
            try
            {
                State = CommandState.ExecutionRequested;
                var result = getResult();
                Result.Result = result;
                Result.State = CommandResultState.Success;
            }
            catch (Exception ex)
            {
                Result.State = CommandResultState.Failure;
                Result.Error = new CommandError
                {
                    Exception = new CommandException($"Failed to execute {Name} command", ex),
                    LastState = State
                };
            }
            finally
            {
                State = CommandState.Executed;
            }
        }
    }
}
