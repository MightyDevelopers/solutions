using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Requests.Implementations.ProfileRequests;
using SolutionsAI.DataInterface.Requests.Implementations.UserRequests;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic.Services.Interface
{
    public interface IProfileService
    {
        CommandResult<User> GetProfile(GetUserRequest getProfileByEmailCommand);
        CommandResult<User> UpdateProfile(UpdateProfileRequest updateProfileRequest);
    }
}
