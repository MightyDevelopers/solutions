using SolutionsAI.Response;
using SolutionsAI.Response.DTOs;

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
        /// <param name="credentialsDTO">Credentials</param>
        BaseResponse Register(CredentialsDTO credentialsDTO);
    }
}
