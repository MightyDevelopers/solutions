using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.Domain;
using SolutionsAI.Interfaces;
using SolutionsAI.Response;
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

        public ProfilesController(IProfileService profileRepository)
        {
            ProfileRepository = profileRepository;
        }

        [HttpGet(Name = "GetProfile")]
        public GenericResponse<IEnumerable<Profile>> Get()
        {
            return this.GetGenericResponse(() => ProfileRepository.GetAllUsers());
        }

        [HttpGet("{email}")]
        public GenericResponse<Profile> Get(string email)
        {
            if (User.Claims.Any(claim => claim.Type == ClaimTypes.Email && claim.Value == email))
            {
                return this.GetGenericResponse(()=>ProfileRepository.GetUserProfile(email));
            }
            Response.StatusCode = 403;
            return null;
        }
    }
}
