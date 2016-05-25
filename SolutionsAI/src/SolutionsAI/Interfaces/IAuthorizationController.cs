using Microsoft.AspNet.Mvc;
using SolutionsAI.Domain;
using SolutionsAI.Response;

namespace SolutionsAI.Interfaces
{
    /// <summary>
    /// Moved authentication to separate controller. Not exactly API type of thing.
    /// </summary>
    public interface IAuthorizationController
    {
        /// <summary>
        /// Sign in method
        /// </summary>
        /// <param name="user">Data required for authentication</param>
        BaseResponse Authorize([FromBody] User user);
    }
}
