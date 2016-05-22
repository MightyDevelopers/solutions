using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Mvc;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.Domain;

namespace SolutionsAI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController: Controller
    {
        private IUserService UserService { get; set; }
        const string Issuer = "http://solutionsai.azurewebsites.net";

        public UsersController(IUserService userService)
        {
            UserService = userService;
        }
        /// <summary>
        /// Sign in method
        /// </summary>
        /// <param name="user">Data required for authentication</param>
        [HttpPost]
        [AllowAnonymous]
        public void Authorize([FromBody] User user)
        {
            if (UserService.UserExists(user).Result)
            {
                SignIn(user.EMail);
            }
            else
            {
                throw new AuthenticationException();
            }
        }

        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="user"></param>
        [HttpPost("new")]
        [AllowAnonymous]
        public void Register([FromBody] User user)
        {
            var commandResult = UserService.CreateUser(user);
            if (commandResult.State == CommandResultState.Success)
            SignIn(commandResult.Result.EMail);
        }

        private void SignIn(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email, ClaimValueTypes.String, Issuer)
            };
            var userIdentity = new ClaimsIdentity("Email");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = true
                }).Wait();
        }
    }
}
