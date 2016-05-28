using System;
using System.ComponentModel;
using SolutionsAI.DatabaseTools;

namespace SolutionsAI.DataInterface.Commands.Base
{
    public abstract class BaseInitializableCommand<TEntity, TResult, TRequest> 
        : BaseCommand<TEntity, TResult>, ISupportInitialize,
        ICanExecuteRequest<TRequest, TResult>
    {
        protected TRequest Request { get; set; }

        public BaseInitializableCommand(IRepository<TEntity> repository) : base(repository)
        {
        }

        public CommandResult<TResult> ExecuteRequest(TRequest request)
        {
            Init(request);
            return GetResult();
        }

        public virtual void Init(TRequest request)
        {
            Init(() => { Request = request; });
        }
        
        public virtual void BeginInit()
        {
            State = CommandState.Created;
            Result = new CommandResult<TResult>
            {
                State = CommandResultState.Pending
            };
        }

        public virtual void EndInit()
        {
            State = CommandState.Initialized;
        }

        protected void Init(Action action)
        {
            BeginInit();
            action();
            EndInit();
        }

        protected void Init()
        {
            Init(() => { });
        }
    }
}
