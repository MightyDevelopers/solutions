using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Base;

namespace SolutionsAI.DataInterface.Commands.User
{
    public class CreateUserCommand: BaseCommand<Domain.User, Domain.User>
    {
        private Domain.User _user;

        public CreateUserCommand(IRepository<Domain.User> repository) : base(repository)
        {
        }

        protected override string Name => "CreateUserCommand";

        public void Init(Domain.User user)
        {
            BeginInit();
            _user = user;
            EndInit();
        }

        public override void Execute()
        {
            Repository.GetItem("InsertUser",
                Repository.GetDataParameter("email", _user.EMail),
                Repository.GetDataParameter("password", _user.Password));
        }
    }
}
