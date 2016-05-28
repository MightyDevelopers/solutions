using System.Net;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.DataInterface.Commands.User;
using SolutionsAI.Domain;
using SolutionsAI.Interfaces;
using SolutionsAI.Response;
using SolutionsAI.Response.DTOs;
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
        public BaseResponse Authorize([FromBody] CredentialsDTO request)
        {
            if (UserService.UserExists(request.ToCheckRequest()).Result)
            {
                var existingUser = UserService.GetUser(request.ToGetRequest());
                AuthorizationUtility.SignIn(HttpContext.Authentication, existingUser.Result);
                return this.GetBasicSuccessResponse();
            }
            return this.GetBasicFailureResponse(HttpStatusCode.Unauthorized);
        }

        [HttpDelete]
        public BaseResponse SignOut()
        {
            AuthorizationUtility.SignOut(HttpContext.Authentication);
            return this.GetBasicSuccessResponse();
        }
    }
}
