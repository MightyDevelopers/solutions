using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using SolutionsAI.Data;
using SolutionsAI.DatabaseTools;

namespace SolutionsAI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private ConnectionOptions ConnectionOptions { get; set; }

        public UsersController(IOptions<ConnectionOptions> options)
        {
            ConnectionOptions = options.Value;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Profile> Get()
        {
            var repo = new UserRepository(ConnectionOptions);
            return repo.GetAllUsers();
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
            return new UserRepository(ConnectionOptions).GetUserProfile(email);
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
