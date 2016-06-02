using SolutionsAI.DataInterface.Requests.Implementations.GroupsRequests;
using SolutionsAI.DataInterface.Requests.Implementations.ProfileRequests;
using SolutionsAI.DataInterface.Requests.Implementations.UserRequests;
using SolutionsAI.Requests;
using SolutionsAI.Response.DTOs;

namespace SolutionsAI.Utility
{
    public static class DTOExtensions
    {
        public static UpdateProfileRequest ToUpdateRequest(this ProfileDTO profileDTO)
        {
            return new UpdateProfileRequest
            {
                LastName = profileDTO.LastName,
                FirstName = profileDTO.FirstName,
                Email = profileDTO.Email
            };
        }

        public static CreateGroupRequest ToCreateRequest(this NameRequest nameRequest, int userId)
        {
            return new CreateGroupRequest(nameRequest.Name, userId);
        }

        public static CreateUserRequest ToCreateRequest(this CredentialsDTO credentialsDTO)
        {
            return new CreateUserRequest
            {
                Email = credentialsDTO.Email,
                Password = credentialsDTO.Password
            };
        }

        public static GetUserRequest ToGetRequest(this CredentialsDTO credentialsDTO)
        {
            return new GetUserRequest
            {
                Email = credentialsDTO.Email,
                Password = credentialsDTO.Password
            };
        }

        public static CheckIfUserExistsRequest ToCheckRequest(this CredentialsDTO credentialsDTO)
        {
            return new CheckIfUserExistsRequest
            {
                Email = credentialsDTO.Email,
                Password = credentialsDTO.Password
            };
        }

        public static GetUserByIdRequest ToGetUserRequest(this int userId)
        {
            return new GetUserByIdRequest
            {
                UserId = userId
            };
        }
    }
}
