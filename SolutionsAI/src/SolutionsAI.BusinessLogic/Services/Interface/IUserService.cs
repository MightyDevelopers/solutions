using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic.Services.Interface
{
    public interface IUserService
    {
        CommandResult<bool> UserExists(User user);
        CommandResult<User> CreateUser(User user);
    }
}
