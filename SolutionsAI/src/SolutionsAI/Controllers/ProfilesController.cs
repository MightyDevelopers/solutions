using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.Domain;

namespace SolutionsAI.Controllers
{
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {
        private IProfileService ProfileRepository { get; set; }

        public ProfilesController(IProfileService profileRepository)
        {
            ProfileRepository = profileRepository;
        }

        // GET: api/values
        [HttpGet]
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
            return ProfileRepository.GetUserProfile(email).Result;
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
