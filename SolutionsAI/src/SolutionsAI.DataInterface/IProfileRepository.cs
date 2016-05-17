using System.Collections.Generic;
using SolutionsAI.Data;

namespace SolutionsAI.DataInterface
{
    public interface IProfileRepository
    {
        Profile GetUserProfile(string email);

        IEnumerable<Profile> GetAllUsers();
    }
}
