using System.Collections.Generic;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Commands.Profile;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic.Services.Implementation
{
    public class ProfileService: IProfileService
    {
        private readonly GetAllProfilesCommand _getAllProfilesCommand;
        private readonly GetProfileByEmail _getProfileByEmail;

        public ProfileService(GetAllProfilesCommand getAllProfilesCommand, GetProfileByEmail getProfileByEmail)
        {
            _getAllProfilesCommand = getAllProfilesCommand;
            _getProfileByEmail = getProfileByEmail;
        }

        public CommandResult<Profile> GetUserProfile(string email)
        {
            _getProfileByEmail.Init(email);
            return _getProfileByEmail.GetResult();
        }

        public CommandResult<IEnumerable<Profile>> GetAllUsers()
        {
            return _getAllProfilesCommand.GetResult();
        }
    }
}
