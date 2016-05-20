using System.Collections.Generic;
using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Base;

namespace SolutionsAI.DataInterface.Commands.Profile
{
    public class GetAllProfilesCommand: BaseCommand<Domain.Profile, IEnumerable<Domain.Profile>>
    {
        public GetAllProfilesCommand(IRepository<Domain.Profile> repository): base(repository)
        {
        }

        protected override string Name => "GetAllProfiles";

        public override void Execute()
        {
            Init();
            HandleExecute(() => Repository.GetItems("GetAllUsers"));
        }
    }
}
