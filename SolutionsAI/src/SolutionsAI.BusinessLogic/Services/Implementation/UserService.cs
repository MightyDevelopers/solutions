using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Commands.User;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic.Services.Implementation
{
    public class UserService: IUserService
    {
        private readonly CheckIfUserExistsCommand _checkIfUserExistsCommand;
        private readonly CreateUserCommand _createUserCommand;

        public UserService(CheckIfUserExistsCommand checkIfUserExistsCommand, CreateUserCommand createUserCommand)
        {
            _checkIfUserExistsCommand = checkIfUserExistsCommand;
            _createUserCommand = createUserCommand;
        }

        public CommandResult<bool> UserExists(User user)
        {
            _checkIfUserExistsCommand.Init(user.EMail);
            return _checkIfUserExistsCommand.GetResult();
        }

        public CommandResult<User> CreateUser(User user)
        {
            _createUserCommand.Init(user);
            return _createUserCommand.GetResult();
        }
    }
}
