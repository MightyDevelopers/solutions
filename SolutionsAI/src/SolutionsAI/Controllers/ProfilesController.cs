using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.Domain;

namespace SolutionsAI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {
        private IProfileService ProfileRepository { get; set; }

        public ProfilesController(IProfileService profileRepository)
        {
            ProfileRepository = profileRepository;
        }

        // GET: api/values
        [HttpGet(Name = "GetProfile")]
        public IEnumerable<Profile> Get()
        {
            return ProfileRepository.GetAllUsers().Result;
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

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

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
