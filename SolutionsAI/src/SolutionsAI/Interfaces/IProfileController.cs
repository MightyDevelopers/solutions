using SolutionsAI.Response;
using SolutionsAI.Response.DTOs;

namespace SolutionsAI.Interfaces
{
    /// <summary>
    /// Profiles API. Requires Authentication.
    /// </summary>
    public interface IProfileController
    {
        /// <summary>
        /// Get user profile
        /// </summary>
        /// <returns>User profile</returns>
        GenericResponse<ProfileDTO> GetProfile();

            /// <summary>
        /// Update existing profile
        /// </summary>
        /// <param name="profile">Updated profile</param>
        /// <returns>Updated profile</returns>
        GenericResponse<ProfileDTO> EditProfile(ProfileDTO profile);
    }
}
