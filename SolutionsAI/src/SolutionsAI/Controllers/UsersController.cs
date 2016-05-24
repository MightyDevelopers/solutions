using System.Security.Authentication;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.Domain;
using SolutionsAI.Interfaces;
using SolutionsAI.Utility;

namespace SolutionsAI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController: Controller, IUsersController
    {
        private IUserService UserService { get; set; }

        public UsersController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public void Authorize([FromBody] User user)
        {
            if (UserService.UserExists(user).Result)
            {
                AuthorizationUtility.SignIn(HttpContext.Authentication, user);
            }
            else
            {
                throw new AuthenticationException();
            }
        }

        [HttpPost("new")]
        [AllowAnonymous]
        public void Register([FromBody] User user)
        {
            var commandResult = UserService.CreateUser(user);
            if (commandResult.State == CommandResultState.Success)
            AuthorizationUtility.SignIn(HttpContext.Authentication, commandResult.Result);
        }
    }
}
