using System;
using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Base;

namespace SolutionsAI.DataInterface.Commands.Profile
{
    public class GetProfileByEmail: BaseCommand<Domain.Profile, Domain.Profile>
    {
        protected override string Name => "GetProfileByEmail";
        private string _email = string.Empty;

        public GetProfileByEmail(IRepository<Domain.Profile> repository) : base(repository)
        {
        }

        public void Init(string email)
        {
            BeginInit();
            _email = email;
            EndInit();
        }

        public override void Execute()
        {
            HandleExecute(() => Repository.GetItem("GetUserByEmail", Repository.GetDataParameter("email", _email)));
        }
    }
}
