using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Requests.Implementations.GroupsRequests;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic.Services.Implementation
{
    public class GroupService: IGroupService
    {
        private readonly ICanExecuteRequest<CreateGroupRequest, Group> _createGroupCommand;

        public GroupService(ICanExecuteRequest<CreateGroupRequest, Group> createGroupCommand)
        {
            _createGroupCommand = createGroupCommand;
        }

        public CommandResult<Group> CreateGroup(CreateGroupRequest createGroupRequest)
        {
            return _createGroupCommand.ExecuteRequest(createGroupRequest);
        }
    }
}
