using System.Collections.Generic;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic.Services.Interface
{
    public interface IProfileService
    {
        CommandResult<Profile> GetProfile(string email);
        CommandResult<Profile> UpdateProfile(Profile profile);

        CommandResult<IEnumerable<Profile>> GetAllProfiles();
    }
}
