using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Requests.Implementations.UserRequests;

namespace SolutionsAI.DataInterface.Commands.User
{
    public class CreateUserCommand: 
        BaseInitializableCommand<Domain.User, Domain.User, CreateUserRequest>
    {
        public CreateUserCommand(IRepository<Domain.User> repository) : base(repository)
        {
        }

        protected override string Name => "CreateUserCommand";

        public override void Execute()
        {
            Repository.GetItem("InsertUser",
                Repository.GetDataParameter("email", Request.Email),
                Repository.GetDataParameter("password", Request.Password));
        }
    }
}
