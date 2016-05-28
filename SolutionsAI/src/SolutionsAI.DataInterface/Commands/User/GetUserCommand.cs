using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Requests.Implementations.UserRequests;

namespace SolutionsAI.DataInterface.Commands.User
{
    public class GetUserCommand: 
        BaseInitializableCommand<Domain.User, Domain.User, GetUserRequest>
    {
        public GetUserCommand(IRepository<Domain.User> repository) : base(repository)
        {
        }

        protected override string Name => "GetUserCommand";

        public override void Execute()
        {
            HandleExecute(() => Repository.GetItem("GetUserByCredentials",
                Repository.GetDataParameter("email", Request.Email),
                Repository.GetDataParameter("password", Request.Password)));
        }
    }
}
