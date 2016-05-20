using System.Collections.Generic;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic.Services.Interface
{
    public interface IProfileService
    {
        CommandResult<Profile> GetUserProfile(string email);

        CommandResult<IEnumerable<Profile>> GetAllUsers();
    }
}
