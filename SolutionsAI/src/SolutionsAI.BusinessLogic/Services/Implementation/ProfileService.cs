using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Requests.Implementations.ProfileRequests;
using SolutionsAI.DataInterface.Requests.Implementations.UserRequests;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic.Services.Implementation
{
    public class ProfileService: IProfileService
    {
        private readonly ICanExecuteRequest<GetUserRequest, User> _getProfileByEmail;
        private readonly ICanExecuteRequest<UpdateProfileRequest, User> _updateProfileCommand;

        public ProfileService(
            ICanExecuteRequest<GetUserRequest, User> getProfileByEmail,
            ICanExecuteRequest<UpdateProfileRequest, User> updateProfileCommand)
        {
            _getProfileByEmail = getProfileByEmail;
            _updateProfileCommand = updateProfileCommand;
        }

        public CommandResult<User> GetProfile(GetUserRequest getProfileByEmailRequest)
        {
            return _getProfileByEmail.ExecuteRequest(getProfileByEmailRequest);
        }

        public CommandResult<User> UpdateProfile(UpdateProfileRequest updateProfileRequest)
        {
            return _updateProfileCommand.ExecuteRequest(updateProfileRequest);
        }
    }
}
