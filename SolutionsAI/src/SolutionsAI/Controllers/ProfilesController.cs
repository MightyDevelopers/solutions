using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using SolutionsAI.Data;
using SolutionsAI.DataInterface;

namespace SolutionsAI.Controllers
{
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {
        private IProfileRepository ProfileRepository { get; set; }

        public ProfilesController(IProfileRepository profileRepository)
        {
            ProfileRepository = profileRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Profile> Get()
        {
            return ProfileRepository.GetAllUsers();
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
            return ProfileRepository.GetUserProfile(email);
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
