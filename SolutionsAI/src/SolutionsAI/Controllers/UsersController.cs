using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.Domain;
using SolutionsAI.Interfaces;
using SolutionsAI.Response;
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
        public BaseResponse Register([FromBody] User user)
        {
            var response = this.GetGenericResponse(() => UserService.CreateUser(user), false);
            if (response.Success)
            {
                AuthorizationUtility.SignIn(HttpContext.Authentication, user);
            }
            return response;
        }
    }
}
