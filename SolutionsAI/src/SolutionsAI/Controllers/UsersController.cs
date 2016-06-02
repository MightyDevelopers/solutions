using System.Net;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.Interfaces;
using SolutionsAI.Response;
using SolutionsAI.Response.DTOs;
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
        public BaseResponse Register([FromBody] CredentialsDTO credentialsDTO)
        {
            var existingUser = UserService.GetUser(credentialsDTO.ToGetRequest());
            if (existingUser.Result != null)
            {
                return this.GetBasicFailureResponse(
                    HttpStatusCode.Conflict, 
                    "An account for this email already exists.");
            }

            var response = this.GetGenericResponse(
                () => UserService.CreateUser(credentialsDTO.ToCreateRequest()), false);
            if (response.Success)
            {
                AuthorizationUtility.SignIn(HttpContext.Authentication, response.Result);
            }
            return response;
        }
    }
}
