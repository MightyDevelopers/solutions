using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Requests.Implementations.UserRequests;

namespace SolutionsAI.DataInterface.Commands.User
{
    public class CheckIfUserExistsCommand: 
        BaseInitializableCommand<Domain.User, bool, CheckIfUserExistsRequest>
    {
        public CheckIfUserExistsCommand(IRepository<Domain.User> repository) : base(repository)
        {
        }

        protected override string Name => "CheckIfUserExistsCommand";

        public override void Execute()
        {
            HandleExecute(() => Repository.HasResult("GetUserByCredentials", 
                Repository.GetDataParameter("email", Request.Email),
                Repository.GetDataParameter("password", Request.Password)));
        }
    }
}
