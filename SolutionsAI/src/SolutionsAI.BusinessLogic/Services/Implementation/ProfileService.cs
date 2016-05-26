using System.Collections.Generic;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Commands.Errors;
using SolutionsAI.DataInterface.Commands.Profile;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic.Services.Implementation
{
    public class ProfileService: IProfileService
    {
        private readonly GetAllProfilesCommand _getAllProfilesCommand;
        private readonly GetProfileByEmailCommand _getProfileByEmail;
        private readonly UpdateProfileCommand _updateProfileCommand;

        public ProfileService(
            GetAllProfilesCommand getAllProfilesCommand, 
            GetProfileByEmailCommand getProfileByEmail,
            UpdateProfileCommand updateProfileCommand)
        {
            _getAllProfilesCommand = getAllProfilesCommand;
            _getProfileByEmail = getProfileByEmail;
            _updateProfileCommand = updateProfileCommand;
        }

        public CommandResult<Profile> GetProfile(string email)
        {
            _getProfileByEmail.Init(email);
            return _getProfileByEmail.GetResult();
        }

        public CommandResult<Profile> UpdateProfile(Profile profile)
        {
            _updateProfileCommand.Init(profile);
            return _updateProfileCommand.GetResult();
        }

        public CommandResult<IEnumerable<Profile>> GetAllProfiles()
        {
            return _getAllProfilesCommand.GetResult();
        }
    }
}
