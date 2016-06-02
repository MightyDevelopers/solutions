using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.Domain;
using SolutionsAI.Interfaces;
using SolutionsAI.Response;
using SolutionsAI.Response.DTOs;
using SolutionsAI.Utility;

namespace SolutionsAI.Controllers
{
    /// <summary>
    /// Profiles API. Requires Authentication.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    public class ProfilesController : Controller, IProfileController
    {
        private IProfileService ProfileRepository { get; set; }
        private IUserService UserService { get; set; }

        public ProfilesController(IProfileService profileRepository, IUserService userService)
        {
            ProfileRepository = profileRepository;
            UserService = userService;
        }

        [HttpGet]
        public GenericResponse<ProfileDTO> GetProfile()
        {
            return this.GetGenericResponse<User, ProfileDTO>(
                userId => UserService.GetUser(userId.ToGetUserRequest()), false);
        }

        [HttpPut]
        public GenericResponse<ProfileDTO> EditProfile([FromBody] ProfileDTO profile)
        {
            return this.GetGenericResponse<User, ProfileDTO>(
                email =>
                {
                    profile.Email = email;
                    return ProfileRepository.UpdateProfile(profile.ToUpdateRequest());
                },
                false);
        }
    }
}
