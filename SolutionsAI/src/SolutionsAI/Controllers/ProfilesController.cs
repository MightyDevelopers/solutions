using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.Domain;

namespace SolutionsAI.Controllers
{
    /// <summary>
    /// Profiles API. Requires Authentication.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {
        private IProfileService ProfileRepository { get; set; }

        public ProfilesController(IProfileService profileRepository)
        {
            ProfileRepository = profileRepository;
        }

        /// <summary>
        /// Returns list of profiles
        /// </summary>
        /// <returns>All profiles</returns>
        [HttpGet(Name = "GetProfile")]
        public IEnumerable<Profile> Get()
        {
            return ProfileRepository.GetAllUsers().Result;
        }

        /// <summary>
        /// Returns user's profile by email. (You can get only your profile right now.)
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("{email}")]
        public Profile Get(string email)
        {
            if (User.Claims.Any(claim => claim.Type == ClaimTypes.Email && claim.Value == email))
            {
                return ProfileRepository.GetUserProfile(email).Result;
            }
            Response.StatusCode = 403;
            return null;
        }
    }
}
