using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Requests.Implementations.UserRequests;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic.Services.Interface
{
    public interface IUserService
    {
        CommandResult<bool> UserExists(CheckIfUserExistsRequest checkIfUserExistsRequest);
        CommandResult<User> CreateUser(CreateUserRequest createUserRequest);
        CommandResult<User> GetUser(GetUserRequest getUserRequest);
        CommandResult<User> GetUser(GetUserByIdRequest getUserRequest);
    }
}
