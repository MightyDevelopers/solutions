using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using SolutionsAI.Domain;

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
        IEnumerable<Profile> Get();

        /// <summary>
        /// Returns user's profile by email. (You can get only your profile right now.)
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User profile</returns>
        Profile Get(string email);
    }
}
