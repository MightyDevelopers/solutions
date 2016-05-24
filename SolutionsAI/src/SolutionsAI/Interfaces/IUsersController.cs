using Microsoft.AspNet.Mvc;
using SolutionsAI.Domain;

namespace SolutionsAI.Interfaces
{
    /// <summary>
    /// Controller to manage users
    /// </summary>
    public interface IUsersController
    {
        /// <summary>
        /// Sign in method
        /// </summary>
        /// <param name="user">Data required for authentication</param>
        void Authorize([FromBody] User user);

        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="user"></param>
        void Register([FromBody] User user);
    }
}
