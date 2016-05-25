using System.Net;
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
    public class AuthorizationController: Controller, IAuthorizationController
    {
        private IUserService UserService { get; set; }

        public AuthorizationController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public BaseResponse Authorize([FromBody] User user)
        {
            if (UserService.UserExists(user).Result)
            {
                AuthorizationUtility.SignIn(HttpContext.Authentication, user);
                return this.GetBasicSuccessResponse();
            }
            return this.GetBasicFailureResponse(HttpStatusCode.Unauthorized);
        }
    }
}
