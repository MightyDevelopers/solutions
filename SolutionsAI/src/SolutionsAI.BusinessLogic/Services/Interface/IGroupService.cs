using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Requests.Implementations.GroupsRequests;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic.Services.Interface
{
    public interface IGroupService
    {
        CommandResult<Group> CreateGroup(CreateGroupRequest createGroupRequest);
    }
}
