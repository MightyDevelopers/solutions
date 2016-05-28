using SolutionsAI.Response;
using SolutionsAI.Response.DTOs;

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
        /// <param name="credentialsDTO">Data required for authentication</param>
        BaseResponse Authorize(CredentialsDTO credentialsDTO);

        /// <summary>
        /// Signs out
        /// </summary>
        /// <returns></returns>
        BaseResponse SignOut();
    }
}
