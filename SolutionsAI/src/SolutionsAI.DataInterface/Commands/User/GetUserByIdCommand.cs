using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Requests.Implementations.UserRequests;

namespace SolutionsAI.DataInterface.Commands.User
{
    public class GetUserByIdCommand: BaseInitializableCommand<Domain.User, Domain.User, GetUserByIdRequest>
    {
        public GetUserByIdCommand(IRepository<Domain.User> repository) : base(repository)
        {
        }

        protected override string Name { get; }
        public override void Execute()
        {
            HandleExecute(()=> Repository.GetItem("GetUserById",
                Repository.GetDataParameter("userId", Request.UserId)));
        }
    }
}
