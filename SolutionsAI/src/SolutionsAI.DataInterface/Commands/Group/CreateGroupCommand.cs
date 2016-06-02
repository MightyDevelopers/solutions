using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Requests.Implementations.GroupsRequests;

namespace SolutionsAI.DataInterface.Commands.Group
{
    public class CreateGroupCommand: 
        BaseInitializableCommand<Domain.Group, Domain.Group, CreateGroupRequest>
    {
        public CreateGroupCommand(IRepository<Domain.Group> repository) : base(repository)
        {
        }

        protected override string Name => "CreateGroupCommand";

        public override void Execute()
        {
            HandleExecute(()=> Repository.GetItem("InsertGroup",
                Repository.GetDataParameter("name", Request.Name),
                Repository.GetDataParameter("userId", Request.UserId)));
        }
    }
}
