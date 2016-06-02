using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Requests.Implementations.UserRequests;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic.Services.Implementation
{
    public class UserService: IUserService
    {
        private readonly ICanExecuteRequest<CheckIfUserExistsRequest, bool> _checkIfUserExistsCommand;
        private readonly ICanExecuteRequest<CreateUserRequest, User> _createUserCommand;
        private readonly ICanExecuteRequest<GetUserRequest, User> _getUserCommand;
        private readonly ICanExecuteRequest<GetUserByIdRequest, User> _getUserByIdCommand;

        public UserService(
            ICanExecuteRequest<CheckIfUserExistsRequest, bool> checkIfUserExistsCommand,
            ICanExecuteRequest<CreateUserRequest, User> createUserCommand,
            ICanExecuteRequest<GetUserRequest, User> getUserCommand,
            ICanExecuteRequest<GetUserByIdRequest, User> getUserByIdCommand)
        {
            _checkIfUserExistsCommand = checkIfUserExistsCommand;
            _createUserCommand = createUserCommand;
            _getUserCommand = getUserCommand;
            _getUserByIdCommand = getUserByIdCommand;
        }

        public CommandResult<bool> UserExists(CheckIfUserExistsRequest checkIfUserExistsRequest)
        {
            return _checkIfUserExistsCommand.ExecuteRequest(checkIfUserExistsRequest);
        }

        public CommandResult<User> CreateUser(CreateUserRequest createUserRequest)
        {
            return _createUserCommand.ExecuteRequest(createUserRequest);
        }

        public CommandResult<User> GetUser(GetUserRequest getUserRequest)
        {
            return _getUserCommand.ExecuteRequest(getUserRequest);
        }

        public CommandResult<User> GetUser(GetUserByIdRequest getUserRequest)
        {
            return _getUserByIdCommand.ExecuteRequest(getUserRequest);
        }
    }
}
