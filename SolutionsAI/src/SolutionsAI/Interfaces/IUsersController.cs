using Microsoft.AspNet.Mvc;
using SolutionsAI.Domain;
using SolutionsAI.Response;

namespace SolutionsAI.Interfaces
{
    /// <summary>
    /// Controller to manage users
    /// </summary>
    public interface IUsersController
    {
        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="user"></param>
        BaseResponse Register([FromBody] User user);
    }
}
