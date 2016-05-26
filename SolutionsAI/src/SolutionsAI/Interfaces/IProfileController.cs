using System.Collections.Generic;
using SolutionsAI.Domain;
using SolutionsAI.Response;

namespace SolutionsAI.Interfaces
{
    /// <summary>
    /// Profiles API. Requires Authentication.
    /// </summary>
    public interface IProfileController
    {
        /// <summary>
        /// Returns list of profiles
        /// </summary>
        /// <returns>All profiles</returns>
        GenericResponse<IEnumerable<Profile>> Get();

        /// <summary>
        /// Returns user's profile by email. (You can get only your profile right now.)
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User profile</returns>
        GenericResponse<Profile> Get(string email);

        /// <summary>
        /// Update existing profile
        /// </summary>
        /// <param name="profile">Updated profile</param>
        /// <returns>Updated profile</returns>
        GenericResponse<Profile> EditProfile(Profile profile);
    }
}
