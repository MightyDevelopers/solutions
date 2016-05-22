using System;
using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Base;

namespace SolutionsAI.DataInterface.Commands.User
{
    public class CheckIfUserExistsCommand: BaseCommand<Domain.User, bool>
    {
        private string _email;

        public CheckIfUserExistsCommand(IRepository<Domain.User> repository) : base(repository)
        {
        }

        protected override string Name => "CheckIfUserExistsCommand";

        public void Init(string email)
        {
            BeginInit();
            _email = email;
            EndInit();
        }

        public override void Execute()
        {
            HandleExecute(() => Repository.HasResult("GetUserByEmail", Repository.GetDataParameter("email", _email)));
        }
    }
}
