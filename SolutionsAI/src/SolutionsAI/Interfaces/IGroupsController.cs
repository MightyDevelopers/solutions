using SolutionsAI.Requests;
using SolutionsAI.Response;
using SolutionsAI.Response.DTOs;

namespace SolutionsAI.Interfaces
{
    /// <summary>
    /// Allows to access and manage user groups
    /// </summary>
    public interface IGroupsController
    {
        /// <summary>
        /// Creates a new users group
        /// </summary>
        /// <param name="nameRequest">Contains name of the group to create</param>
        /// <returns>Create group</returns>
        GenericResponse<GroupDTO> CreateGroup(NameRequest nameRequest);
    }
}
